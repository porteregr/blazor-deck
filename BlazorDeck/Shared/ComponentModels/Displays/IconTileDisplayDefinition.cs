namespace BlazorDeck.Shared.ComponentModels.Displays
{
    public class IconTileDisplayDefinition: ColoredLabeledTileDisplayDefinition
    {
        public string Icon { get; private set; }
        public string IconColor { get; private set; }
        public IconTileDisplayDefinition(string icon, string backgroundColor, string iconColor, string label = null):base(label, iconColor, backgroundColor)
        {
            Icon = icon;
            IconColor = iconColor;
        }
    }
}
