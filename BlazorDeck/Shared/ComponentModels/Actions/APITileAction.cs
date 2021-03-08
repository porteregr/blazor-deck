using System.Net.Http;

namespace BlazorDeck.Shared.ComponentModels
{
    public class APITileAction : ITileAction
    {
        public string Route { get; protected set; }
        public HttpMethod Method { get; protected set; }
        public object Content { get; protected set; }
        protected APITileAction()
        { }
        public APITileAction(string route, HttpMethod method, object content = null)
        {
            this.Route = route;
            this.Method = method;
            this.Content = content;
        }
    }
}
