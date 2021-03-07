using BlazorDeck.Client.Services.ActionRunners;
using BlazorDeck.Shared.ComponentModels;
using System.Threading.Tasks;

namespace BlazorDeck.Client.Services
{
    public class ActionRouter : IActionRunner
    {
        private readonly APIActionRunner aPIActionRunner;
        public ActionRouter(APIActionRunner aPIActionRunner)
        {
            this.aPIActionRunner = aPIActionRunner;
        }

        public Task RunAction(ITileAction action)
        {
            if(action is APITileAction)
            {
                return aPIActionRunner.RunAction(action);
            }
            return Task.CompletedTask;
        }
    }
}
