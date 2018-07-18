using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Common.DTO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectStructure.Controllers
{
    [Produces("application/json")]
    [Route("api/crews/[action]")]
    public class CrewController : Controller
    {
        private ICrewService _service;

        public CrewController(ICrewService service)
        {
            _service = service;
        }

        //GET: api/crews/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(await _service.GetAll());
        }

        [HttpGet]
        
        public async Task<IActionResult> GetFirstTen()
        {
            await DownloadApiCrewsByUrl("http://5b128555d50a5c0014ef1204.mockapi.io/crew");

            return Json(string.Empty);
        }

        //GET: api/crews/:id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Json(await _service.Get(id));
        }

        //POST: api/crews/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrewDto crew)
        {
            await _service.Create(crew);
            return Ok();
        }

        //PUT: api/crews/:id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CrewDto crew)
        {
            await _service.Update(crew);
            return Ok();
        }

        //DELETE: api/crews/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }

        private static async Task<List<CrewOutDto>> DownloadApiCrewsByUrl(string url)
        {
            var crews = new List<CrewOutDto>();

            using (var c = new HttpClient())
            {
                
                try
                {
                    var stringData = await c.GetStringAsync(url);
                    crews = JsonConvert.DeserializeObject<List<CrewOutDto>>(stringData);

                }
                catch (System.Exception)
                {

                    throw;
                }
            }
            return crews;

        }
    }
}