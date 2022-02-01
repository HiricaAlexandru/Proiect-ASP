using lab210.DAL.Entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab210.BLL.Interfaces
{
    public interface IModelManager
    {
        Task<Boolean> updatePret(int id, decimal pret);
        Task<Boolean> insertNewModel(string producator_nume, string nume, DateTime anFabricatie, decimal Pret);
        Task<Boolean> deleteModel(string Nume, string numeProducator);

        Task<List<Model>> getAllCarsList();
    }
}
