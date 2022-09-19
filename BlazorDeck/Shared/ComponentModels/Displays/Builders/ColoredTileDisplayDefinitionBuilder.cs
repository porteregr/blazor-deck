using System.ComponentModel.DataAnnotations;
using BlazorDeck.Shared.ComponentModels.Actions.Builders;

namespace BlazorDeck.Shared.ComponentModels.Displays.Builders
{
    public class ColoredTileDisplayDefinitionBuilder : ITileDisplayBuilder, IBuilderFor<ColoredTileDisplayDefinitionBuilder>
    {
        [Required]
        [Display(Name = "Background Color")]
        public string BackgroundColor { get; set; }

        public ColoredTileDisplayDefinitionBuilder()
        {

        }

        public ColoredTileDisplayDefinitionBuilder(ColoredTileDisplayDefinition orginal)
        {
            BackgroundColor = orginal.BackgroundColor;
        }

        public ITileDisplay BuildTileDisplay()
        {
            return new ColoredTileDisplayDefinition(BackgroundColor);
        }
    }
}
