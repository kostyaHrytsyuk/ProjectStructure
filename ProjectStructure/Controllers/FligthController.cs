using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Common.DTO;

namespace ProjectStructure.Controllers
{
    [Produces("application/json")]
    [Route("api/Flights")]
    public class FlightController : Controller
    {
        private IFlightService _service;

        public FlightController(IFlightService service)
        {
            _service = service;
        }

        //GET: api/flights/
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(_service.GetAll());
        }

        //GET: api/flights/:id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Json(_service.Get(id));
        }

        //POST: api/flights/
        [HttpPost]
        public IActionResult Create([FromBody] FlightDto flight)
        {
            if (ModelState.IsValid)
            {
                _service.Create(flight);
                return Ok(flight);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        //PUT: api/flights/:id
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] FlightDto flight)
        {
            if (ModelState.IsValid)
            {
                _service.Update(flight);
                return Ok(flight);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        //DELETE: api/flights/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}