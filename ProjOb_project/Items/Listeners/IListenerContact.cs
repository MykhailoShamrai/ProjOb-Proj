using ProjOb_project.Publishers;
using ProjOb_project.Visitors.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Items.Listeners
{
    internal interface IListenerContact: ItemParsable
    {
        public int Update(NetworkSourceSimulator.ContactInfoUpdateArgs args, ContactChangedVisitor visitor);
    }
}
