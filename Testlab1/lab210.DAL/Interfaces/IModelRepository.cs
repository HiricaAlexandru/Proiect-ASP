using lab210.DAL.Entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab210.DAL.Interfaces
{
    public interface IModelRepository
    {
        Task<List<Model>> GetAll();
        Task<Model> GetById(int id);
        Task Create(Model model);

        Task<List<Model>> GetAllSimple();
        Task<Producator> getProducator(string nume);
        Task Update(Model model);
        Task Delete(Model model);
        Task<IQueryable<Model>> GetQuery();
    }
}
