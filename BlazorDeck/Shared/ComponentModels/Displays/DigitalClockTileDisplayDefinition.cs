namespace BlazorDeck.Shared.ComponentModels.Displays
{
    public class DigitalClockDisplayDefinition : ColoredTileDisplayDefinition
    {
        public string Text { get; private set; }
        public string TextColor { get; private set; }
        public DigitalClockDisplayDefinition(string text, string backgroundColor, string textColor):base(backgroundColor)
        {
            Text = text;
            TextColor = textColor;
        }
    }
}
