using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDeck.Shared.ComponentModels.Displays
{
    public class SvgTileDisplayDefinition: ITileDisplay
    {
        public string SvgPath { get; private set; }
        public string BackgroundColor { get; private set; }
        public string IconColor { get; private set; }
        public SvgTileDisplayDefinition(string svgPath, string backgroundColor, string iconColor)
        {
            SvgPath = svgPath;
            BackgroundColor = backgroundColor;
            IconColor = iconColor;
        }
    }
}
