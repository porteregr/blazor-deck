namespace BlazorDeck.Shared.ComponentModels.Actions
{
    public class WOLTileAction : NativeTileAction
    {
        public string MacAddress { get; private set; }
        public WOLTileAction(string macAddress)
        {
            MacAddress = macAddress;
        }
    }
}
