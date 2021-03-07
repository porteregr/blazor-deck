using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDeck.Shared.ComponentModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorDeck.Client.Services.ServerEventHandlers
{
    public class ServerEventManager
    {
        private readonly ActiveWindowEventHandler activeWindowEventHandler;
        private readonly HubConnection hubConnection;
        public ServerEventManager(NavigationManager navigationManager, ActiveWindowEventHandler activeWindowEventHandler)
        {
            this.activeWindowEventHandler = activeWindowEventHandler;
            hubConnection = new HubConnectionBuilder()
            .WithUrl(navigationManager.ToAbsoluteUri("/servereventhub"))
            .Build();
        }

        public Task Start(IEnumerable<IServerEvent> serverEvents)
        {
            RegisterEventHandlers(serverEvents);
            return hubConnection.StartAsync();
        }

        private void RegisterEventHandlers(IEnumerable<IServerEvent> serverEvents)
        {
            foreach(var serverEvent in serverEvents)
            {
                  activeWindowEventHandler.RegisterEvent(serverEvent, hubConnection);
            }
        }
    }
}
