using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDeck.Shared.ComponentModels.Displays
{
    public class IconTileDisplayDefinition : ITileDisplay
    {
        public string Icon { get; private set; }
        public string BackgroundColor { get; private set; }
        public string IconColor { get; private set; }

        public IconTileDisplayDefinition(string icon, string backgroundColor, string iconColor)
        {
            Icon = icon;
            BackgroundColor = backgroundColor;
            IconColor = iconColor;
        }
    }
}
