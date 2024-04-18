using ProjOb_project.Items.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Publishers
{
    internal class OnIDPublisher
    {
        private Dictionary<ulong, IListenerID> _listeners = new Dictionary<ulong, IListenerID>();

        public void Subscribe(ulong id, IListenerID listener)
        {
            _listeners.Add(id, listener);
        }

        public void Notify(object sender, NetworkSourceSimulator.IDUpdateArgs args)
        {
            foreach (var listener in _listeners.Values)
            {
                listener.Update(args);
            }
        }
    }
}
