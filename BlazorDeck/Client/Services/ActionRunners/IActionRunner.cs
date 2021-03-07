using BlazorDeck.Shared.ComponentModels;
using System.Threading.Tasks;

namespace BlazorDeck.Client.Services.ActionRunners
{
    interface IActionRunner
    {
        public Task RunAction(ITileAction action);
    }
}
