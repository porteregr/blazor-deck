using System;
using System.Threading.Tasks;
using BlazorDeck.Shared.ComponentModels;

namespace BlazorDeck.Client.Services.ActionRunners
{
    public class NavActionRunner : IActionRunner
    {
        public event EventHandler NavEvent;
        public Task RunAction(ITileAction action)
        {
            if (action is NavTileAction apiAction)
            {
                NavEvent.Invoke(action, null);
            }

            return Task.CompletedTask;
        }
    }
}
