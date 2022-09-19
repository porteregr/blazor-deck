using System.Collections.Generic;

namespace BlazorDeck.Shared.ComponentModels
{
    public class TilePageDefinition
    {
        public IReadOnlyList<TileDefinition> Tiles { get; private set; }
        public string Name { get; private set; }
        public TileDefinition NavTile { get; private set; }
        public IServerEvent NavEvent { get; private set; }
        public bool DefaultPage { get; private set; }

        public TilePageDefinition(List<TileDefinition> tiles, string name, TileDefinition navTile, IServerEvent navEvent, bool defaultPage = false)
        {
            Tiles = tiles;
            Name = name;
            NavTile = navTile;
            NavEvent = navEvent;
            DefaultPage = defaultPage;
        }

        public TilePageDefinition Add(TileDefinition newTile)
        {
            var tiles = new List<TileDefinition>(Tiles)
            {
                newTile
            };
            return new TilePageDefinition(tiles, Name, NavTile, NavEvent, DefaultPage);
        }

        public TilePageDefinition Remove(TileDefinition tileToRemove)
        {
            var tiles = new List<TileDefinition>(Tiles);
            tiles.Remove(tileToRemove);
            return new TilePageDefinition(tiles, Name, NavTile, NavEvent, DefaultPage);
        }

        public TilePageDefinition Replace(TileDefinition orginalTile, TileDefinition newTile)
        {
            var tiles = new List<TileDefinition>(Tiles)
            {
                newTile
            };
            tiles.Remove(orginalTile);
            return new TilePageDefinition(tiles, Name, NavTile, NavEvent, DefaultPage);
        }
    }
}
