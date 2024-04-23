using ProjOb_project.Items.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Publishers
{
    internal class OnContactInfoPublisher
    {
        private List<IListenerContact> _listeners = new List<IListenerContact>();

        public void Subscribe(IListenerContact listener)
        {
            _listeners.Add(listener);
        }

        public void Notify(object sender, NetworkSourceSimulator.ContactInfoUpdateArgs args)
        {
            foreach (var listener in _listeners)
            {
                if (listener.Id == args.ObjectID)
                {
                    if (listener.Update(args) == 0)
                    {

                    } // place for logging
                    break;
                }
            }
        }
    }
}
