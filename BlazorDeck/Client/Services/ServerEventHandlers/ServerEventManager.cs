using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDeck.Shared.ComponentModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorDeck.Client.Services.ServerEventHandlers
{
    public class ServerEventManager
    {
        private readonly ActiveWindowEventHandler activeWindowEventHandler;
        private readonly AudioDeviceEventHandler audioDeviceEventHandler;
        private readonly HubConnection hubConnection;
        public ServerEventManager(NavigationManager navigationManager, ActiveWindowEventHandler activeWindowEventHandler, AudioDeviceEventHandler audioDeviceEventHandler)
        {
            this.activeWindowEventHandler = activeWindowEventHandler;
            this.audioDeviceEventHandler = audioDeviceEventHandler;
            hubConnection = new HubConnectionBuilder()
            .WithUrl(navigationManager.ToAbsoluteUri("/servereventhub"))
            .Build();
        }

        public async Task Start(IEnumerable<IServerEvent> serverEvents)
        {
            if(hubConnection.State != HubConnectionState.Connected && hubConnection.State != HubConnectionState.Connecting)
            {
                await hubConnection.StartAsync();
            }           
            RegisterEventHandlers(serverEvents);
        }

        private void RegisterEventHandlers(IEnumerable<IServerEvent> serverEvents)
        {
            foreach(var serverEvent in serverEvents)
            {
                activeWindowEventHandler.RegisterEvent(serverEvent, hubConnection);
                audioDeviceEventHandler.RegisterEvent(serverEvent, hubConnection);
            }
        }
    }
}
