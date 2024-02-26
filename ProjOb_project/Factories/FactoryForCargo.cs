using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.NewFolder
{
    internal class FactoryForCargo : FactoryForParsable
    {
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
