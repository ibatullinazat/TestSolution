using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CreditAPI.Models;

namespace CreditAPI.Data
{
    public interface IDbContext
    {
        DbSet<Application> Applications { get; set; }
        DbSet<Person> Persons { get; set; }
        DbSet<RequestedCredit> RequestedCredits { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
