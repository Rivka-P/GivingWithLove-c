using Bl.BLApi;
using Bl.BLModels;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        private readonly IBl _bl;

        public VolunteerController(IBl bl)
        {
            _bl = bl;
        }

        // GET: api/Volunteer
        [HttpGet]
        public async Task<ActionResult<List<BLVolunteerModel>>> GetAll()
        {
            var volunteers = await _bl.Volunteer.ReadAllAsync();
            return Ok(volunteers);
        }

        // GET api/Volunteer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLVolunteerModel>> Get(int id)
        {
            var volunteer = await _bl.Volunteer.ReadAsync(id);
            if (volunteer == null)
                return NotFound();

            return volunteer; // ActionResult wrapping the model
        }

        // POST api/Volunteer
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BLVolunteerModel v)
        {
            try
            {
                await _bl.Volunteer.CreateAsync(v);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/Volunteer/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BLVolunteerModel v)
        {
            try
            {
                await _bl.Volunteer.UpdateAsync(v);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/Volunteer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                BLVolunteerModel volunteer = (await Get(id)).Value;
                _bl.Volunteer.DeleteAsync(volunteer);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}