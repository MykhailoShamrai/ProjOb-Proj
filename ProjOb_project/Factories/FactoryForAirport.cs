using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.NewFolder
{
    internal class FactoryForAirport : FactoryForParsable
    {
        public override ItemParsable CreateParsable(string[] parameters)
        {
            ulong id = ulong.Parse(parameters[0]);
            string name = parameters[1];
            string code = parameters[2];
            (float, float, float) coordinates = ParseCoordinates(parameters[3..6]);
            string countryIso = parameters[6];
            return new Airport(id, name, code, coordinates.Item1, coordinates.Item2, coordinates.Item3, countryIso);
        }
    }
}
