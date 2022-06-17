using economyopedia_server.Common;
using economyopedia_server.Data;
using economyopedia_server.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace economyopedia_server.Models
{
    public class Expense : BaseModel
    {

        private readonly EconomyopediaDbContext _context;

        public Expense(EconomyopediaDbContext context)
        {
            _context = context;
        }

        public Expense()
        {

        }

        public double PercentageOfExpenses
        {
            get
            {
                if (_context == null)
                {
                    return 0;
                }
                var sumOfExpenses = _context.Expenses.Select(x => x.Amount).Sum();
                var percentage = (Amount / sumOfExpenses) * 100;

                return Math.Round(percentage, 2);

            }
        }
        public bool IncludeInCalculation { get; set; }
    }
}
