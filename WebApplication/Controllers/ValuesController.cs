using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class Value
    {
        public int Id;
    }

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Values-1", "Values-2" };
        }

        [HttpGet("{id:int}")]
        public string Get(int id)
        {
            return $"values: {id}";
        }

        [HttpPost]
        public IActionResult Post([FromBody]Value value)
        {
            return CreatedAtAction("Get", new {id = value.Id}, value);
        }
    }
}