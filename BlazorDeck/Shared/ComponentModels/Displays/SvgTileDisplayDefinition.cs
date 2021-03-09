namespace BlazorDeck.Shared.ComponentModels.Displays
{
    public class SvgTileDisplayDefinition: ColoredLabeledTileDisplayDefinition
    {
        public string SvgPath { get; private set; }

        public SvgTileDisplayDefinition(string svgPath, string backgroundColor, string label = null, string labelColor = "#FFFFFF"):base(label, labelColor, backgroundColor)
        {
            SvgPath = svgPath;
        }
    }
}
