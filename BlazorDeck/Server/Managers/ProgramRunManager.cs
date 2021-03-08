using System.Collections.Generic;
using System.Linq;
using BlazorDeck.Shared.ComponentModels.Actions;

namespace BlazorDeck.Server.Managers
{
    public class ProgramRunManager
    {
        private Dictionary<string,string> programRunActionsByName;
        public ProgramRunManager(TileConfigManager tileConfigManager)
        {
            var programRunActions = tileConfigManager.GetPages().SelectMany((tilePageDefinition) =>
                tilePageDefinition.Tiles.Where((tile) => tile.Action is ProgramRunAction).Select((tile) =>
                    tile.Action as ProgramRunAction));
            programRunActionsByName = programRunActions.ToDictionary((action) => action.Content as string, (action) => action.Path);
        }

        public void RunProgram(string name)
        {
            if(programRunActionsByName.TryGetValue(name, out var path))
            {
                System.Diagnostics.Process.Start(path);
            }
        }
    }
}
