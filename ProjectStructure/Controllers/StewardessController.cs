using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Common.DTO;
using System.Threading.Tasks;

namespace ProjectStructure.Controllers
{
    [Produces("application/json")]
    [Route("api/stewardesses")]
    public class StewardessController : Controller
    {
        IStewardessService _service;

        public StewardessController(IStewardessService service)
        {
            _service = service;
        }

        //GET: api/stewardesses/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(await _service.GetAll());
        }

        //GET: api/stewardesses/:id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Json(await _service.Get(id));
        }

        //POST: api/stewardesses/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StewardessDto stewardess)
        {
            if (ModelState.IsValid)
            {
                stewardess = await _service.Create(stewardess);
                return Ok(stewardess);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        //PUT: api/stewardesses/:id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] StewardessDto stewardess)
        {
            if (ModelState.IsValid)
            {
                stewardess = await _service.Update(stewardess);
                return Ok(stewardess);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        //DELETE: api/stewardesses/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}