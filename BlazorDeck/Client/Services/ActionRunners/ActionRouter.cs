using BlazorDeck.Client.Services.ActionRunners;
using BlazorDeck.Shared.ComponentModels;
using BlazorDeck.Shared.ComponentModels.Actions;
using System.Threading.Tasks;

namespace BlazorDeck.Client.Services
{
    public class ActionRouter : IActionRunner
    {
        private readonly APIActionRunner aPIActionRunner;
        private readonly NavActionRunner navActionRunner;
        private readonly NativeActionRunner nativeActionRunner;
        public ActionRouter(APIActionRunner aPIActionRunner, NavActionRunner navActionRunner, NativeActionRunner nativeActionRunner)
        {
            this.aPIActionRunner = aPIActionRunner;
            this.navActionRunner = navActionRunner;
            this.nativeActionRunner = nativeActionRunner;
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
            if(action is NativeTileAction)
            {
                return nativeActionRunner.RunAction(action);
            }
            return Task.CompletedTask;
        }
    }
}
