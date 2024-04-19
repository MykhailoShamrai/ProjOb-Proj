using ProjOb_project.Items.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Publishers
{
    internal class OnUpdatePositionPublisher
    {
        private Dictionary<ulong, IListenerPosition> _listeners = new Dictionary<ulong, IListenerPosition>();

        public void Subscribe(ulong id, IListenerPosition listener)
        {
            _listeners.Add(id, listener);
        }

        public void Notify(object sender, NetworkSourceSimulator.PositionUpdateArgs args)
        {
            foreach (var listener in _listeners.Values)
            {
                if (listener.Id == args.ObjectID)
                {
                    listener.Update(args);
                    break;
                }
            }
        }   
    }
}
