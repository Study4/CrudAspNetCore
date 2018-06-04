using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudAspNetCore.Api.Infrastructures;
using CrudAspNetCore.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudAspNetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly SkyHRContext _db;

        public EmployeesController(SkyHRContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Employees);
        }

        [HttpGet("{id}", Name = "GetEmployee")]
        public async Task<IActionResult> Get(int id)
        {
            var obj = await _db.Employees.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            return Ok(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Employees.Add(dto);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetEmployee", new { id = dto.Id }, dto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Employee dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dto.Id)
            {
                return BadRequest();
            }

            var entity = await _db.Employees.FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            _db.Entry(entity).CurrentValues.SetValues(dto);
            await _db.SaveChangesAsync();

            return StatusCode(204);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _db.Employees.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _db.Employees.Remove(entity);
            await _db.SaveChangesAsync();

            return Ok(entity);
        }
    }
}