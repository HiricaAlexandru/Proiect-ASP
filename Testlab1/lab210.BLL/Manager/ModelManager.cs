using lab210.BLL.Interfaces;
using lab210.DAL.Interfaces;
using lab210.DAL.Entitati;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab210.DAL.Repositories;

namespace lab210.BLL.Manager
{
    public class ModelManager : IModelManager
    {
        private readonly IModelRepository _modelRepository;

        public ModelManager(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }
        public async Task<Boolean> deleteModel(string Nume, string numeProducator)
        {
            var modele = await _modelRepository.GetQuery();
            var model_selectat = await modele.Where(x => x.Nume == Nume && x.Producator.Nume == numeProducator).FirstOrDefaultAsync();
            
            if(model_selectat == null)
            {
                return false;
            }

            await _modelRepository.Delete(model_selectat);

            return true;

        }

        public async Task<Boolean> insertNewModel(string producator_nume, string nume, DateTime anFabricatie, decimal Pret)
        {
            if (string.IsNullOrEmpty(nume) || string.IsNullOrEmpty(producator_nume))
                return false;

            var model = new Model();
            model.Nume = nume;
            model.AnFabricatie = anFabricatie;
            model.Pret = Pret;

            var producator = await _modelRepository.getProducator(producator_nume);
            model.Producator = producator;
            await _modelRepository.Create(model);

            return true;
        }

        public async Task<List<Model>> getAllCarsList()
        {
            var cars = await _modelRepository.GetAllSimple();
            return cars;
        }

        public async Task<Boolean> updatePret(int id, decimal pret)
        {
            var modeleQuery = await _modelRepository.GetQuery();
            var modelSelectat = await modeleQuery.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();

            

            if(modelSelectat == null)
            {
                return false;
            }

            modelSelectat.Pret = pret;

            await _modelRepository.Update(modelSelectat);
            return true;

        }
    }
}
