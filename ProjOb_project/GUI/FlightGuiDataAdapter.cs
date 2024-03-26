using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Mapsui.Projections;
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
            Airport origin = flight.OriginAirport!;
            Airport target = flight.TargetAirport!;
            DateTime takeOffTime = DateTime.Parse(flight.TakeOffTime);
            DateTime landingTime = DateTime.Parse(flight.LandingTime);
            DateTime now = DateTime.Now;                  
            
            double currentSeconds = (now - takeOffTime).TotalSeconds;
            double amountOfSeconds = (landingTime - takeOffTime).TotalSeconds;

            latitudeDif = target.Latitude - origin.Latitude;
            longtitudeDif = target.Longtitude - origin.Longtitude;
            double curLong = MathFunctions.LinearInterpolation(0, amountOfSeconds, origin.Longtitude, target.Longtitude, currentSeconds);
            double curLat = MathFunctions.LinearInterpolation(0, amountOfSeconds, origin.Latitude, target.Latitude, currentSeconds);
            flight.Latitude = (float)curLat;
            flight.Longtitude = (float)curLong;
            return new WorldPosition(curLat, curLong);
        }

        public override double GetRotation(int index)
        {
            Flight flight = flights[index];
            Airport origin = flight.OriginAirport!;
            Airport target = flight.TargetAirport!;
            (double originX, double originY) = SphericalMercator.FromLonLat(origin.Longtitude, origin.Latitude);
            (double targetX, double targetY) = SphericalMercator.FromLonLat(target.Longtitude, target.Latitude);
            double distanceX = targetX - originX;
            double distanceY = targetY - originY;
            return Math.Atan2(distanceX, distanceY);
        }
    }
}
