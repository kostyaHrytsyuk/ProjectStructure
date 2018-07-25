using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Common.DTO;
using System.Threading.Tasks;

namespace ProjectStructure.Controllers
{
    [Produces("application/json")]
    [Route("api/planes")]
    public class PlaneController : Controller
    {
        IPlaneService _service;

        public PlaneController(IPlaneService service)
        {
            _service = service;
        }

        //GET: api/planes/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(await _service.GetAll());
        }

        //GET: api/planes/:id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Json(await _service.Get(id));
        }

        //POST: api/planes/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PlaneDto plane)
        {
            if (ModelState.IsValid)
            {
                await _service.Create(plane);
                return Ok();
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        //PUT: api/plane/:id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] PlaneDto plane)
        {
            if (ModelState.IsValid)
            {
                await _service.Update(plane);
                return Ok();
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        //DELETE: api/plane/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}