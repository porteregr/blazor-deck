using System.Collections.Generic;
using BlazorDeck.Shared.ComponentModels;
using BlazorDeck.Shared.ComponentModels.ServerEvents;
using BlazorDeck.Shared.ComponentModels.Tiles;

namespace BlazorDeck.Client.Services
{
    public class EditBookBuilder
    {
        public IEnumerable<TilePageDefinition> BuildEditBook(IEnumerable<TilePageDefinition> orginalBook)
        {
            var editBook = new List<TilePageDefinition>();
            foreach(var page in orginalBook)
            {
                editBook.Add(CopyPage(page));
            }
            editBook.Add(new TilePageDefinition(new List<TileDefinition> { new AddTileDefinition() }, "Add Page", new AddTileDefinition("Add Page"), new NullServerEvent(),orginalBook == null ? true :false));
            return editBook;
        }

        private TilePageDefinition CopyPage(TilePageDefinition orginalPage)
        {
            var editTiles = new List<TileDefinition>();
            foreach(var tile in orginalPage.Tiles)
            {
                editTiles.Add(CopyTile(tile));
            }
            editTiles.Add(new AddTileDefinition());
            var editNavTile = CopyTile(orginalPage.NavTile, orginalPage.Name);
            return new TilePageDefinition(editTiles,orginalPage.Name, editNavTile, new NullServerEvent(), orginalPage.DefaultPage);
        }

        private TileDefinition CopyTile(TileDefinition orginalTile, string pageName = null)
        {
            return new TileDefinition(new EditTileAction(orginalTile, pageName), orginalTile.Display, orginalTile.Name, orginalTile.Priority, false, null, orginalTile.Width, orginalTile.Height);
        }
    }
}
