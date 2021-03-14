using System;
using Newtonsoft.Json;

namespace BlazorDeck.Shared.ComponentModels.ServerEvents
{
    public class NullServerEvent : IServerEvent
    {
        public event EventHandler EventActive;
        public event EventHandler EventInactive;
        [JsonIgnore]
        public bool State { get; private set; } = false;
    }
}
