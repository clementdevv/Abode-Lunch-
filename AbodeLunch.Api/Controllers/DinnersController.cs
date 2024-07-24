using Microsoft.AspNetCore.Mvc;

namespace AbodeLunch.Api.Controllers;

    [Route("[controller]")]
    public class DinnersController : ApiController 
    {
        [HttpGet]
        public IActionResult ListDinners()
        {
            return Ok(Array.Empty<string>());
        }
    }
