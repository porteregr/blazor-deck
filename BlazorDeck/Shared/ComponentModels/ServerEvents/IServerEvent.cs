using System;

namespace BlazorDeck.Shared.ComponentModels
{
    public interface IServerEvent
    {
        public event EventHandler EventActive;
        public event EventHandler EventInactive;
    }
}
