using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.NewFolder
{
    internal class FactoryForCargoPlane : FactoryForParsable
    {
        public override ItemParsable CreateParsable(string[] parameters)
        {
            (ulong, string, string, string) cargoPlaneParams = ParseForPlane(parameters[0..4]);
            float maxLoad = Parser.ParseStringWithDot2Float(parameters[4]);
            return new CargoPlane(cargoPlaneParams.Item1, cargoPlaneParams.Item2, cargoPlaneParams.Item3, cargoPlaneParams.Item4, maxLoad);
        }
    }
}
