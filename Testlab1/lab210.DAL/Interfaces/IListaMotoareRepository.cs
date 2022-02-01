using System;
using lab210.DAL.Entitati;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace lab210.DAL.Interfaces
{
    public interface IListaMotoareRepository
    {
        Task<List<ListaMotoare>> GetAll();
        Task<ListaMotoare> GetById(int id);
        Task Create(ListaMotoare listaMotoare);
        Task Update(ListaMotoare listaMotoare);
        Task Delete(ListaMotoare listaMotoare);
        Task<IQueryable<ListaMotoare>> GetQuery();
    }
}
