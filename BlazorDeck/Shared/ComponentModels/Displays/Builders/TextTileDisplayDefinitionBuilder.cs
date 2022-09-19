using System.ComponentModel.DataAnnotations;
using BlazorDeck.Shared.ComponentModels.Actions.Builders;

namespace BlazorDeck.Shared.ComponentModels.Displays.Builders
{
    public class TextTileDisplayDefinitionBuilder : ITileDisplayBuilder, IBuilderFor<TextTileDisplayDefinition>
    {
        [Required]
        [Display(Name = "Background Color")]
        public string BackgroundColor { get; set; }
        [Required]
        [Display(Name = "Text")]
        public string Text { get; set; }
        [Required]
        [Display(Name = "Text Color")]
        public string TextColor { get; set; }

        public TextTileDisplayDefinitionBuilder()
        {

        }

        public TextTileDisplayDefinitionBuilder(TextTileDisplayDefinition original)
        {
            BackgroundColor = original.BackgroundColor;
            Text = original.Text;
            TextColor = original.TextColor;
        }

        public ITileDisplay BuildTileDisplay()
        {
            return new TextTileDisplayDefinition(Text, BackgroundColor, TextColor);
        }
    }
}
