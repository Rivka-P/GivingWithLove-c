using Bl.BLApi;
using Bl.BLModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IBl bl;
        public ProjectController(IBl bl)
        {
            this.bl = bl;
        }

        // GET: api/<ProjectController>
        [HttpGet]
        public async Task<List<BlProjectModel>> GetAll()
        {
            return await bl.Project.ReadAllAsync();
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public async Task<BlProjectModel> Get(int id)
        {
            return await bl.Project.ReadAsync(id);
        }

        // POST api/<ProjectController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BlProjectModel s)
        {
            try
            {
                await bl.Project.CreateAsync(s);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BlProjectModel s)
        {
            try
            {
                await bl.Project.UpdateAsync(s);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var project = await bl.Project.ReadAsync(id);
                if (project == null)
                    return NotFound();

                await bl.Project.DeleteAsync(project);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}