using BlazorDeck.Server.Managers;
using Microsoft.AspNetCore.Mvc;

namespace BlazorDeck.Server.Controllers
{
    [Route("api/runprogram")]
    [ApiController]
    public class RunProgramController : ControllerBase
    {
        private readonly ProgramRunManager programRunManager; 
        public RunProgramController(ProgramRunManager programRunManager)
        {
            this.programRunManager = programRunManager;
        }
        [Route("")]
        [HttpPost]
        public IActionResult RunProgram([FromBody]string name)
        {
            programRunManager.RunProgram(name);
            
            return Ok();
        }
    }
}
