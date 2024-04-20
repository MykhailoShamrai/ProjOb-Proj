using ProjOb_project.Items;
using ProjOb_project.Items.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Publishers
{
    internal class EventManager
    {
        public OnIDPublisher OnIDPublisher = new OnIDPublisher();
        public OnUpdatePositionPublisher OnUpdatePositionPublisher = new OnUpdatePositionPublisher();
        public OnContactInfoPublisher OnContactInfoPublisher = new OnContactInfoPublisher();
    }
}
