using lab210.DAL.Entitati;
using lab210.DAL.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab210.DAL.Repositories
{
    public class OrasRepository : IOrasRepository
    {
        private readonly AppDbContext _context;

        public OrasRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Oras oras)
        {
            await _context.Orase.AddAsync(oras);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Oras oras)
        {
            _context.Orase.Remove(oras);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Oras>> GetAll()
        {
            var orase = await(await GetQuery()).ToListAsync();
            return orase;
        }

        public async Task<Oras> GetById(int id)
        {
            var orase = await _context.Orase.FindAsync(id);
            return orase;
        }

        public async Task<IQueryable<Oras>> GetQuery()
        {
            var query = _context.Orase.AsQueryable();
            return query;
        }

        public async Task Update(Oras oras)
        {
            _context.Orase.Update(oras);
            await _context.SaveChangesAsync();
        }
    }
}
