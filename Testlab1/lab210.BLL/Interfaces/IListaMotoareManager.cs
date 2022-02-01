using lab210.DAL.Entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab210.BLL.Interfaces
{
    public interface IListaMotoareManager
    {
        Task<List<ListaMotoare>> getListaMotoarePentruModel(int idModel);
        Task<Boolean> addEngineModelConfiguration(int idModel, int idMotor);
        Task<Boolean> deleteEngineConfiguration(int id);
        

    }
}
