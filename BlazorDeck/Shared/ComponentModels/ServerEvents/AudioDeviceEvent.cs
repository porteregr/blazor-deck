using System;
using Newtonsoft.Json;

namespace BlazorDeck.Shared.ComponentModels.ServerEvents
{
    public class AudioDeviceEvent : IServerEvent
    {
        public event EventHandler EventActive;
        public event EventHandler EventInactive;
        [JsonIgnore]
        public bool State { get; private set; } = false;
        public string DeviceId { get; private set; }

        public AudioDeviceEvent(string deviceId)
        {
            DeviceId = deviceId;
        }

        public void Deactivate()
        {
            State = false;
            EventInactive?.Invoke(this, null);
        }

        public void Activate()
        {
            State = true;
            EventActive?.Invoke(this, null);
        }
    }
}
