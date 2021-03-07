using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDeck.Shared.ComponentModels
{
    public class ActiveWindowEvent : IServerEvent
    {
        public event EventHandler EventActive;
        public event EventHandler EventInactive;

        public string WindowName { get; private set; }

        public ActiveWindowEvent(string windowName)
        {
            WindowName = windowName;
        }

        public void Deactivate()
        {
            EventInactive.Invoke(this, null);
        }

        public void Activate()
        {
            EventActive.Invoke(this, null);
        }
    }
}
