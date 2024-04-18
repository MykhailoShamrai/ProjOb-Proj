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
        private Dictionary<int, IListenerID> _listeners = new Dictionary<int, IListenerID>();

        public void Subscribe(int id, IListenerID listener)
        {
            _listeners.Add(id, listener);
        }

        public void Notify(NetworkSourceSimulator.IDUpdateArgs args)
        {
            foreach (var listener in _listeners.Values)
            {
                listener.Update(args);
            }
        }
    }
}
