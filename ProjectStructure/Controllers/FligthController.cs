using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Common.DTO;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAll()
        {
            return Json(await _service.GetAll());
        }

        //GET: api/flights/:id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Json(await _service.Get(id));
        }

        //POST: api/flights/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FlightDto flight)
        {
            if (ModelState.IsValid)
            {
                await _service.Create(flight);
                return Ok(flight);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        //PUT: api/flights/:id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] FlightDto flight)
        {
            if (ModelState.IsValid)
            {
                await _service.Update(flight);
                return Ok(flight);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        //DELETE: api/flights/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}