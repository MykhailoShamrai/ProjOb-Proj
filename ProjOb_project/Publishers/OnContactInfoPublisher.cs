﻿using ProjOb_project.Items.Listeners;
using ProjOb_project.Visitors.Log;
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
        private ContactChangedVisitor visitor = new ContactChangedVisitor();

        public void Subscribe(IListenerContact listener)
        {
            _listeners.Add(listener);
        }

        public void Notify(object sender, NetworkSourceSimulator.ContactInfoUpdateArgs args)
        {
            bool flag = false;
            foreach (var listener in _listeners)
            {
                if (listener.Id == args.ObjectID)
                {
                    listener.Update(args, visitor);
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                Logers.Logger.LogMessage($"{DateTime.Now.ToString("HH:mm:ss")}| There is no instance with Id {args.ObjectID}");
            }
        }
    }
}
