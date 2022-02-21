using System.ComponentModel.DataAnnotations;

namespace BlazorDeck.Shared.ComponentModels.Actions.Builders
{
    public class PrimaryMonitorActionBuilder : ITileActionBuilder, IBuilderFor<PrimaryMonitorAction>
    {
        [Display(Name = "Monitor Id")]
        public int MonitorId { get; set; } = 0;

        public PrimaryMonitorActionBuilder()
        {

        }

        public PrimaryMonitorActionBuilder(PrimaryMonitorAction primaryMonitorAction)
        {
            MonitorId = int.Parse((string)primaryMonitorAction.Content);
        }

        public ITileAction BuildTileAction()
        {
            return new PrimaryMonitorAction((uint)MonitorId);
        }
    }
}
