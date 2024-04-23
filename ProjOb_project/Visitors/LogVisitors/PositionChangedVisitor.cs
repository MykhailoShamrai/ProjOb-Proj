using ProjOb_project.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Visitors.Log
{
    internal class PositionChangedVisitor
    {
        public void visitSuccessfully(Flight flight, NetworkSourceSimulator.PositionUpdateArgs args)
        {
            Logers.Logger.LogMessage($"{DateTime.Now.ToString("HH:mm:ss")}| Flight with Id {flight.Id} which had ASML {flight.Amsl}, Latitude {flight.Latitude}, Longtitude {flight.Longtitude} changed coordinates to {args.AMSL}, {args.Latitude}, {args.Longitude}");
        }
        public void visitError(Flight flight, NetworkSourceSimulator.PositionUpdateArgs args)
        {
            Logers.Logger.LogMessage($"{DateTime.Now.ToString("HH:mm:ss")}| Flight with Id changed {flight.Id} isn't on air");
        }
    }
}
