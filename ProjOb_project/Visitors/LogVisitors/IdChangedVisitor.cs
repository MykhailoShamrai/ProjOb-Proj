using ProjOb_project.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Visitors.Logs
{
    internal class IdChangedVisitor
    {
        public void visitSuccessfully(Airport airport, NetworkSourceSimulator.IDUpdateArgs args)
        {
            Logers.Logger.LogMessage($"{DateTime.Now.ToString("HH:mm:ss")}| Airport with Id {airport.Id} has changed Id to {args.NewObjectID}");
        }

        public void visitSuccessfully(Cargo cargo, NetworkSourceSimulator.IDUpdateArgs args)
        {
            Logers.Logger.LogMessage($"{DateTime.Now.ToString("HH:mm:ss")}| Cargo with Id {cargo.Id} has changed Id to {args.NewObjectID}");
        }

        public void visitSuccessfully(CargoPlane cargoPlane, NetworkSourceSimulator.IDUpdateArgs args)
        {
            Logers.Logger.LogMessage($"{DateTime.Now.ToString("HH:mm:ss")}| CargoPlane with Id {cargoPlane.Id} has changed Id to {args.NewObjectID}");
        }

        public void visitSuccessfully(Crew crew, NetworkSourceSimulator.IDUpdateArgs args)
        {
            Logers.Logger.LogMessage($"{DateTime.Now.ToString("HH:mm:ss")}| Crew with Id {crew.Id} has changed Id to {args.NewObjectID}");
        }

        public void visitSuccessfully(Flight flight, NetworkSourceSimulator.IDUpdateArgs args)
        {
            Logers.Logger.LogMessage($"{DateTime.Now.ToString("HH:mm:ss")}| Flight with Id {flight.Id} has changed Id to {args.NewObjectID}");
        }

        public void visitSuccessfully(Passanger passanger, NetworkSourceSimulator.IDUpdateArgs args)
        {
            Logers.Logger.LogMessage($"{DateTime.Now.ToString("HH:mm:ss")}| Passanger with Id {passanger.Id} has changed Id to {args.NewObjectID}");
        }

        public void visitSuccessfully(PassangerPlane passangerPlane, NetworkSourceSimulator.IDUpdateArgs args)
        {
            Logers.Logger.LogMessage($"{DateTime.Now.ToString("HH:mm:ss")}| PassangerPlane with Id {passangerPlane.Id} has changed Id to {args.NewObjectID}");
        }
        /// <summary>
        /// Visitors for errors
        /// </summary>
        public void visitError(Airport airport, NetworkSourceSimulator.IDUpdateArgs args)
        {
            Logers.Logger.LogMessage($"{DateTime.Now.ToString("HH:mm:ss")}| Airport with Id {airport.Id} can't change Id to {args.NewObjectID}, because such object is already added to database");
        }

        public void visitError(Cargo cargo, NetworkSourceSimulator.IDUpdateArgs args)
        {
            Logers.Logger.LogMessage($"{DateTime.Now.ToString("HH:mm:ss")}| Cargo with Id {cargo.Id} can't change Id to {args.NewObjectID}, because such object is already added to database");
        }

        public void visitError(CargoPlane cargoPlane, NetworkSourceSimulator.IDUpdateArgs args)
        {
            Logers.Logger.LogMessage($"{DateTime.Now.ToString("HH:mm:ss")}| CargoPlane with Id {cargoPlane.Id} can't change Id to {args.NewObjectID}, because such object is already added to database");
        }

        public void visitError(Crew crew, NetworkSourceSimulator.IDUpdateArgs args)
        {
            Logers.Logger.LogMessage($"{DateTime.Now.ToString("HH:mm:ss")}| Crew with Id {crew.Id} can't change Id to {args.NewObjectID}, because such object is already added to database");
        }

        public void visitError(Flight flight, NetworkSourceSimulator.IDUpdateArgs args)
        {
            Logers.Logger.LogMessage($"{DateTime.Now.ToString("HH:mm:ss")}| Flight with Id {flight.Id} can't change Id to {args.NewObjectID}, because such object is already added to database");
        }

        public void visitError(Passanger passanger, NetworkSourceSimulator.IDUpdateArgs args)
        {
            Logers.Logger.LogMessage($"{DateTime.Now.ToString("HH:mm:ss")}| Passanger with Id {passanger.Id} can't change Id to {args.NewObjectID}, because such object is already added to database");
        }

        public void visitError(PassangerPlane passangerPlane, NetworkSourceSimulator.IDUpdateArgs args)
        {
            Logers.Logger.LogMessage($"{DateTime.Now.ToString("HH:mm:ss")}| PassangerPlane with Id {passangerPlane.Id} can't change Id to {args.NewObjectID}, because such object is already added to database");
        }
    }
}