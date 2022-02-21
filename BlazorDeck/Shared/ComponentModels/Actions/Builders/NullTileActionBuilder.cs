using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDeck.Shared.ComponentModels.Actions.Builders
{
    public class NullTileActionBuilder: ITileActionBuilder, IBuilderFor<DumbTileAction>
    {
        public NullTileActionBuilder()
        {

        }
        public NullTileActionBuilder(DumbTileAction dumbTileAction)
        {

        }
        public ITileAction BuildTileAction()
        {
            return new DumbTileAction();
        }
    }
}
