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
    public class ProducatorRepository : IProducatorRepository
    {
        private readonly AppDbContext _context;

        public ProducatorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Producator producator)
        {
            await _context.Producatori.AddAsync(producator);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Producator producator)
        {
            _context.Producatori.Remove(producator);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Producator>> GetAll()
        {
            var producatori = await(await GetQuery()).ToListAsync();
            return producatori;
        }

        public async Task<Producator> GetById(int id)
        {
            var producatori = await _context.Producatori.FindAsync(id);
            return producatori;
        }

        public async Task<IQueryable<Producator>> GetQuery()
        {
            var query = _context.Producatori.AsQueryable();
            return query;
        }

        public async Task Update(Producator producator)
        {
            _context.Producatori.Update(producator);
            await _context.SaveChangesAsync();
        }
    }
}
