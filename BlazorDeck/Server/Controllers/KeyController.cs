using BlazorDeck.Server.SystemControl;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WindowsInput.Native;

namespace BlazorDeck.Server.Controllers
{
    [Route("api/keyboard")]
    [ApiController]
    public class KeyController : ControllerBase
    {
        private readonly KeyEmulation keyEmulator; 
        public KeyController(KeyEmulation keyEmulation)
        {
            this.keyEmulator = keyEmulation;
        }
        [Route("press")]
        [HttpPost]
        public IActionResult KeyPessPost([FromBody]VirtualKeyCode keyCode)
        {
            keyEmulator.PressKey(keyCode);
            
            return Ok();
        }
        [Route("presschord")]
        [HttpPost]
        public IActionResult KeyPessPost([FromBody] IEnumerable<VirtualKeyCode> keyCodes)
        {
            keyEmulator.PressChord(keyCodes);

            return Ok();
        }
    }
}
