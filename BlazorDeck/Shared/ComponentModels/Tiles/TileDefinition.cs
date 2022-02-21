namespace BlazorDeck.Shared.ComponentModels
{
    public class TileDefinition
    {
        public ITileAction Action { get; protected set; }
        public ITileDisplay Display { get; protected set; }
        public IServerEvent ToggleEvent { get; protected set; }
        public string Name { get; protected set; }
        public decimal Priority { get; protected set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public bool Togglable { get; protected set; }

        public TileDefinition(ITileAction action, ITileDisplay display, string name, decimal priority = 1, bool togglable = false, IServerEvent toggleEvent = null, int width = 1, int height = 1)
        {
            Action = action;
            Display = display;
            Name = name;
            Priority = priority;
            Width = width;
            Height = height;
            Togglable = togglable;
            ToggleEvent = toggleEvent;
        }
        protected TileDefinition()
        {

        }
    }
}
