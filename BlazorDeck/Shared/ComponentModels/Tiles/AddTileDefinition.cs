using BlazorDeck.Shared.ComponentModels.Displays;

namespace BlazorDeck.Shared.ComponentModels.Tiles
{
    public class AddTileDefinition : TileDefinition
    {
        public AddTileDefinition(string pageName = null)
        {
            Action = new EditTileAction(this, pageName);
            Display = new IconTileDisplayDefinition("fa-plus-square", "#2D2D30", "#FFFFFF", pageName != null ? "Add Page": "Add Tile");
            Name = "Add Tile";
            Priority = decimal.MaxValue;
            Width = 1;
            Height = 1;
            Togglable = false;
        }
    }
}
