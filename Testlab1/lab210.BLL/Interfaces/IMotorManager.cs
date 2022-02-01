using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab210.BLL.Interfaces
{
    public interface IMotorManager
    {
        Task<List<String>> GetAllEnginesList();
        Task<Boolean> UpdateEngineById(int id, int newPutere, decimal newPret);
        Task<Boolean> AddNewEngine(string nume, int putere, decimal pret);
        Task<Boolean> DeleteEngine(string Nume);
    }
}
