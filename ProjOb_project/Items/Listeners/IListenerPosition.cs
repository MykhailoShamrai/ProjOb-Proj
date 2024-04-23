using ProjOb_project.Visitors.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Items.Listeners
{
    internal interface IListenerPosition: ItemParsable
    {
        public int Update(NetworkSourceSimulator.PositionUpdateArgs args, PositionChangedVisitor visitor);
    }
}
