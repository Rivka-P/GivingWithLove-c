using Bl.BLApi;
using Bl.BLModels;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VolunteerDomainController : ControllerBase
    {
        private readonly IBl bl;
        public VolunteerDomainController(IBl bl)
        {
            this.bl = bl;
        }

        // GET: api/VolunteerDomain/Get
        [HttpGet]
        public async Task<List<BlVolunteerDomainModel>> GetAll()
        {
            return await bl.VolunteerDomains.ReadAllAsync();
        }

        // GET api/VolunteerDomain/Get/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlVolunteerDomainModel>> Get(int id)
        {
            var result = await bl.VolunteerDomains.ReadAsync(id);
            if (result == null)
                return NotFound();
            return result;
        }

        // POST api/VolunteerDomain/Post
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BlVolunteerDomainModel v)
        {
            await bl.VolunteerDomains.CreateAsync(v);
            return CreatedAtAction(nameof(Get), new { id = v.VolunteerDomainsCode }, v);
        }

        // PUT api/VolunteerDomain/Put/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BlVolunteerDomainModel v)
        {
            if (id != v.VolunteerDomainsCode)
                return BadRequest();

            await bl.VolunteerDomains.UpdateAsync(v);
            return NoContent();
        }

        // DELETE api/VolunteerDomain/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var volunteerDomain = await bl.VolunteerDomains.ReadAsync(id);
            if (volunteerDomain == null)
                return NotFound();

            await bl.VolunteerDomains.DeleteAsync(volunteerDomain);
            return NoContent();
        }
    }
}