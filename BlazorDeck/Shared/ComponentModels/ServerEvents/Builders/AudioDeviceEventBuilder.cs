using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BlazorDeck.Shared.ComponentModels.Actions.Builders;

namespace BlazorDeck.Shared.ComponentModels.ServerEvents.Builders
{
    public class AudioDeviceEventBuilder : IServerEventBuilder, IBuilderFor<AudioDeviceEvent>
    {
        [Required]
        [Display(Name = "Device Id")]
        public string DeviceId { get; set; }
        public AudioDeviceEventBuilder()
        {

        }
        public AudioDeviceEventBuilder(AudioDeviceEvent original)
        {
            DeviceId = original.DeviceId;
        }
        public IServerEvent BuildServerEvent()
        {
            throw new NotImplementedException();
        }
    }
}
