using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SoundSwitch.Audio.Manager;
using SoundSwitch.Framework.Audio.Lister;

namespace BlazorDeck.Server.Controllers
{
    [Route("api/audio")]
    [ApiController]
    public class AudioOutputController : ControllerBase
    {
        private readonly AudioSwitcher audioSwitcher;
        private readonly CachedAudioDeviceLister cachedAudioDeviceLister;
        public AudioOutputController(AudioSwitcher audioSwitcher, CachedAudioDeviceLister cachedAudioDeviceLister)
        {
            this.audioSwitcher = audioSwitcher;
            this.cachedAudioDeviceLister = cachedAudioDeviceLister;
        }
        [Route("media")]
        [HttpPost]
        public IActionResult KeyPessPost([FromBody]string name)
        {
            cachedAudioDeviceLister.Refresh();
            var deviceToSelect = cachedAudioDeviceLister.PlaybackDevices.FirstOrDefault((device) => string.Equals(device.NameClean, name));
            if(deviceToSelect == default)
            {
                return NotFound();
            }
            audioSwitcher.SwitchTo(deviceToSelect.Id,SoundSwitch.Audio.Manager.Interop.Enum.ERole.eMultimedia);
            return Ok();
        }
    }
}
