using System;
using System.ComponentModel.DataAnnotations;
using BlazorDeck.Shared.ComponentModels.Actions.Builders;

namespace BlazorDeck.Shared.ComponentModels.Displays.Builders
{
    public class SvgTileDisplayDefinitionBuilder : ITileDisplayBuilder, IBuilderFor<SvgTileDisplayDefinition>
    {
        [Required]
        [Display(Name = "Background Color")]
        public string BackgroundColor { get; set; }
        [Required]
        [Display(Name = "Svg")]
        public string SvgPath { get; set; }
        [Display(Name = "Svg Color")]
        public string SvgColor { get; set; } = "#FFFFFF";
        [Display(Name = "Label")]
        public string Label { get; set; } = null;

        public SvgTileDisplayDefinitionBuilder()
        {
        }

        public SvgTileDisplayDefinitionBuilder(SvgTileDisplayDefinition orginal)
        {
            BackgroundColor = orginal.BackgroundColor;
            SvgPath = orginal.SvgPath;
            SvgColor = orginal.LabelColor;
        }

        public ITileDisplay BuildTileDisplay()
        {
            return new SvgTileDisplayDefinition(SvgPath, BackgroundColor, String.IsNullOrWhiteSpace(Label) ? null: Label, SvgColor);
        }
    }
}
