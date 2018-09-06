using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Extension.Alpha.Controllers
{
    [Route("api1/[controller]")]
    public class AlphaController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Alpha-1", "Alpha-2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"values: {id}";
        }

        [HttpGet("{id}")]
        public string Values(int id)
        {
            return $"values: {id}";
        }
    }
}
