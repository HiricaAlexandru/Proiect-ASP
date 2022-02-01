using lab210.BLL.Interfaces;
using lab210.DAL.Entitati;
using lab210.DAL.Interfaces;
using lab210.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab210.BLL.Manager
{
    public class ListaMotoareManager : IListaMotoareManager
    {
        private readonly IListaMotoareRepository _listaMotoareRep;

        public ListaMotoareManager(IListaMotoareRepository listaMotoareRep)
        {
            _listaMotoareRep = listaMotoareRep;
        }

        public async Task<bool> addEngineModelConfiguration(int idModel, int idMotor)
        {
            ListaMotoare ls = new ListaMotoare();
            ls.ModelId = idModel;
            ls.MotorId = idMotor;

            await _listaMotoareRep.Create(ls);
            return true;


        }

        public async Task<bool> deleteEngineConfiguration(int id)
        {
            var configurari = await _listaMotoareRep.GetQuery();
            var lista_selectata = await configurari.Where(x => x.Id == id).FirstOrDefaultAsync();

            if(lista_selectata == null)
            {
                return false;

            }

            await _listaMotoareRep.Delete(lista_selectata);
            return true;

        }

        public async Task<List<ListaMotoare>> getListaMotoarePentruModel(int idModel)
        {
            var lista_motoare = await _listaMotoareRep.GetQuery();
            var lista_selectata = await lista_motoare.Include(x => x.Model).Include(x => x.Motor).Where(x => x.ModelId == idModel).ToListAsync();
            return lista_selectata;



        }
    }
}
