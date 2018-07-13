using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        [Route("api/tickets/")]
        public IActionResult GetAllTickets()
        {
            return Json(_service.GetAll());
        }

        //GET: api/tickets/:id
        [HttpGet("{id})")]
        public IActionResult GetTicketById(int id)
        {
            return Json(_service.Get(id));
        }

        [HttpPost]
        [Route("api/tickets/")]
        public IActionResult Create([FromBody] TicketDto ticket)
        {
            _service.Create(ticket);
            return Ok();
        }

        [HttpPut("{id})")]
        public IActionResult Update([FromBody] TicketDto ticket)
        {
            _service.Update(ticket);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}