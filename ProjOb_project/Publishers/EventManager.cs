using ProjOb_project.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Publishers
{
    internal class EventManager
    {
        public enum EventTypes
        {
            OnIDUpdate,
            OnPostionUpdate,
            OnContactInfoUpdate
        }

        /// <summary>
        /// xddd Dictionary of dictionaries for subscribers.
        /// </summary>
        public Dictionary<EventTypes, AbstractPublisher> EventTypePublisher = new Dictionary<EventTypes, AbstractPublisher>();

        public EventManager()
        {
            EventTypePublisher.Add(EventTypes.OnIDUpdate, new IDChangePublisher());
        }
        

        //private void notify(EventTypes type, )

    }
}
