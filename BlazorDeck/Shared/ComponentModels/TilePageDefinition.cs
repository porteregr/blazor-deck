using System.Collections.Generic;

namespace BlazorDeck.Shared.ComponentModels
{
    public class TilePageDefinition
    {
        public List<TileDefinition> Tiles { get; private set; }
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
    }
}
