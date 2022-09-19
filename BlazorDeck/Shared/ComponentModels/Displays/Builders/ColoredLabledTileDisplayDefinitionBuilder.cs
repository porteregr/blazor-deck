using System.ComponentModel.DataAnnotations;
using BlazorDeck.Shared.ComponentModels.Actions.Builders;

namespace BlazorDeck.Shared.ComponentModels.Displays.Builders
{
    public class ColoredLabledTileDisplayDefinitionBuilder : ITileDisplayBuilder, IBuilderFor<ColoredLabeledTileDisplayDefinition>
    {
        [Required]
        [Display(Name = "Background Color")]
        public string BackgroundColor { get; set; }
        [Required]
        [Display(Name = "Label")]
        public string Label { get; set; }
        [Required]
        [Display(Name = "Label Color")]
        public string LabelColor { get; set; }

        public ColoredLabledTileDisplayDefinitionBuilder()
        {

        }

        public ColoredLabledTileDisplayDefinitionBuilder(ColoredLabeledTileDisplayDefinition original)
        {
            BackgroundColor = original.BackgroundColor;
            Label = original.Label;
            LabelColor = original.LabelColor;
        }

        public ITileDisplay BuildTileDisplay()
        {
            return new ColoredLabeledTileDisplayDefinition(Label, LabelColor, BackgroundColor);
        }
    }
}
