using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditAPI.Models;

namespace CreditAPI.Repositories
{
    public interface IRepository
    {
        Task<Application> Get(int id);
        Task<IEnumerable<Application>> GetAll();
        Task Add(Application product);
        Task Delete(int id);
        Task Update(Application product);
    }
}
