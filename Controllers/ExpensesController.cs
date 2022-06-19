using economyopedia_server.Data;
using economyopedia_server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace economyopedia_server.Controllers
{
    

    public class ExpensesController : BaseController<Expense>
    {
        private readonly EconomyopediaDbContext _context;

        public ExpensesController(EconomyopediaDbContext context) : base(context)
        {
            _context = context;
        }

        [HttpGet]
        public TotalExpensesResponse GetTotalExpenses()
        {
            return new TotalExpensesResponse()
            {
                TotalExpenses = _context.Expenses.Where(x => x.IncludeInCalculation == true).Select(x => x.Amount).Sum()
            };
        }

        [HttpGet]
        public override List<Expense> GetAll()
        {
            return _context.Expenses
                .OrderByDescending(x => x.Amount)
                .ToList();
        }

        [HttpPost]
        public IActionResult SetIncludeInCalculation(int id, bool status)
        {
            var expense = _context.Expenses.FirstOrDefault(x => x.Id == id);

            if (expense == null)
                return BadRequest();

            expense.IncludeInCalculation = status;

            _context.Expenses.Update(expense);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public double GetTotalExcluded()
        {
            return _context.Expenses.Where(x => x.IncludeInCalculation == false).Select(x => x.Amount).Sum();
        }
    }
}
