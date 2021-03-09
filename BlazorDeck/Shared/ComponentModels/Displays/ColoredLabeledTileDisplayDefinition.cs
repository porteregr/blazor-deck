namespace BlazorDeck.Shared.ComponentModels.Displays
{
    public class ColoredLabeledTileDisplayDefinition: ColoredTileDisplayDefinition
    {
        public string Label { get; private set; }
        public string LabelColor { get; private set; }
        public ColoredLabeledTileDisplayDefinition(string label, string labelColor, string backgroundColor) : base(backgroundColor)
        {
            Label = label;
            LabelColor = labelColor;
        }
    }
}
