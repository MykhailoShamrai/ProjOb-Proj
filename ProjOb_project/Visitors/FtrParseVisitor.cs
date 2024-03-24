﻿using ProjOb_project.Items;

namespace ProjOb_project.Visitors
{

    /// <summary>
    /// Class of visitor for parsing ItemParsable object, while reading from ftr files
    /// </summary>

    internal class FtrParseVisitor : Visitor
    {
        public override void visitAirport(Airport airport)
        {
            return;
        }
        public override void visitCargo(Cargo cargo)
        {
            return;
        }
        public override void visitCargoPlane(CargoPlane cargoPlane)
        {
            return;
        }
        public override void visitCrew(Crew crew)
        {
            return;
        }

        /// <summary>
        /// Reads from Flight object arrays with id's, and links objexts from Database to list with objects,
        /// where id is equal to flight parameters id (CrewId, LoadId)
        /// </summary>
        /// <param name="flight">Flight object, on which is required linking objects from database</param>
        public override void visitFlight(Flight flight)
        {
            lock(Database.DictionaryForCrewLock)
            {
                foreach (ulong crewId in flight.CrewAsId)
                {
                    if (Database.DictionaryForCrew.ContainsKey(crewId))
                        flight.CrewList.Add(Database.DictionaryForCrew[crewId]);
                }
            }
            lock (Database.DictionaryForPassangerPlaneLock) lock (Database.DictionaryForCargoPlaneLock)
            { 
                if (Database.DictionaryForPassangerPlane.ContainsKey(flight.PlaneAsId))
                {
                    flight.Plane = Database.DictionaryForPassangerPlane[flight.PlaneAsId];
                    lock (Database.DictionaryForPassangerLock)
                    {
                        foreach (ulong loadId in flight.LoadAsId)
                        {
                            if (Database.DictionaryForPassanger.ContainsKey(loadId))
                            {
                                flight.LoadList.Add(Database.DictionaryForPassanger[loadId]);
                            }
                        }
                    }
                }
                else if (Database.DictionaryForCargoPlane.ContainsKey(flight.PlaneAsId))
                {
                    flight.Plane = Database.DictionaryForCargoPlane[flight.PlaneAsId];
                    lock(Database.DictionaryForCargoLock)
                    { 
                        foreach (ulong loadId in flight.LoadAsId)
                        {
                            if (Database.DictionaryForCargo.ContainsKey(loadId))
                            {
                                flight.LoadList.Add(Database.DictionaryForCargo[loadId]);
                            }
                        }
                    }
                }
            }
            lock (Database.DictionaryForAirportLock)
            {
                if (Database.DictionaryForAirport.ContainsKey(flight.TargetAsId))
                {
                    flight.TargetAirport = Database.DictionaryForAirport[flight.TargetAsId];
                }
                if (Database.DictionaryForAirport.ContainsKey(flight.OriginAsId))
                {
                    flight.OriginAirport = Database.DictionaryForAirport[flight.OriginAsId];
                }
            }
        }
        public override void visitPassanger(Passanger passanger)
        {
            return;
        }
        public override void visitPassangerPlane(PassangerPlane passangerPlane)
        {
            return;
        }
    }
}
