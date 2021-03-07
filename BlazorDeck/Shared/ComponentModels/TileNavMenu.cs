using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDeck.Shared.ComponentModels
{
    public class TileNavMenu
    {
        public IList<TileDefinition> Tiles { get; private set; }
        public TileDefinition HomeTile { get; private set; }
        public TileDefinition DefaultActiveTile { get; private set; }
    }
}
