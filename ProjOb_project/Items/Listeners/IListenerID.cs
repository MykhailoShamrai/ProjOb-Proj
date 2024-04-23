using ProjOb_project.Visitors.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Items.Listeners
{
    internal interface IListenerID: ItemParsable
    {
        public int Update(NetworkSourceSimulator.IDUpdateArgs args, IdChangedVisitor visitor);
    }
}
