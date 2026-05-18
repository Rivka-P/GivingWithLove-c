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
    public class EichudController : ControllerBase
    {
        IBl bl;
        public EichudController(IBl bl)
        {
            this.bl = bl;
        }

        // GET: api/<EichudController>
        [HttpGet]
        public async Task<List<BlEichudModel>> GetAll()
        {
            return await bl.Eichud.ReadAllAsync();
        }

        // GET api/<EichudController>/5
        [HttpGet("{id}")]
        public async Task<BlEichudModel> Get(int id)
        {
            return await bl.Eichud.ReadAsync(id);
        }

        // POST api/<EichudController>
        [HttpPost]
        public async Task Post([FromBody] BlEichudModel value)
        {
            await bl.Eichud.CreateAsync(value);
        }

        // PUT api/<EichudController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] BlEichudModel value)
        {
            await bl.Eichud.UpdateAsync(value);
        }

        // DELETE api/<EichudController>/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var all = await bl.Eichud.ReadAllAsync();
                var v = all.Find(e => e.EichudCode == id);
                if (v == null)
                    throw new NullReferenceException("Eichud not found");

                await bl.Eichud.DeleteAsync(v);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}