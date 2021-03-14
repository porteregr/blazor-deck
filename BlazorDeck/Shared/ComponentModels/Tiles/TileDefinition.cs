namespace BlazorDeck.Shared.ComponentModels
{
    public class TileDefinition
    {
        public ITileAction Action { get; private set; }
        public ITileDisplay Display { get; private set; }
        public IServerEvent ToggleEvent { get; private set; }
        public string Name { get; private set; }
        public float Priority { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool Togglable { get; private set; }

        public TileDefinition(ITileAction action, ITileDisplay display, string name, float priority = 1, bool togglable = false, IServerEvent toggleEvent = null, int width = 1, int height = 1)
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
    }
}
