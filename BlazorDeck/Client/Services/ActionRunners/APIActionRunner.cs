using BlazorDeck.Shared.ComponentModels;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorDeck.Client.Services.ActionRunners
{
    public class APIActionRunner: IActionRunner
    {
        private HttpClient http;
        public APIActionRunner(HttpClient http)
        {
            this.http = http;
        }
        public Task RunAction(ITileAction action)
        {
            if(action is APITileAction apiAction)
            {
                var httpMessage = new HttpRequestMessage(apiAction.Method, apiAction.Route);
                if(apiAction.Content != null)
                {
                    httpMessage.Content = JsonContent.Create(apiAction.Content);
                }
                
                return http.SendAsync(httpMessage);
            }

            return Task.CompletedTask;
        }
    }
}
