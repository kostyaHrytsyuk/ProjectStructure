using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Common.DTO;
using System.Threading.Tasks;

namespace ProjectStructure.Controllers
{
    [Produces("application/json")]
    [Route("api/pilots")]
    public class PilotController : Controller
    {
        private IPilotService _service;

        public PilotController(IPilotService service)
        {
            _service = service;
        }

        //GET: api/pilots/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(await _service.GetAll());
        }

        //GET: api/pilots/:id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Json(await _service.Get(id));
        }

        //POST: api/pilots/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PilotDto pilot)
        {
            await _service.Create(pilot);
            return Ok();
        }

        //PUT: api/pilots/:id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] PilotDto pilot)
        {
            await _service.Update(pilot);
            return Ok();
        }

        //DELETE: api/pilots/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}