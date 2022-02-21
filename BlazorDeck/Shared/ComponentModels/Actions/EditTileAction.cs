namespace BlazorDeck.Shared.ComponentModels
{
    public class EditTileAction : NavTileAction, ITileAction
    {
        public TileDefinition OriginalTile { get; private set; }

        public EditTileAction(TileDefinition originalTile, string pageName = null):base(pageName)
        {
            OriginalTile = originalTile;
        }
    }
}
