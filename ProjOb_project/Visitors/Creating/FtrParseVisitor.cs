using ProjOb_project.Items;
using System;
using System.Data;

namespace ProjOb_project.Visitors.Creating
{

    /// <summary>
    /// Class of visitor for parsing ItemParsable object, while reading from ftr files
    /// </summary>

    internal class FtrParseVisitor : ObjectCreatingVisitor
    {
        virtual public void visitAirport(Airport airport)
        {
            return;
        }
        virtual public void visitCargo(Cargo cargo)
        {
            return;
        }
        virtual public void visitCargoPlane(CargoPlane cargoPlane)
        {
            return;
        }
        virtual public void visitCrew(Crew crew)
        {
            return;
        }

        /// <summary>
        /// Reads from Flight object arrays with id's, and links objexts from Database to list with objects,
        /// where id is equal to flight parameters id (CrewId, LoadId)
        /// </summary>
        /// <param name="flight">Flight object, on which is required linking objects from database</param>
        virtual public void visitFlight(Flight flight)
        {
            lock (Database.DictionaryForCrewLock)
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
                        lock (Database.DictionaryForCargoLock)
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
                int flag = 0;
                if (Database.DictionaryForAirport.ContainsKey(flight.TargetAsId))
                {
                    flight.TargetAirport = Database.DictionaryForAirport[flight.TargetAsId];
                    flag++;
                }
                if (Database.DictionaryForAirport.ContainsKey(flight.OriginAsId))
                {
                    flight.OriginAirport = Database.DictionaryForAirport[flight.OriginAsId];
                    flag++;
                }
                if (flag == 2)
                {
                    double latitudeDif;
                    double longtitudeDif;
                    DateTime takeOffTime = DateTime.Parse(flight.TakeOffTime);
                    DateTime landingTime = DateTime.Parse(flight.LandingTime);

                    latitudeDif = flight.TargetAirport!.Latitude - flight.OriginAirport!.Latitude;
                    longtitudeDif = flight.TargetAirport!.Longtitude - flight.OriginAirport!.Longtitude;

                    if (takeOffTime < landingTime)
                    {
                        flight.LatitudeDif = latitudeDif/(landingTime - takeOffTime).TotalSeconds;
                        flight.LongtitudeDif = longtitudeDif/(landingTime - takeOffTime).TotalSeconds;
                    }
                }
            }
        }
        virtual public void visitPassanger(Passanger passanger)
        {
            return;
        }
        virtual public void visitPassangerPlane(PassangerPlane passangerPlane)
        {
            return;
        }
    }
}
