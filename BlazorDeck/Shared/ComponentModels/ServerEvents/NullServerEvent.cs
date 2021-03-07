using System;

namespace BlazorDeck.Shared.ComponentModels.ServerEvents
{
    public class NullServerEvent : IServerEvent
    {
        public event EventHandler EventActive;
        public event EventHandler EventInactive;
    }
}
