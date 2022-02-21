using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorDeck.Shared.ComponentModels.Tiles.Builders
{
    public class TileDefinitionBuilder
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Display priority 0 renders first")]
        public decimal Priority { get; set; } = 0;
        [Display(Name = "Width")]
        [Range(1, 5)]
        public int Width { get; set; } = 1;
        [Display(Name = "Height")]
        [Range(1, 5)]
        public int Height { get; set; } = 1;
        [Display(Name = "Togglable")]
        public bool Togglable { get; set; } = false;

        public TileDefinitionBuilder()
        {

        }

        public TileDefinitionBuilder(TileDefinition tileDefinition)
        {
            if(tileDefinition == null)
            {
                return;
            }
            Name = tileDefinition.Name;
            Priority = tileDefinition.Priority;
            Width = tileDefinition.Width;
            Height = tileDefinition.Height;
            Togglable = tileDefinition.Togglable;
        }

        public TileDefinition BuildTileDefinition(ITileAction tileAction, ITileDisplay tileDisplay, IServerEvent toggleEvent)
        {
            return new TileDefinition(tileAction, tileDisplay, Name, Priority, Togglable, toggleEvent, Width, Height);
        }
    }
}
