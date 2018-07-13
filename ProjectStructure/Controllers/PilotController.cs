using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Common.DTO;

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
        public IActionResult GetAll()
        {
            return Json(_service.GetAll());
        }

        //GET: api/pilots/:id
        [HttpGet("{id})")]
        public IActionResult GetById(int id)
        {
            return Json(_service.Get(id));
        }

        //POST: api/pilots/
        [HttpPost]
        public IActionResult Create([FromBody] PilotDto pilot)
        {
            _service.Create(pilot);
            return Ok();
        }

        //PUT: api/pilots/:id
        [HttpPut("{id})")]
        public IActionResult Update([FromBody] PilotDto pilot)
        {
            _service.Update(pilot);
            return Ok();
        }

        //DELETE: api/pilots/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}