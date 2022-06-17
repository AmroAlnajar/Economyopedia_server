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
                new Expense(){Amount = 7500 ,Title = "Husleie", IncludeInCalculation = true},
                new Expense(){Amount = 2000 ,Title = "Strøm", IncludeInCalculation = true},
                new Expense(){Amount = 590 ,Title = "Bil forsikring", IncludeInCalculation = true},
                new Expense(){Amount = 589 ,Title = "Amro sin mobil", IncludeInCalculation = true},
                new Expense(){Amount = 479 ,Title = "Hala sin mobil", IncludeInCalculation = true},
                new Expense(){Amount = 10 ,Title = "apple cloud", IncludeInCalculation = true},
                new Expense(){Amount = 60 ,Title = "Youtube music", IncludeInCalculation = true},
                new Expense(){Amount = 3860 ,Title = "Bil lån", IncludeInCalculation = true},
                new Expense(){Amount = 2500 ,Title = "Lånekasse", IncludeInCalculation = true},
                new Expense(){Amount = 833 ,Title = "NAV", IncludeInCalculation = true},
                new Expense(){Amount = 1755 ,Title = "NAV 2", IncludeInCalculation = true},
                new Expense(){Amount = 3000 ,Title = "Mat og drikke", IncludeInCalculation = true}
            };

            var incomesList = new List<Income>()
            {
                new Income() {Title = "Yearly salary", IncomeType = Common.IncomeTypeEnum.TaxableYearly, Amount = 550000},
                new Income() {Title= "Extra income", IncomeType = Common.IncomeTypeEnum.NonTaxableMonthly, Amount = 0}
            };

            _context.Expenses.AddRange(expensesList);
            _context.Incomes.AddRange(incomesList);

            _context.SaveChanges();
        }

    }
}



