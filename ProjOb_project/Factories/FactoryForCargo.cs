using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjOb_project.Parsers;

namespace ProjOb_project.NewFolder
{
    // Class FactoryForCargo inherited from FactoryForParsable. Is used for creating instances of Cargo class.
    internal class FactoryForCargo : FactoryForParsable
    {
        // Overriden method from creating ItemParsable object, in this case object will be of Cargo class.
        public override ItemParsable CreateParsable(string[] parameters)
        {
            ulong id = ulong.Parse(parameters[0]);
            float weight = Parser.ParseStringWithDot2Float(parameters[1]);
            string code = parameters[2];
            string descreption = parameters[3];
            return new Cargo(id, weight, code, descreption);
        }
    }
}
