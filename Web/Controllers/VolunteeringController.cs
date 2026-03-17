using Bl.BLApi;
using Bl.BLModels;
using Dal.Api;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteeringController : ControllerBase
    {
        IBl bl;
        public VolunteeringController(IBl bl)
        {
            this.bl = bl;
        }
        // GET: api/<VolunteeringController>
        [HttpGet]
        public Task<List<BlVolunteeringModel >> Get()
        {
            return bl.Volunteerings.ReadAll();
        }

        // GET api/<VolunteeringController>/5
        [HttpGet("{id}")]
        public Task<BlVolunteeringModel> Get(int id)
        {
            return bl.Volunteerings.Read(id);
        }

        // POST api/<VolunteeringController>
        [HttpPost]
        public void Post([FromBody] BlVolunteeringModel v)
        {
            bl.Volunteerings.Create(v);
        }

        // PUT api/<VolunteeringController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BlVolunteeringModel v)
        {
            bl.Volunteerings.Update(v);

        }

        // DELETE api/<VolunteeringController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bl.Volunteerings.Delete(Get(id).Result);
        }
    }
}
