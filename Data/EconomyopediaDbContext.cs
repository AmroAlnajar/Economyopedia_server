using economyopedia_server.Models;
using Microsoft.EntityFrameworkCore;

namespace economyopedia_server.Data
{
    public class EconomyopediaDbContext: DbContext
    {
        public EconomyopediaDbContext(DbContextOptions<EconomyopediaDbContext> options): base(options)
        {

        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
    }
}
