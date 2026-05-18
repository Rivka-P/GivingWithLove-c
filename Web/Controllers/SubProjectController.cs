using Bl.BLApi;
using Bl.BLModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubProjectController : ControllerBase
    {
        private readonly IBl bl;
        public SubProjectController(IBl bl)
        {
            this.bl = bl;
        }

        // GET: api/SubProject
        [HttpGet]
        public async Task<ActionResult<List<BlSubProjectModel>>> GetAll()
        {
            var list = await bl.SubProject.ReadAllAsync();
            return Ok(list);
        }

        // GET api/SubProject/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlSubProjectModel>> Get(int id)
        {
            var sp = await bl.SubProject.ReadAsync(id);
            if (sp == null)
                return NotFound();
            return Ok(sp);
        }

        // POST api/SubProject
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BlSubProjectModel s)
        {
            if (s == null)
                return BadRequest();

            await Task.Run(() => bl.SubProject.CreateAsync(s));
            return CreatedAtAction(nameof(Get), new { id = s.SubProjectCode }, s);
        }

        // PUT api/SubProject/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BlSubProjectModel s)
        {
            if (s == null || id != s.SubProjectCode)
                return BadRequest();

            await Task.Run(() => bl.SubProject.UpdateAsync(s));
            return NoContent();
        }

        // DELETE api/SubProject/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var sp = await bl.SubProject.ReadAsync(id);
            if (sp == null)
                return NotFound();

            await Task.Run(() => bl.SubProject.DeleteAsync(sp));
            return NoContent();
        }
    }
}