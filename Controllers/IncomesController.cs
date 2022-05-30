using economyopedia_server.Data;
using economyopedia_server.Enums;
using economyopedia_server.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace economyopedia_server.Controllers
{
    public class IncomesController : BaseController<Income>
    {
        private readonly EconomyopediaDbContext _context;
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly ILogger _logger;

        public IncomesController(EconomyopediaDbContext context, ILogger<IncomesController> logger) : base(context)
        {
            _context = context;
            _logger = logger;
             
        }


        [HttpGet]
        public async Task<IncomeDataResponse> GetMonthlyIncome(TaxTableNumberEnum tableNumber)
        {

            double grossMonthly = 0;
            double taxPaid = 0;
            double totalExtraIncome = 0;
            double netMonthly = 0;

            var taxableYearly = _context.Incomes.FirstOrDefault(x => x.IncomeType == Common.IncomeTypeEnum.TaxableYearly);


            if (taxableYearly != null)
            {
                var response = await _httpClient
                    .GetAsync($"https://taxbase.herokuapp.com/GetTaxByTable?yearlySalary={taxableYearly.Amount}&taxTable={tableNumber}");

                if(!response.IsSuccessStatusCode)
                {
                    _logger.LogError("Fetching from taxbase failed.");
                } else
                {
                    _logger.LogInformation("Fetch from taxbase succeeded.");
                }

                var data = await response.Content.ReadAsStringAsync();

                var taxableSalaryInformation = JsonConvert.DeserializeObject<TaxCalculatorResponse>(data);

                grossMonthly = taxableSalaryInformation.GrossMonthly;
                taxPaid = taxableSalaryInformation.TaxPaid;
                netMonthly = taxableSalaryInformation.NetMonthly;

            }

            var extraIncome = _context.Incomes.Where(x => x.IncomeType == Common.IncomeTypeEnum.NonTaxableMonthly);

            if (extraIncome != null)
            {
                totalExtraIncome = extraIncome.Sum(x => x.Amount);

            }


            return new IncomeDataResponse()
            {
                NetMonthly = netMonthly + totalExtraIncome,
                MonthlyIncome = grossMonthly + totalExtraIncome,
                TaxPayed = taxPaid
            };
        }
    }
}


