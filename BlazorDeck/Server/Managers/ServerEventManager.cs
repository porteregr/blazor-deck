using BlazorDeck.Server.Hubs;
using BlazorDeck.Server.SystemControl;
using Microsoft.AspNetCore.SignalR;

namespace BlazorDeck.Server.Managers
{
    public class ServerEventManager
    {
        private readonly IHubContext<ServerEventHub> hubContext;
        private readonly WindowManagement windowManagement;
        public ServerEventManager(IHubContext<ServerEventHub> hubContext, WindowManagement windowManagement)
        {
            this.hubContext = hubContext;
            this.windowManagement = windowManagement;
            SubscribeToWindowUpdates();
        }

        private void SubscribeToWindowUpdates()
        {
            windowManagement.WindowChanged += SendWindowChange;
        }

        private void SendWindowChange(object sender, string windowName)
        {
            hubContext.Clients.All.SendAsync("WindowChange",windowName);
        }
    }
}
