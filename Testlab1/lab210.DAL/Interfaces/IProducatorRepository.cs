using lab210.DAL.Entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab210.DAL.Interfaces
{
    public interface IProducatorRepository
    {
        Task<List<Producator>> GetAll();
        Task<Producator> GetById(int id);
        Task Create(Producator producator);
        Task Update(Producator producator);
        Task Delete(Producator producator);
        Task<IQueryable<Producator>> GetQuery();
    }
}
