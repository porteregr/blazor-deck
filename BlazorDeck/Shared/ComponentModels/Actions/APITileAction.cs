using System.Net.Http;

namespace BlazorDeck.Shared.ComponentModels
{
    public class APITileAction : ITileAction
    {
        public string Route { get; }
        public HttpMethod Method { get; }
        public object Content { get; }
        public APITileAction(string route, HttpMethod method, object content = null)
        {
            this.Route = route;
            this.Method = method;
            this.Content = content;
        }
    }
}
