using BlazorDeck.Server.Managers;
using BlazorDeck.Server.SystemControl;
using Microsoft.AspNetCore.SignalR;

namespace BlazorDeck.Server.Hubs
{
    public class ServerEventHub:Hub
    {
        private readonly ServerEventManager serverEventManager;
        private readonly DefaultAudioMonitor defaultAudioMonitor;
        public ServerEventHub(ServerEventManager serverEventManager, DefaultAudioMonitor defaultAudioMonitor)
        {
            this.serverEventManager = serverEventManager;
            this.defaultAudioMonitor = defaultAudioMonitor;
        }

        public string CurrentAudioDevice()
        {
            return defaultAudioMonitor.CurrentAudioDevice();
        }
    }
}
