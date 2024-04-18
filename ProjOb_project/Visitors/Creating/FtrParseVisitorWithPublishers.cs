﻿using ProjOb_project.Items;
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
        }
        override public void visitCargo(Cargo cargo)
        {
            base.visitCargo(cargo);
        }
        override public void visitCargoPlane(CargoPlane cargoPlane)
        {
            base.visitCargoPlane(cargoPlane);
        }
        override public void visitCrew(Crew crew)
        {
            base.visitCrew(crew);
        }

        /// <summary>
        /// Reads from Flight object arrays with id's, and links objexts from Database to list with objects,
        /// where id is equal to flight parameters id (CrewId, LoadId)
        /// </summary>
        /// <param name="flight">Flight object, on which is required linking objects from database</param>
        override public void visitFlight(Flight flight)
        {
            base.visitFlight(flight);
        }
        override public void visitPassanger(Passanger passanger)
        {
            base.visitPassanger(passanger);
        }
        override public void visitPassangerPlane(PassangerPlane passangerPlane)
        {
            base.visitPassangerPlane(passangerPlane);
        }
    }
}