using System.Collections.Generic;
using System.Linq;
using BlazorDeck.Shared.ComponentModels;
using BlazorDeck.Shared.ComponentModels.ServerEvents;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorDeck.Client.Services.ServerEventHandlers
{
    public class AudioDeviceEventHandler
    {
        private bool registeredToHub = false;
        private readonly Dictionary<string, List<AudioDeviceEvent>> registeredEvents = new();
        private readonly List<AudioDeviceEvent> activeEvents = new();
        private string intitialValue;
        public void RegisterEvent(IServerEvent serverEvent, HubConnection hubConnection)
        {
            if (serverEvent is AudioDeviceEvent audioDeviceEvent)
            {
                if (!registeredToHub)
                {
                    GetInitialValue(hubConnection);
                }
                RegisterIfNeeded(hubConnection);
                if (!registeredEvents.TryAdd(audioDeviceEvent.DeviceId, new List<AudioDeviceEvent> { audioDeviceEvent }))
                {
                    registeredEvents[audioDeviceEvent.DeviceId].Add(audioDeviceEvent);
                }


                AudioDeviceChanged(intitialValue);
            }
        }

        private void RegisterIfNeeded(HubConnection hubConnection)
        {
            if (!registeredToHub)
            {
                hubConnection.On<string>("AudioDeviceChange", AudioDeviceChanged);
                registeredToHub = true;
            }
        }

        private async void GetInitialValue(HubConnection hubConnection)
        {
            intitialValue = await hubConnection.InvokeAsync<string>("CurrentAudioDevice");
            AudioDeviceChanged(intitialValue);
        }

        private void AudioDeviceChanged(string currentDevie)
        {
            if (string.IsNullOrEmpty(currentDevie)){
                return;
            }

            foreach (var activeEvent in activeEvents)
            {
                activeEvent.Deactivate();
            }

            activeEvents.Clear();
            foreach (var events in registeredEvents.Values)
            {
                if (currentDevie.Contains(events.First().DeviceId))
                {
                    activeEvents.AddRange(events);
                    foreach (var activeEvent in events)
                    {
                        activeEvent.Activate();
                    }
                }
            }
        }
    }
}
