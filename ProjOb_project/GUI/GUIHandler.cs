using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FlightTrackerGUI;
using ProjOb_project.Items;

namespace ProjOb_project.GUI
{
    static internal class GUIHandler
    {
        /// <summary>
        /// Thread for running GUI window.
        /// </summary>
        static private Thread _thread_for_GUIRunning;

        /// <summary>
        /// Thread for updating GUI and list of actual flights.
        /// </summary>
        static private Thread _thread_for_GUIUpdating;

        /// <summary>
        /// Static constructor for adding parameters for thread field.
        /// </summary>
        static GUIHandler()
        {
            _thread_for_GUIRunning = new Thread(Runner.Run);
            _thread_for_GUIRunning.IsBackground = true;
            _thread_for_GUIUpdating = new Thread(UpdateGUI);
            _thread_for_GUIUpdating.IsBackground = true;
        }

        /// <summary>
        /// Method for actualization Flights, and adding to list of actual flights Flight objects that take place at this time.
        /// </summary>
        /// <param name="timeOfActualisation">DateTime parameter against which is checked whether flights from Database are actual or not</param>
        static private void ActualiseFlights(DateTime timeOfActualisation)
        {
            DateTime timeOfTakeOff;
            DateTime timeOfLanding;
            lock (Database.CurrentFlightsListLock)
            {
                Database.CurrentFlightsList.Clear();
                Database.CurrentFlightsList.TrimExcess();
                lock (Database.DictionaryForFlight)
                {
                    foreach (Flight flight in Database.DictionaryForFlight.Values)
                    {
                        timeOfTakeOff = DateTime.Parse(flight.TakeOffTime);
                        timeOfLanding = DateTime.Parse(flight.LandingTime);
                        if (IsActualFlight(timeOfActualisation, timeOfTakeOff, timeOfLanding))
                        {
                            flight.IsCUrrentlyOnAir = true;
                            Database.CurrentFlightsList.Add(flight);
                        }
                        else
                        {
                            flight.IsCUrrentlyOnAir = false;
                            Database.CurrentFlightsList.Remove(flight);
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

        /// <summary>
        /// Method for using by a thread. This method must for each second actualize a list of flights and update gui state by calling
        /// Runner.UpdateGUI with object of class FlightGuiDataAdapter
        /// </summary>
        static private void UpdateGUI()
        {
            while (true)
            {
                FlightGuiDataAdapter adapter = new FlightGuiDataAdapter();
                Thread.Sleep(1000);
                GUIHandler.ActualiseFlights(DateTime.Now);
                Runner.UpdateGUI(adapter);
            }
        }

        /// <summary>
        /// Starting up a thread with starting a GUI function.
        /// </summary>
        static public void StartGUI()
        {
            _thread_for_GUIRunning.Start();
        }

        /// <summary>
        /// Starting up a thread with updating of GUI function.
        /// </summary>
        static public void StartUpdatingGUI()
        {
            _thread_for_GUIUpdating.Start();
        }
    }
}
