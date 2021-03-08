using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDeck.Shared.ComponentModels.Displays
{
    public class TextTileDisplayDefinition : ITileDisplay
    {
        public string Text { get; private set; }
        public string BackgroundColor { get; private set; }
        public string TextColor { get; private set; }
        public TextTileDisplayDefinition(string text, string backgroundColor, string textColor)
        {
            Text = text;
            BackgroundColor = backgroundColor;
            TextColor = textColor;
        }
    }
}
