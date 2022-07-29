using economyopedia_server.Data;
using economyopedia_server.Models;

namespace economyopedia_server.Helpers
{
    public static class DbSeeder
    {
        public static void Seed(EconomyopediaDbContext _context)
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            var expensesList = new List<Expense>() {
                new Expense(){Amount = 7500 ,Title = "Husleie"},
                new Expense(){Amount = 2000 ,Title = "Strøm"},
                new Expense(){Amount = 590 ,Title = "Bil forsikring"},
                new Expense(){Amount = 589 ,Title = "Amro sin mobil"},
                new Expense(){Amount = 479 ,Title = "Hala sin mobil"},
                new Expense(){Amount = 10 ,Title = "apple cloud"},
                new Expense(){Amount = 60 ,Title = "Youtube music"},
                new Expense(){Amount = 3860 ,Title = "Bil lån"},
                new Expense(){Amount = 2857 ,Title = "Lånekasse"},
                new Expense(){Amount = 833 ,Title = "NAV"},
                new Expense(){Amount = 1755 ,Title = "NAV 2"},
                new Expense(){Amount = 3000 ,Title = "Mat og drikke"}
            };

            var incomesList = new List<Income>()
            {
                new Income() {Title = "Yearly salary", IncomeType = Common.IncomeTypeEnum.TaxableYearly, Amount = 561240},
                new Income() {Title= "Extra income", IncomeType = Common.IncomeTypeEnum.NonTaxableMonthly, Amount = 0}
            };

            _context.Expenses.AddRange(expensesList);
            _context.Incomes.AddRange(incomesList);

            _context.SaveChanges();
        }

    }
}



