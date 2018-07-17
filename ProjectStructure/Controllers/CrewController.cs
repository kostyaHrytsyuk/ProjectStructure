using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Common.DTO;
using System.Threading.Tasks;

namespace ProjectStructure.Controllers
{
    [Produces("application/json")]
    [Route("api/crews")]
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
    }
}