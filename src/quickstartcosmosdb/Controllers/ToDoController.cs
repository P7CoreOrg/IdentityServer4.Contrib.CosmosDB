using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo;
using todo.Models;

namespace quickstartcosmosdb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        // GET: api/ToDo
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var items = await DocumentDBRepository<Item>.GetItemsAsync(d => !d.Completed);

            return new string[] { "value1", "value2" };
        }

        // GET: api/ToDo/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        string NewGuidS => Guid.NewGuid().ToString();
        // POST: api/ToDo
        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            var item = new Item
            {
                Id = NewGuidS,
                Name = value,
                Completed = false,
                Description = NewGuidS
            };
            await DocumentDBRepository<Item>.CreateItemAsync(item);
        }

        // PUT: api/ToDo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
