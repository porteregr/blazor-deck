using System.Net.Http;
using Newtonsoft.Json;

namespace BlazorDeck.Shared.ComponentModels.Actions
{
    public class PrimaryMonitorAction : APITileAction
    {
        public PrimaryMonitorAction(uint monitorId)
        {
            Route = "api/monitor/primary";
            Method = HttpMethod.Post;
            Content = monitorId;
        }
        [JsonConstructor]
        public PrimaryMonitorAction(string content, HttpMethod method, string route)
        {
            Route = route;
            Method = method;
            Content = content;
        }
    }
}
