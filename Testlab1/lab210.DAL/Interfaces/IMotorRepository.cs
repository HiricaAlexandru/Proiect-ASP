using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab210.DAL.Entitati;

namespace lab210.DAL.Interfaces
{
    public interface IMotorRepository
    { 
        Task<List<Motor>> GetAll();
        Task<Motor> GetById(int id);
        Task Create(Motor motor);
        Task Update(Motor motor);
        Task Delete(Motor motor);
        Task<IQueryable<Motor>> GetQuery();
    }
}
