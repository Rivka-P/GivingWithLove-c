using Bl.BLApi;
using Bl.BLModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<List<BlPositionModel>> GetAll()
        {
            return await bl.Position.ReadAllAsync();
        }

        // GET api/<PositionController>/5
        [HttpGet("{id}")]
        public async Task<BlPositionModel> Get(int id)
        {
            return await bl.Position.ReadAsync(id);
        }

        // POST api/<PositionController>
        [HttpPost]
        public async Task Post([FromBody] BlPositionModel value)
        {
            await bl.Position.CreateAsync(value);
        }

        // PUT api/<PositionController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] BlPositionModel value)
        {
            await bl.Position.UpdateAsync(value);
        }

        // DELETE api/<PositionController>/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync([FromBody] BlPositionModel value)
        {
            try
            {
                await bl.Position.DeleteAsync(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}