using System;
using System.ComponentModel.DataAnnotations;
using BlazorDeck.Shared.ComponentModels.Actions.Builders;

namespace BlazorDeck.Shared.ComponentModels.Displays.Builders
{
    public class IconTileDisplayDefinitionBuilder : ITileDisplayBuilder, IBuilderFor<IconTileDisplayDefinition>
    {
        [Required]
        [Display(Name = "Background Color")]
        public string BackgroundColor { get; set; }
        [Required]
        [Display(Name = "Icon")]
        public string Icon { get; set; }
        [Required]
        [Display(Name = "Icon Color")]
        public string IconColor { get; set; }
        [Display(Name = "Label")]
        public string Label { get; set; } = String.Empty;

        public IconTileDisplayDefinitionBuilder()
        {
        }

        public IconTileDisplayDefinitionBuilder(IconTileDisplayDefinition orginal)
        {
            BackgroundColor = orginal.BackgroundColor;
            Icon = orginal.Icon;
            IconColor = orginal.IconColor;
            Label = orginal.Label;
        }

        public ITileDisplay BuildTileDisplay()
        {
            return new IconTileDisplayDefinition(Icon, BackgroundColor, IconColor, String.IsNullOrWhiteSpace(Label) ? null: Label);
        }
    }
}
