using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Mapsui.Providers.Wfs.Utilities;
using ProjOb_project.Items;

namespace ProjOb_project.GUI
{
    internal class FlightGuiDataAdapter : FlightsGUIData
    {
        private List<Flight> flights = Database.CurrentFlightsList;
        public override int GetFlightsCount()
        {
            return flights.Count;
        }

        public override ulong GetID(int index)
        {
            return flights[index].Id;
        }

        public override WorldPosition GetPosition(int index)
        {
            double latitudeDif;
            double longtitudeDif;
            Flight flight = flights[index];
            DateTime takeOffTime = DateTime.Parse(flight.TakeOffTime);
            DateTime landingTime = DateTime.Parse(flight.LandingTime);
            DateTime now = DateTime.Now;                  
            double currentSeconds = (now - takeOffTime).TotalSeconds;
            double amountOfSeconds = (landingTime - takeOffTime).TotalSeconds;
            latitudeDif = flight.TargetAirport!.Latitude - flight.OriginAirport!.Latitude;
            longtitudeDif = flight.TargetAirport!.Longtitude - flight.OriginAirport!.Longtitude;
            double curLong = (flight.OriginAirport.Longtitude * (amountOfSeconds - currentSeconds) + flight.TargetAirport.Longtitude * (currentSeconds)) / amountOfSeconds;
            double curLat = (flight.OriginAirport.Latitude * (amountOfSeconds - currentSeconds) + flight.TargetAirport.Latitude * (currentSeconds)) / amountOfSeconds;
            return new WorldPosition(curLat, curLong);
        }

        public override double GetRotation(int index)
        {
            return 0;
        }
    }
}
