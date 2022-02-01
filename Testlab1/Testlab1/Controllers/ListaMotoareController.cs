using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab210.BLL.Interfaces;
using lab210.DAL.Entitati;
using Microsoft.AspNetCore.Authorization;

namespace Testlab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaMotoareController : ControllerBase
    {
        private readonly IListaMotoareManager _listaMotoareManager;
        public ListaMotoareController(IListaMotoareManager listaMotoareManager)
        {
            _listaMotoareManager = listaMotoareManager;
        }

        [HttpDelete("delete-lista-motoare")]
        [Authorize("Admin")]
        public async Task<IActionResult> deleteEngineConfig([FromQuery] int id)
        {
            var rezultat = await _listaMotoareManager.deleteEngineConfiguration(id);
            if(rezultat == false)
            {
                return BadRequest("Eroare!");
            }

            return Ok("A fost sters!");
        }

        [HttpGet("get-lista-motoare")]

        public async Task<IActionResult> getListaMotoare([FromQuery] int idModel)
        {
            var rezultat = await _listaMotoareManager.getListaMotoarePentruModel(idModel);
            return Ok(rezultat);
        }

        [HttpPut("insert-engine")]
        [Authorize("Admin")]
        public async Task<IActionResult> insertEngine([FromQuery] int idModel, [FromQuery] int idMotor)
        {
            var rezultat = await _listaMotoareManager.addEngineModelConfiguration(idModel, idMotor);
            if(rezultat == false)
            {
                return BadRequest("Eroare");
            }

            return Ok("A fost inserat");
        }
    }
}
