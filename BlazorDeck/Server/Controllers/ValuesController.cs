using BlazorDeck.Server.SystemControl;
using Microsoft.AspNetCore.Mvc;

namespace BlazorDeck.Server.Controllers
{
    [Route("api/volume")]
    [ApiController]
    public class VolumeController : ControllerBase
    {
        private readonly VolumeControl volumeControl;
        private readonly WindowManagement windowManagement;
        public VolumeController(VolumeControl volumeControl, WindowManagement windowManagement)
        {
            this.volumeControl = volumeControl;
            this.windowManagement = windowManagement;
        }
        [Route("mute")]
        [HttpPost]
        public IActionResult MutePost() {
            volumeControl.Mute();
            return Ok();
        }

        [Route("window")]
        [HttpGet]
        public IActionResult GetActiveWindow()
        {
            return Ok(windowManagement.GetActiveWindow());
        }
    }
}
