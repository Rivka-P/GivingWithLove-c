using Bl.BLApi;
using Bl.BLModels;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VolunteerDomainController : ControllerBase
    {
        IBl bl;
        public VolunteerDomainController(IBl bl)
        {
            this.bl = bl;
        }
        // GET: api/<VolunteeringController>
        [HttpGet]
        public Task<List<BlVolunteerDomainModel>> Get()
        {
            return bl.VolunteerDomains.ReadAll();
        }

        // GET api/<VolunteeringController>/5
        [HttpGet("{id}")]
        public Task<BlVolunteerDomainModel> Get(int id)
        {
            return bl.VolunteerDomains.Read(id);
        }

        // POST api/<VolunteeringController>
        [HttpPost]
        public void Post([FromBody] BlVolunteerDomainModel v)
        {
            bl.VolunteerDomains.Create(v);
        }

        // PUT api/<VolunteeringController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BlVolunteerDomainModel v)
        {
            bl.VolunteerDomains.Update(v);

        }

        // DELETE api/<VolunteeringController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bl.VolunteerDomains.Delete(Get(id).Result);
        }
    }
}
