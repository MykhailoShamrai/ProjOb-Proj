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
        private List<IListenerID> _listeners = new List<IListenerID>();

        public void Subscribe(IListenerID listener)
        {
            _listeners.Add(listener);
        }

        public void Notify(object sender, NetworkSourceSimulator.IDUpdateArgs args)
        {
            foreach (var listener in _listeners)
            {
                if (listener.Id == args.ObjectID)
                {
                    if (listener.Update(args) == 0)
                    { }
                    break;
                }   
            }
        }
    }
}
