using System.Collections.Generic;
using System.Linq;
using BlazorDeck.Shared.ComponentModels.Actions;

namespace BlazorDeck.Server.Managers
{
    public class ProgramRunManager
    {
        private Dictionary<string,ProgramRunAction> programRunActionsByName;
        public ProgramRunManager(BookManager tileConfigManager)
        {
            var programRunActions = tileConfigManager.GetBooks().SelectMany((book) => book.SelectMany((tilePageDefinition) =>
                tilePageDefinition.Tiles.Where((tile) => tile.Action is ProgramRunAction).Select((tile) =>
                    tile.Action as ProgramRunAction)));
            programRunActionsByName = programRunActions.ToDictionary((action) => action.Content as string, (action) => action);
        }

        public void RunProgram(string name)
        {
            if(programRunActionsByName.TryGetValue(name, out var action))
            {
                if (string.IsNullOrEmpty(action.Param))
                {
                    System.Diagnostics.Process.Start(action.Path);
                }
                else
                {
                    System.Diagnostics.Process.Start(action.Path, action.Param);
                }
            }
        }
    }
}
