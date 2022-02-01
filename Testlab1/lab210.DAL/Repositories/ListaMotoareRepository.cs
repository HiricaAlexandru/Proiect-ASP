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
    public class ListaMotoareRepository : IListaMotoareRepository
    {
        private readonly AppDbContext _context;

        public ListaMotoareRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(ListaMotoare listaMotoare)
        {
            await _context.ListaMotoare.AddAsync(listaMotoare);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ListaMotoare listaMotoare)
        {
            _context.ListaMotoare.Remove(listaMotoare);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ListaMotoare>> GetAll()
        {
            var listaMotoare = await(await GetQuery()).ToListAsync();
            return listaMotoare;
        }

        public async Task<ListaMotoare> GetById(int id)
        {
            var listaMotoare = await _context.ListaMotoare.FindAsync(id);
            return listaMotoare;
        }

        public async Task<IQueryable<ListaMotoare>> GetQuery()
        {
            var query = _context.ListaMotoare.AsQueryable().Include(x=>x.Motor).Include(x=>x.Model);
            return query;
        }

        public async Task Update(ListaMotoare listaMotoare)
        {
            _context.ListaMotoare.Update(listaMotoare);
            await _context.SaveChangesAsync();
        }
    }
}
