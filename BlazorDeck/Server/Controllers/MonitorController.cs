using BlazorDeck.Server.SystemControl.PrimaryMonitor;
using Microsoft.AspNetCore.Mvc;

namespace BlazorDeck.Server.Controllers
{
    [Route("api/monitor")]
    [ApiController]
    public class MonitorController : ControllerBase
    {
        private readonly PrimaryDisplayManager primaryDisplayManager; 
        public MonitorController(PrimaryDisplayManager primaryDisplayManager)
        {
            this.primaryDisplayManager = primaryDisplayManager;
        }
        [Route("primary")]
        [HttpPost]
        public IActionResult KeyPessPost([FromBody]uint id)
        {
            primaryDisplayManager.SetAsPrimaryMonitor(id);
            return Ok();
        }
    }
}
