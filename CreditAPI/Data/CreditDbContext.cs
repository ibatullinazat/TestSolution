using Microsoft.EntityFrameworkCore;
using CreditAPI.Models;

namespace CreditAPI.Data
{
    public class CreditDbContext : DbContext, IDbContext
    {
        public CreditDbContext(DbContextOptions<CreditDbContext> options)
           : base(options)
        {

        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<RequestedCredit> RequestedCredits { get; set; }
    }
}
