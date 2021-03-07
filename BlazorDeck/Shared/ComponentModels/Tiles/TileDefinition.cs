using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDeck.Shared.ComponentModels
{
    public class TileDefinition
    {
        public ITileAction Action { get; private set; }
        public ITileDisplay Display { get; private set; }
        public string Name { get; private set; }
        public float Priority { get; private set; }

        public TileDefinition(ITileAction action, ITileDisplay display, string name, float priority = 1)
        {
            Action = action;
            Display = display;
            Name = name;
            Priority = priority;
        }
    }
}
