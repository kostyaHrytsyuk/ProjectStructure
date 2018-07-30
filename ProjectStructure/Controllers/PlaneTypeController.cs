using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Common.DTO;
using System.Threading.Tasks;

namespace ProjectStructure.Controllers
{
    [Produces("application/json")]
    [Route("api/planeTypes/")]
    public class PlaneTypeController : Controller
    {
        private IPlaneTypeService _service;

        public PlaneTypeController(IPlaneTypeService service)
        {
            _service = service;
        }

        //GET: api/planeTypes/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(await _service.GetAll());
        }

        //GET: api/planeTypes/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Json(await _service.Get(id));
        }

        //POST: api/planeTypes/:id
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PlaneTypeDto planeType)
        {
            if (ModelState.IsValid)
            {
                planeType = await _service.Create(planeType);
                return Ok(planeType);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);   
            }
        }

        //PUT: api/planeTypes/
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] PlaneTypeDto planeType)
        {
            if(ModelState.IsValid)
            {
                planeType = await _service.Update(planeType);
                return Ok(planeType);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        //DELETE: api/planeTypes/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}