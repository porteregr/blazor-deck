using System;
using BlazorDeck.Server.Hubs;
using BlazorDeck.Server.SystemControl;
using Microsoft.AspNetCore.SignalR;
using SoundSwitch.Audio.Manager;
using static SoundSwitch.Audio.Manager.WindowMonitor;

namespace BlazorDeck.Server.Managers
{
    public class ServerEventManager
    {
        private readonly IHubContext<ServerEventHub> hubContext;
        private readonly WindowMonitor windowMonitor;
        private readonly DefaultAudioMonitor defaultAudioMonitor;
        public ServerEventManager(IHubContext<ServerEventHub> hubContext, WindowMonitor windowMonitor, DefaultAudioMonitor defaultAudioMonitor)
        {
            this.hubContext = hubContext;
            this.windowMonitor = windowMonitor;
            this.defaultAudioMonitor = defaultAudioMonitor;
            SubscribeToWindowUpdates();
            SubscribeToAudioUpdates();
        }

        private void SubscribeToAudioUpdates()
        {
            defaultAudioMonitor.DefaultAudioDeviceChanged += SendAudioDeviceChange;
        }

        private void SendAudioDeviceChange(object sender, string audioDeviceId)
        {
            hubContext.Clients.All.SendAsync("AudioDeviceChange", audioDeviceId);
        }

        private void SubscribeToWindowUpdates()
        {
            windowMonitor.ForegroundChanged += SendWindowChange;
        }

        private void SendWindowChange(object sender, Event windowEvent)
        {
            hubContext.Clients.All.SendAsync("WindowChange", windowEvent.WindowName);
        }
    }
}
