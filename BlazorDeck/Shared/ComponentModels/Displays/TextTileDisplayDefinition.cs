namespace BlazorDeck.Shared.ComponentModels.Displays
{
    public class TextTileDisplayDefinition : ColoredTileDisplayDefinition
    {
        public string Text { get; private set; }
        public string TextColor { get; private set; }
        public TextTileDisplayDefinition(string text, string backgroundColor, string textColor):base(backgroundColor)
        {
            Text = text;
            TextColor = textColor;
        }
    }
}
