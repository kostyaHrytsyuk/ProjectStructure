using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Common.DTO;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAll()
        {
            return Json(await _service.GetAll());
        }

        //GET: api/departures/:id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Json(await _service.Get(id));
        }

        //POST: api/departures/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartureDto departure)
        {
            if (ModelState.IsValid)
            {
                departure = await _service.Create(departure);
                return Ok(departure);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        //PUT: api/departures/:id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] DepartureDto departure)
        {
            if (ModelState.IsValid)
            {
                departure = await _service.Update(departure);
                return Ok(departure);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        //DELETE: api/departures/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}