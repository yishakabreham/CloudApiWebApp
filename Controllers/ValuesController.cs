using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using SDA;

namespace CloudApiWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        TICKET2019Entities _context;
        public ValuesController(TICKET2019Entities context)
        {
            _context = context;
            _context.Configuration.ProxyCreationEnabled = false;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.code == id);
                if(user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound();
                }
            }
            return NotFound();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
