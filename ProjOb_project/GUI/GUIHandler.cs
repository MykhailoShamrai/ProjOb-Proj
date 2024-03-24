using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjOb_project.Items;

namespace ProjOb_project.GUI
{
    internal class GUIHandler
    {
        /// <summary>
        /// Method for actualization Flights, and adding to list of actual flights Flight objects that take place at this time.
        /// </summary>
        /// <param name="timeOfActualisation">DateTime parameter against which is checked whether flights from Database are actual or not</param>
        static public void ActualiseFlights(DateTime timeOfActualisation)
        {
            DateTime timeOfTakeOff;
            DateTime timeOfLanding;
            lock (Database.CurrentFlightsListLock)
            {
                Database.CurrentFlightsList.Clear();
                lock (Database.DictionaryForFlightLock)
                {
                    foreach (Flight flight in Database.DictionaryForFlight.Values)
                    {
                        timeOfTakeOff = DateTime.Parse(flight.TakeOffTime);
                        timeOfLanding = DateTime.Parse(flight.LandingTime);
                        if (IsActualFlight(timeOfActualisation, timeOfTakeOff, timeOfLanding))
                        {
                            Database.CurrentFlightsList.Add(flight);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Private method for checking if actual time is in boundaries of takeOff time and landing time of a plane.
        /// </summary>
        /// <param name="timeOfActualization">Actual time for checking</param>
        /// <param name="timeOfTakeOff">Time of taking off a plane</param>
        /// <param name="timeOfLanding">Time of landing of a plane</param>
        /// <returns></returns>
        static private bool IsActualFlight(DateTime timeOfActualization, DateTime timeOfTakeOff, DateTime timeOfLanding)
        {
            bool thisDay = false;

            thisDay = DateTime.Compare(timeOfTakeOff, timeOfActualization) <= 0 && DateTime.Compare(timeOfActualization, timeOfLanding) <= 0;

            return thisDay;
        }
    }
}
