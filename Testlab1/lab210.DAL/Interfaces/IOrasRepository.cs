using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lab210.DAL.Entitati;
using System.Threading.Tasks;

namespace lab210.DAL.Interfaces
{
    public interface IOrasRepository
    {
        Task<List<Oras>> GetAll();
        Task<Oras> GetById(int id);
        Task Create(Oras oras);
        Task Update(Oras oras);
        Task Delete(Oras oras);
        Task<IQueryable<Oras>> GetQuery();
    }
}
