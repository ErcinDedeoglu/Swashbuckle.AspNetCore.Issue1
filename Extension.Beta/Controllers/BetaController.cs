using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Extension.Beta.Controllers
{
    [Route("api2/[controller]")]
    public class BetaController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Beta-1", "Beta-2" };
        }
    }
}
