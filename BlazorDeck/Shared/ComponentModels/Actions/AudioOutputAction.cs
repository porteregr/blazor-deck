using System.Net.Http;
using Newtonsoft.Json;

namespace BlazorDeck.Shared.ComponentModels.Actions
{
    public class AudioOutputAction : APITileAction
    {
        public AudioOutputAction(string name)
        {
            Route = "api/audio/media";
            Method = HttpMethod.Post;
            Content = name;
        }
        [JsonConstructor]
        public AudioOutputAction(string content, HttpMethod method, string route)
        {
            Route = route;
            Method = method;
            Content = content;
        }
    }
}
