using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Items.Listeners
{
    internal interface IListenerID
    {
        public void Update(NetworkSourceSimulator.IDUpdateArgs args);
    }
}
