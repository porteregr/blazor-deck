using Microsoft.AspNetCore.Mvc;

namespace BlazorDeck.Server.Controllers
{
    [Route("api/ping")]
    [ApiController]
    public class PingController : ControllerBase
    {
        public PingController()
        {
        }
        [Route("")]
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok();
        }
    }
}
