using BlazorDeck.Client.Services.ActionRunners;
using BlazorDeck.Shared.ComponentModels;
using System.Threading.Tasks;

namespace BlazorDeck.Client.Services
{
    public class ActionRouter : IActionRunner
    {
        private readonly APIActionRunner aPIActionRunner;
        private readonly NavActionRunner navActionRunner;
        public ActionRouter(APIActionRunner aPIActionRunner, NavActionRunner navActionRunner)
        {
            this.aPIActionRunner = aPIActionRunner;
            this.navActionRunner = navActionRunner;
        }

        public Task RunAction(ITileAction action)
        {
            if(action is APITileAction)
            {
                return aPIActionRunner.RunAction(action);
            }
            if(action is NavTileAction)
            {
                return navActionRunner.RunAction(action);
            }
            return Task.CompletedTask;
        }
    }
}
