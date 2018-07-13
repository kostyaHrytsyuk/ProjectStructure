using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Common.DTO;

namespace ProjectStructure.Controllers
{
    [Produces("application/json")]
    [Route("api/tickets")]
    public class TicketController : Controller
    {
        private ITicketService _service;

        public TicketController(ITicketService service)
        {
            _service = service;
        }

        //GET: api/tickets/
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(_service.GetAll());
        }

        //GET: api/tickets/:id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Json(_service.Get(id));
        }

        //POST: api/tickets/
        [HttpPost]
        public IActionResult Create([FromBody] TicketDto ticket)
        {
            _service.Create(ticket);
            return Ok();
        }

        //PUT: api/tickets/:id
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] TicketDto ticket)
        {
            _service.Update(ticket);
            return Ok();
        }

        //DELETE: api/tickets/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}