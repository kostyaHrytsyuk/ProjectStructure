using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Common.DTO;

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
        public IActionResult GetAll()
        {
            return Json(_service.GetAll());
        }

        //GET: api/crews/:id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Json(_service.Get(id));
        }

        //POST: api/crews/
        [HttpPost]
        public IActionResult Create([FromBody] CrewDto crew)
        {
            _service.Create(crew);
            return Ok();
        }

        //PUT: api/crews/:id
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CrewDto crew)
        {
            _service.Update(crew);
            return Ok();
        }

        //DELETE: api/crews/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}