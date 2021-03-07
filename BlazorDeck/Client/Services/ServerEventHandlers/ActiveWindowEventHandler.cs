using System.Collections.Generic;
using System.Linq;
using BlazorDeck.Shared.ComponentModels;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorDeck.Client.Services.ServerEventHandlers
{
    public class ActiveWindowEventHandler
    {
        private bool registeredToHub = false;
        private readonly Dictionary<string, List<ActiveWindowEvent>> registeredEvents = new Dictionary<string, List<ActiveWindowEvent>>();
        private List<ActiveWindowEvent> activeEvents = new List<ActiveWindowEvent>();
        public void RegisterEvent(IServerEvent serverEvent, HubConnection hubConnection)
        {
            if(serverEvent is ActiveWindowEvent activeWindowEvent)
            {
                RegisterIfNeeded(hubConnection);
                if(!registeredEvents.TryAdd(activeWindowEvent.WindowName, new List<ActiveWindowEvent> { activeWindowEvent }))
                {
                    registeredEvents[activeWindowEvent.WindowName].Add(activeWindowEvent);
                }
            }
        }

        private void RegisterIfNeeded(HubConnection hubConnection)
        {
            if (!registeredToHub)
            {
                hubConnection.On<string>("WindowChange", WindowChanged);
                registeredToHub = true;
            }
        }

        private void WindowChanged(string currentWindow)
        {
            foreach(var activeEvent in activeEvents)
            {
                activeEvent.Deactivate();
            }

            activeEvents = new List<ActiveWindowEvent>();
            var programName = currentWindow.Split("-").Last().Trim();
            foreach(var events in registeredEvents.Values)
            {
                if (currentWindow.Contains(events.First().WindowName))
                {
                    activeEvents = events;
                    foreach (var activeEvent in events)
                    {
                        activeEvent.Activate();
                    }
                }
            }
        }
    }
}
