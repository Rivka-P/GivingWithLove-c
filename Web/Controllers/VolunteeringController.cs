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
    public class VolunteeringController : ControllerBase
    {
        private readonly IBl _bl;

        public VolunteeringController(IBl bl)
        {
            _bl = bl;
        }

        // GET: api/Volunteering
        [HttpGet]
        public async Task<ActionResult<List<BlVolunteeringModel>>> GetAll()
        {
            var volunteers = await _bl.Volunteerings.ReadAllAsync();
            if (volunteers == null || volunteers.Count == 0)
                return NotFound("No volunteering records found.");

            return Ok(volunteers);
        }

        // GET: api/Volunteering/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlVolunteeringModel>> Get(int id)
        {
            try
            {
                var volunteer = await _bl.Volunteerings.ReadAsync(id);
                if (volunteer == null)
                    return NotFound($"Volunteering record with ID {id} not found.");

                return Ok(volunteer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Volunteering
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BlVolunteeringModel v)
        {
            try
            {
                await _bl.Volunteerings.CreateAsync(v);
                return CreatedAtAction(nameof(Get), new { id = v.VolunteeringCode }, v);
            }
            catch (Exception ex)
            {
                return BadRequest($"Could not create volunteering record: {ex.Message}");
            }
        }

        // PUT: api/Volunteering/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BlVolunteeringModel v)
        {
            try
            {
                await _bl.Volunteerings.UpdateAsync(v);
                return NoContent(); // 204
            }
            catch (Exception ex)
            {
                return BadRequest($"Could not update volunteering record: {ex.Message}");
            }
        }

        // DELETE: api/Volunteering/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var volunteer = await _bl.Volunteerings.ReadAsync(id);
                if (volunteer == null)
                    return NotFound($"Volunteering record with ID {id} not found.");

                await _bl.Volunteerings.DeleteAsync(volunteer);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Could not delete volunteering record: {ex.Message}");
            }
        }
    }
}