using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab210.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Testlab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelManager _modelManager;

        public ModelController(IModelManager modelManager)
        {
            _modelManager = modelManager;
        }

        [HttpPost("insert-model")]
        [Authorize("Admin")]
        public async Task<IActionResult> insertNewModelController([FromQuery] string nume, [FromQuery] string numeProducator, [FromQuery] DateTime anFabricatie, [FromQuery] decimal Pret) =>
            Ok(await _modelManager.insertNewModel(numeProducator, nume, anFabricatie, Pret));
        

        [HttpGet("get-all-models-text")]
        public async Task<IActionResult> getAllModels()
        {
            var lista = await _modelManager.getAllCarsList();
            return Ok(lista);
        }

        //automapper!

        [HttpDelete("delete-Model")]
        [Authorize("Admin")]
        public async Task<IActionResult> deleteModel([FromQuery] string numeModel, [FromQuery] string numeProducator)
        {
            var rezultat = await _modelManager.deleteModel(numeModel, numeProducator);
            if(rezultat == false)
            {
                return BadRequest("A aparut o eroare");
            }

            return Ok("S-a sters modelul mentionat");

        }
        

        [HttpPut("update-model")]
        [Authorize("Admin")]
        public async Task<IActionResult> updateModel([FromQuery] int id, [FromQuery] decimal pret)
        {
            var rezultat = await _modelManager.updatePret(id, pret);
            if(rezultat == false)
            {
                return BadRequest("A aparut o eroare");
            }
            return Ok("S-a updatat modelul mentionat");
        }
    }
}
