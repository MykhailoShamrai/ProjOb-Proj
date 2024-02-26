using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.NewFolder
{
    internal class FactoryForFlight : FactoryForParsable
    {
        public override ItemParsable CreateParsable(string[] parameters)
        {
            ulong id = ulong.Parse(parameters[0]);
            ulong originAsId = ulong.Parse(parameters[1]);
            ulong targetAsId = ulong.Parse(parameters[2]);
            string takeOffTime = parameters[3];
            string landingTime = parameters[4];
            (float, float, float) coordinates = ParseCoordinates(parameters[5..8]);
            ulong planeId = ulong.Parse(parameters[8]);
            ulong[] crewAsId = Parser.ParseParam2UIntTab(parameters[9]);
            ulong[] loadAsId = Parser.ParseParam2UIntTab(parameters[10]);
            return new Flight(id, originAsId, targetAsId, takeOffTime, landingTime, coordinates.Item1, coordinates.Item2, coordinates.Item3, planeId, crewAsId, loadAsId);
        }
    }
}
