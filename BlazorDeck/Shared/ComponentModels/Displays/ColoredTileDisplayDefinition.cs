namespace BlazorDeck.Shared.ComponentModels.Displays
{
    public class ColoredTileDisplayDefinition : ITileDisplay
    {
        public string BackgroundColor { get; private set; }
        public ColoredTileDisplayDefinition(string backgroundColor)
        {
            BackgroundColor = backgroundColor;
        }
    }
}
