using System.Net.Http;
using Newtonsoft.Json;

namespace BlazorDeck.Shared.ComponentModels.Actions
{
    public class ProgramRunAction : APITileAction
    {
        public string Path { get; }
        public ProgramRunAction(string name,string path)
        {
            Path = path;
            Route = "api/runprogram";
            Method = HttpMethod.Post;
            Content = name;
        }
        [JsonConstructor]
        public ProgramRunAction(string content, string path, HttpMethod method, string route)
        {
            Path = path;
            Route = route;
            Method = method;
            Content = content;
        }
    }
}
