using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Common.DTO;

namespace ProjectStructure.Controllers
{
    [Produces("application/json")]
    [Route("api/fligths")]
    public class FligthController : Controller
    {
        private IFligthService _service;

        public FligthController(IFligthService service)
        {
            _service = service;
        }

        //GET: api/fligths/
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(_service.GetAll());
        }

        //GET: api/fligths/:id
        [HttpGet("{id})")]
        public IActionResult GetById(int id)
        {
            return Json(_service.Get(id));
        }

        //POST: api/fligths/
        [HttpPost]
        public IActionResult Create([FromBody] FligthDto flight)
        {
            _service.Create(flight);
            return Ok();
        }

        //PUT: api/fligths/:id
        [HttpPut("{id})")]
        public IActionResult Update([FromBody] FligthDto flight)
        {
            _service.Update(flight);
            return Ok();
        }

        //DELETE: api/fligths/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}