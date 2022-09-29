using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BlazorDeck.Shared.ComponentModels.Actions.Builders;

namespace BlazorDeck.Shared.ComponentModels.ServerEvents.Builders
{
    public class ActiveWindowEventBuilder: IServerEventBuilder, IBuilderFor<ActiveWindowEvent>
    {
        [Required]
        [Display(Name = "Window Name")]
        public string WindowName { get; set; }
        public ActiveWindowEventBuilder()
        {

        }
        public ActiveWindowEventBuilder(ActiveWindowEvent original)
        {
            WindowName = original.WindowName;
        }

        public IServerEvent BuildServerEvent()
        {
            return new ActiveWindowEvent(WindowName);
        }
    }
}
