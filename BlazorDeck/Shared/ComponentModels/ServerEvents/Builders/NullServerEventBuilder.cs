using System;
using System.Collections.Generic;
using System.Text;
using BlazorDeck.Shared.ComponentModels.Actions.Builders;

namespace BlazorDeck.Shared.ComponentModels.ServerEvents.Builders
{
    public class NullServerEventBuilder : IServerEventBuilder, IBuilderFor<NullServerEvent>
    {
        public NullServerEventBuilder()
        {

        }
        public NullServerEventBuilder(NullServerEvent orginal)
        {

        }
        public IServerEvent BuildServerEvent()
        {
            return new NullServerEvent();
        }
    }
}
