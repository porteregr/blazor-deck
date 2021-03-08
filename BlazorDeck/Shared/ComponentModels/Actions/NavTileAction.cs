namespace BlazorDeck.Shared.ComponentModels
{
    public class NavTileAction : ITileAction
    {
        public string PageName { get; private set; }

        public NavTileAction(string pageName)
        {
            PageName = pageName;
        }
    }
}
