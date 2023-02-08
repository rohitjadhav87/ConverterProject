using Microsoft.AspNetCore.Mvc;

namespace Converter.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok("Converter API is Up.");
        }
    }
}
