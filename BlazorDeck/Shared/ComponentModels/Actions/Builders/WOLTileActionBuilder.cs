using System.ComponentModel.DataAnnotations;

namespace BlazorDeck.Shared.ComponentModels.Actions.Builders
{
    public class WOLTileActionBuilder : ITileActionBuilder, IBuilderFor<WOLTileAction>
    {
        [Required]
        [Display(Name = "Mac address")]
        public string MacAddress { get; set; }
        public WOLTileActionBuilder()
        {

        }

        public WOLTileActionBuilder(WOLTileAction wOLTileAction)
        {
            MacAddress = wOLTileAction.MacAddress;
        }
        public ITileAction BuildTileAction()
        {
            return new WOLTileAction(MacAddress);
        }
    }
}
