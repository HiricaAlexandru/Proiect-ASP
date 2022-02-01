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
    public class ModelRepository : IModelRepository
    {
        private readonly AppDbContext _context;

        public ModelRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Model model)
        {
            await _context.Modele.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Model model)
        {
            _context.Modele.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Model>> GetAll()
        {
            var modele = await(await GetQuery()).Include(x=>x.Producator).Include(x=>x.ListaMotoare).ToListAsync();
            return modele;
        }

        public async Task<List<Model>> GetAllSimple()
        {
            var modele = await (_context.Modele.AsQueryable().Include(x=>x.Producator)).ToListAsync();
            return modele;
        }

        public async Task<Model> GetById(int id)
        {
            var model = await _context.Modele.FindAsync(id);
            return model;
        }

        public async Task<Producator> getProducator(string nume) {
            return await _context.Producatori.Where(x=>x.Nume == nume).AsQueryable().FirstOrDefaultAsync();
        }

        public async Task<IQueryable<Model>> GetQuery()
        {
            var query = _context.Modele.AsQueryable().Include(x => x.Producator).Include(x => x.ListaMotoare);
            return query;
        }

        public async Task Update(Model model)
        {
            _context.Modele.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
