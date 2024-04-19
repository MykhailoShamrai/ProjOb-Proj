using ProjOb_project.Items;
using ProjOb_project.Publishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Visitors.Creating
{
    internal class FtrParseVisitorWithPublishers: FtrParseVisitor
    {
        private EventManager _eventManager;
        internal FtrParseVisitorWithPublishers(EventManager eventManager)
        {
            _eventManager = eventManager;
        }

        override public void visitAirport(Airport airport)
        {
            base.visitAirport(airport);
            _eventManager.onIDPublisher.Subscribe(airport.Id, airport);
        }
        override public void visitCargo(Cargo cargo)
        {
            base.visitCargo(cargo);
            _eventManager.onIDPublisher.Subscribe(cargo.Id, cargo);
        }
        override public void visitCargoPlane(CargoPlane cargoPlane)
        {
            base.visitCargoPlane(cargoPlane);
            _eventManager.onIDPublisher.Subscribe(cargoPlane.Id, cargoPlane);
        }
        override public void visitCrew(Crew crew)
        {
            base.visitCrew(crew);
            _eventManager.onIDPublisher.Subscribe(crew.Id, crew);
        }

        /// <summary>
        /// Reads from Flight object arrays with id's, and links objexts from Database to list with objects,
        /// where id is equal to flight parameters id (CrewId, LoadId)
        /// </summary>
        /// <param name="flight">Flight object, on which is required linking objects from database</param>
        override public void visitFlight(Flight flight)
        {
            base.visitFlight(flight);
            _eventManager.onIDPublisher.Subscribe(flight.Id, flight);
            _eventManager.onUpdatePositionPublisher.Subscribe(flight.Id, flight);
        }
        override public void visitPassanger(Passanger passanger)
        {
            base.visitPassanger(passanger);
            _eventManager.onIDPublisher.Subscribe(passanger.Id, passanger);
        }
        override public void visitPassangerPlane(PassangerPlane passangerPlane)
        {
            base.visitPassangerPlane(passangerPlane);
            _eventManager.onIDPublisher.Subscribe(passangerPlane.Id, passangerPlane);
        }
    }
}
