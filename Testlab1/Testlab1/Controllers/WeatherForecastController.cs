using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testlab1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private List<string> Summaries = new List<string>
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        

        [HttpGet("GetSummary")]
        public ActionResult<List<string>> GetSummary()
        {
            return Ok(Summaries);
        }


        [HttpGet("GetType/{type}")]
        public async Task<IActionResult> GetType([FromRoute] string type)
        {
            try
            {
                int.Parse(type);
                var weatherGood = "good";
                if (weatherGood == type)
                {
                    return Ok(true);
                }

                return Ok(false);
            } catch (Exception Ex) 
            {
                return BadRequest("Endpoint failed");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string type)
        {   
           
            var list = new List<string> { "safa","asfda"};
            list.Add(type);

            return Ok(list);

        }

        [HttpPut]
        public async Task<IActionResult> Update()
        {
            Summaries = new List<string> { "Warm", "Pula" };
            return Ok(Summaries);
        }

        [HttpDelete("Delete/{type}")]
        public async Task<IActionResult> Delete([FromRoute] string type)
        {
            Summaries.Remove(type);
            return Ok(Summaries);
        }

    }
}
