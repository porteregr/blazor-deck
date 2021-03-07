using BlazorDeck.Server.Managers;
using Microsoft.AspNetCore.SignalR;

namespace BlazorDeck.Server.Hubs
{
    public class ServerEventHub:Hub
    {
        private readonly ServerEventManager serverEventManager;
        public ServerEventHub(ServerEventManager serverEventManager)
        {
            this.serverEventManager = serverEventManager;
        }


    }
}
