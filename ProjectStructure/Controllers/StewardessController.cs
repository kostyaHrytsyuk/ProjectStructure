using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Common.DTO;

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
        public IActionResult GetAll()
        {
            return Json(_service.GetAll());
        }

        //GET: api/stewardesses/:id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Json(_service.Get(id));
        }

        //POST: api/stewardesses/
        [HttpPost]
        public IActionResult Create([FromBody] StewardessDto stewardess)
        {
            if (ModelState.IsValid)
            {
                _service.Create(stewardess);
                return Ok(stewardess);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        //PUT: api/stewardesses/:id
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] StewardessDto stewardess)
        {
            if (ModelState.IsValid)
            {
                _service.Update(stewardess);
                return Ok();
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        //DELETE: api/stewardesses/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}