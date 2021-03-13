using System.Net.Http;
using Newtonsoft.Json;

namespace BlazorDeck.Shared.ComponentModels.Actions
{
    public class ProgramRunAction : APITileAction
    {
        public string Path { get; }
        public string Param { get; }
        public ProgramRunAction(string name,string path, string param = null)
        {
            Path = path;
            Route = "api/runprogram";
            Method = HttpMethod.Post;
            Content = name;
            Param = param;
        }
        [JsonConstructor]
        public ProgramRunAction(string content, string path, string param, HttpMethod method, string route)
        {
            Path = path;
            Route = route;
            Method = method;
            Content = content;
            Param = param;
        }
    }
}
