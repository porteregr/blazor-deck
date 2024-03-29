﻿using System;
using Newtonsoft.Json;

namespace BlazorDeck.Shared.ComponentModels
{
    public class ActiveWindowEvent : IServerEvent
    {
        public event EventHandler EventActive;
        public event EventHandler EventInactive;
        [JsonIgnore]
        public bool State { get; private set; } = false;

        public string WindowName { get; private set; }

        public ActiveWindowEvent(string windowName)
        {
            WindowName = windowName;
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
