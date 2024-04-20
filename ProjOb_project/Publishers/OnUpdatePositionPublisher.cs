﻿using ProjOb_project.Items.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Publishers
{
    internal class OnUpdatePositionPublisher
    {
        private List<IListenerPosition> _listeners = new List<IListenerPosition>();

        public void Subscribe(IListenerPosition listener)
        {
            _listeners.Add(listener);
        }

        public void Notify(object sender, NetworkSourceSimulator.PositionUpdateArgs args)
        {
            foreach (var listener in _listeners)
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
