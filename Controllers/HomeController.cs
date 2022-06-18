using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace economyopedia_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("WakeMe")]
        public IActionResult WakeMe()
        {
            return Ok();
        }
    }
}
