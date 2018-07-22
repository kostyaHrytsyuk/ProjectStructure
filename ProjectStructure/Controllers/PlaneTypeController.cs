﻿using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Common.DTO;

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
        public IActionResult GetAll()
        {
            return Json(_service.GetAll());
        }

        //GET: api/planeTypes/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json(_service.Get(id));
        }

        //POST: api/planeTypes/:id
        [HttpPost]
        public IActionResult Create([FromBody] PlaneTypeDto planeType)
        {
            if (ModelState.IsValid)
            {
                _service.Create(planeType);
                return Ok(planeType);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);   
            }
        }

        //PUT: api/planeTypes/
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] PlaneTypeDto planeType)
        {
            if(ModelState.IsValid)
            { 
                _service.Update(planeType);
                return Ok(planeType);
            }
            else
            {
                return new BadRequestObjectResult(ModelState);
            }
        }

        //DELETE: api/planeTypes/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}