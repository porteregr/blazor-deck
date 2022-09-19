using System.ComponentModel.DataAnnotations;
using BlazorDeck.Shared.ComponentModels.Actions.Builders;

namespace BlazorDeck.Shared.ComponentModels.Displays.Builders
{
    public class DigitalClockDisplayDefinitionBuilder : ITileDisplayBuilder, IBuilderFor<DigitalClockDisplayDefinition> 
    {
        [Required]
        [Display(Name = "Background Color")]
        public string BackgroundColor { get; set; }
        [Required]
        [Display(Name = "Text Color")]
        public string TextColor { get; set; }
        public DigitalClockDisplayDefinitionBuilder()
        {
        }

        public DigitalClockDisplayDefinitionBuilder(DigitalClockDisplayDefinition orginal)
        {
            BackgroundColor = orginal.BackgroundColor;
            TextColor = orginal.TextColor;
        }

        public ITileDisplay BuildTileDisplay()
        {
            return new DigitalClockDisplayDefinition("", BackgroundColor, TextColor);
        }
    }
}
