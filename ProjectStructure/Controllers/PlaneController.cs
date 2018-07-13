using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Common.DTO;


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
        public IActionResult GetAll()
        {
            return Json(_service.GetAll());
        }

        //GET: api/planes/:id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Json(_service.Get(id));
        }

        //POST: api/planes/
        [HttpPost]
        public IActionResult Create([FromBody] PlaneDto plane)
        {
            _service.Create(plane);
            return Ok();
        }

        //PUT: api/plane/:id
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] PlaneDto plane)
        {
            _service.Update(plane);
            return Ok();
        }

        //DELETE: api/plane/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}