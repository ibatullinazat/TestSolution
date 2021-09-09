using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CreditAPI.Data;
using CreditAPI.Models;

namespace CreditAPI.Repositories
{
    public class ApplicationRepository : IRepository
    {
        private readonly IDbContext _context;
        public ApplicationRepository(IDbContext context)
        {
            _context = context;

        }
        public async Task Add(Application application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var itemToRemove = await _context.Applications.FindAsync(id);
            if (itemToRemove == null)
                throw new NullReferenceException();

            _context.Applications.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<Application> Get(int id)
        {
            return await _context.Applications.FindAsync(id);
        }

        public async Task<IEnumerable<Application>> GetAll()
        {
            return await _context.Applications.ToListAsync();
        }

        public async Task Update(Application application)
        {
            var itemToUpdate = await _context.Applications.FindAsync(application.Id);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            _context.Applications.Update(application);
            await _context.SaveChangesAsync();

        }
    }
}
