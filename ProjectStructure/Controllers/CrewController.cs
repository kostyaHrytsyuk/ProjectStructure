using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Common.DTO;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectStructure.Controllers
{
    [Produces("application/json")]
    [Route("api/crews")]
    //[Route("api/crews/[action]")]
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

        //[HttpGet]
        //public async Task<IActionResult> GetFirstTen()
        //{
        //    var crews = await DownloadApiCrewsByUrl("http://5b128555d50a5c0014ef1204.mockapi.io/crew");

        //    await _service.CreateSaveOutCrews(crews);

        //    return Json(await _service.GetAll());
        //}

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
            if (ModelState.IsValid)
            {
                crew = await _service.Create(crew);
                return Ok(crew);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        //PUT: api/crews/:id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CrewDto crew)
        {
            if (ModelState.IsValid)
            {
                crew =  await _service.Update(crew);
                return Ok(crew);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        //DELETE: api/crews/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }

        private static async Task<List<CrewDto>> DownloadApiCrewsByUrl(string url)
        {
            var crews = new List<CrewDto>();

            using (var c = new HttpClient())
            {
                
                try
                {
                    var stringData = await c.GetStringAsync(url);
                    if (!string.IsNullOrEmpty(stringData))
                    {
                        crews = JsonConvert.DeserializeObject<List<CrewDto>>(stringData).Take(10).ToList();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return crews;
        }
    }
}