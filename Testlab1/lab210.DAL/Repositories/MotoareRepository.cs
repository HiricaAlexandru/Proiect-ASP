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
    public class MotoareRepository : IMotorRepository
    {
        private readonly AppDbContext _context;
        public MotoareRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Motor motor)
        {
            await _context.Motoare.AddAsync(motor);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Motor motor)
        {
            _context.Motoare.Remove(motor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Motor>> GetAll()
        {
            var motoare = await (await GetQuery()).Include(x=>x.ListaMotoare).ToListAsync();
            return motoare;
        }

        public async Task<Motor> GetById(int id)
        {
            var motor = await _context.Motoare.FindAsync(id);
            return motor;
        }

        public async Task<IQueryable<Motor>> GetQuery()
        {
            var query = _context.Motoare.AsQueryable().Include(x=>x.ListaMotoare);
            return query; ;
        }

        public async Task Update(Motor motor)
        {
            _context.Motoare.Update(motor);
            await _context.SaveChangesAsync();
        }
    }
}
