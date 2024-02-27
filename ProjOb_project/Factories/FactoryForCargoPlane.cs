﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjOb_project.Parsers;

namespace ProjOb_project.NewFolder
{
    // Class FactoryForCargoPlane inherited from FactoryForParsable. Is used for creating instances of CargoPlane class.
    internal class FactoryForCargoPlane : FactoryForParsable
    {
        // Overriden method from creating ItemParsable object, in this case object will be of CargoPlane class.
        public override ItemParsable CreateParsable(string[] parameters)
        {
            (ulong, string, string, string) cargoPlaneParams = ParseForPlane(parameters[0..4]);
            float maxLoad = Parser.ParseStringWithDot2Float(parameters[4]);
            return new CargoPlane(cargoPlaneParams.Item1, cargoPlaneParams.Item2, cargoPlaneParams.Item3, cargoPlaneParams.Item4, maxLoad);
        }
    }
}
