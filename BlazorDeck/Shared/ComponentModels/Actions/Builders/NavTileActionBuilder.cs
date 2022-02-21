using System.ComponentModel.DataAnnotations;

namespace BlazorDeck.Shared.ComponentModels.Actions.Builders
{
    public class NavTileActionBuilder: ITileActionBuilder, IBuilderFor<NavTileAction>
    {
        [Required]
        [Display(Name = "Page Name")]
        public string PageName {get; set;}

        public NavTileActionBuilder()
        {

        }

        public NavTileActionBuilder(NavTileAction navTileAction)
        {
            PageName = navTileAction.PageName;
        }

        public ITileAction BuildTileAction()
        {
            return new NavTileAction(PageName);
        }
    }
}
