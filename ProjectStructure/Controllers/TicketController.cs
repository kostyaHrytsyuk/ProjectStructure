using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Common.DTO;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAll()
        {
            return Json(await _service.GetAll());
        }

        //GET: api/tickets/:id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Json(await _service.Get(id));
        }

        //POST: api/tickets/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TicketDto ticket)
        {
            if (ModelState.IsValid)
            {
                await _service.Create(ticket);
                return Ok(ticket);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        //PUT: api/tickets/:id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] TicketDto ticket)
        {
            if (ModelState.IsValid)
            {
                await _service.Update(ticket);
                return Ok(ticket);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        //DELETE: api/tickets/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}