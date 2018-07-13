using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Common.DTO;

namespace ProjectStructure.Controllers
{
    [Produces("application/json")]
    [Route("api/departures")]
    public class DepartureController : Controller
    {
        IDepartureService _service;

        public DepartureController(IDepartureService service)
        {
            _service = service;
        }

        //GET: api/departures/
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(_service.GetAll());
        }

        //GET: api/departures/:id
        [HttpGet("{id})")]
        public IActionResult GetById(int id)
        {
            return Json(_service.Get(id));
        }

        //POST: api/departures/
        [HttpPost]
        public IActionResult Create([FromBody] DepartureDto departure)
        {
            _service.Create(departure);
            return Ok();
        }

        //PUT: api/departures/:id
        [HttpPut("{id})")]
        public IActionResult Update([FromBody] DepartureDto departure)
        {
            _service.Update(departure);
            return Ok();
        }

        //DELETE: api/departures/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}