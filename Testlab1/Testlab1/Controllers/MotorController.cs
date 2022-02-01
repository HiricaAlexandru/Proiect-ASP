//using lab210.DAL.Interfaces;
using lab210.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testlab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorController : ControllerBase
    {
        private readonly IMotorManager _motorManager;

        public MotorController(IMotorManager motorManager)
        {
            _motorManager = motorManager;
        }

        [HttpGet("get-all-engines")]
        public async Task<IActionResult> getEnginesList()
        {
            var lista_motoare = await _motorManager.GetAllEnginesList();
            return Ok(lista_motoare);
        }

        [HttpPut("update-engine")]
        [Authorize("Admin")] //pt autorizare
        public async Task<IActionResult> updateEngine([FromQuery] int id, [FromQuery] int newPutere, [FromQuery] decimal newPret)
        {
            var result = await _motorManager.UpdateEngineById(id, newPutere, newPret);

            if (result == false)
            {
                return BadRequest("A aparut o eroare la update: una din valori nu este buna!");
            }

            return Ok("Updatat!");
        }

        [HttpPost("insert-engine")]
        [Authorize("Admin")]
        public async Task<IActionResult> insertNewEngine([FromQuery] string nume, [FromQuery] int putere, [FromQuery] decimal pret)
        {
            var result = await _motorManager.AddNewEngine(nume, putere, pret);

            if (result == false)
            {
                return BadRequest("A aparut o eroare la inserare!");
            }

            return Ok("Inserat!");
        }

        [HttpDelete("delete-engine/{nume}")]
        [Authorize("Admin")]
        public async Task<IActionResult> deleteEngine([FromRoute] string nume)
        {
            var result = await _motorManager.DeleteEngine(nume);
            if (result == false)
            {
                return BadRequest("A aparut o eroare!");
            }

            return Ok("Succes!");
        }
    }
       
}
