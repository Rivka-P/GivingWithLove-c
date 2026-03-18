using Bl.BLApi;
using Bl.BLModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EichudController : ControllerBase
    {

        IBl bl;
        public EichudController(IBl bl)
        {
            this.bl = bl;
        }
        
        // GET: api/<EichudController>
        [HttpGet]
        public Task<List<BlEichudModel>> Get()
        {
             return bl.Eichud.ReadAll();
        }

        // GET api/<EichudController>/5
        [HttpGet("{id}")]
        public Task<BlEichudModel> Get(int id)
        {
            return bl.Eichud.Read(id);
        }

        // POST api/<EichudController>
        [HttpPost]
        public void Post([FromBody] BlEichudModel value)
        {
            bl.Eichud.Create(value);
        }

        // PUT api/<EichudController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BlEichudModel value)
        {
            bl.Eichud.Update(value);
        }

        // DELETE api/<EichudController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                BlEichudModel v = bl.Eichud.ReadAll().Result.Find(e=> e.EichudCode == id);
                if (v == null)
                    throw new NullReferenceException("mmm");
                bl.Eichud.Delete(v);
                return true;
            }
            catch(Exception e) { return false; }
        }

    }
}
