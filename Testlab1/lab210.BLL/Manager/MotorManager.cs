using lab210.BLL.Interfaces;
using lab210.DAL.Entitati;
using lab210.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab210.BLL.Manager
{
    public class MotorManager : IMotorManager
    {
        private readonly IMotorRepository _motorRepository;

        public MotorManager(IMotorRepository motorRepository)
        {
            _motorRepository = motorRepository;
        }

        public async Task<Boolean> AddNewEngine(string nume, int putere, decimal pret)
        {
            var motorNou = new Motor();
            if(putere == 0 || pret <= 0 || string.IsNullOrEmpty(nume))
            {
                return false;
            }

            
            motorNou.Nume = nume;
            motorNou.Pret = pret;
            motorNou.Putere = putere;

            await _motorRepository.Create(motorNou);

            return true;
           
        }

        public async Task<Boolean> DeleteEngine(string nume)
        {
            var motoare = await _motorRepository.GetQuery();
            var motor = await motoare.Where(x => x.Nume == nume).FirstOrDefaultAsync();
            if(motor == null)
            {
                return false;
            }
            await _motorRepository.Delete(motor); //sterge motoul din db

            return true;
        }

        public async Task<List<string>> GetAllEnginesList()
        {
            var motoare = await _motorRepository.GetAll();
            List<string> listaMotoare = new List<string>();

            foreach (var motor in motoare)
            {
                listaMotoare.Add($"Motorul: {motor.Nume} are puterea de: {motor.Putere} si pretul de: {motor.Pret}");
            }

            return listaMotoare;
        }

        public async Task<Boolean> UpdateEngineById(int id, int newPutere, decimal newPret)
        {

            if(newPutere == 0 || newPret == 0)
            {
                return false;
            }

            var motor = new Motor();
            motor.Id = id;
            motor.Pret = newPret;
            motor.Putere = newPutere;

            var query_motoare = await _motorRepository.GetQuery();
            var motor_selectat = await query_motoare.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();

            if(motor_selectat == null)
            {
                return false;
            }

            var nume = motor_selectat.Nume;

            motor.Nume = nume;

            await _motorRepository.Update(motor);
            return true;





        }
    }
}
