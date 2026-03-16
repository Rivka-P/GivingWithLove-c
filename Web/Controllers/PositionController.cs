using Bl.BLApi;
using Bl.BLModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        IBl bl;
        public PositionController(IBl bl)
        {
            this.bl = bl;
        }
        // GET: api/<PositionController>
        [HttpGet]

        public Task<List<BlPositionModel>> Get()
        {
            return bl.Position.ReadAll();
        }
        
        // GET api/<PositionController>/5
        [HttpGet("{id}")]
        public Task<BlPositionModel> Get(int id)
        {
            return bl.Position.Read(id);
        }

        // POST api/<PositionController>
        [HttpPost]
        public void Post([FromBody] BlPositionModel value)
        {
            bl.Position.Create(value);
        }
        
        // PUT api/<PositionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BlPositionModel value)
        {
            bl.Position.Update(value);
        }
        
        // DELETE api/<PositionController>/5
        [HttpDelete("{id}")]
        public bool Delete(BlPositionModel id)
        {
            try
            {
                bl.Position.Delete(id);
                return true;
            }
            catch { return false; }
        }
    }
}
