using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.NewFolder
{
    internal class FactoryForPassanger : FactoryForParsable
    {
        public override ItemParsable CreateParsable(string[] parameters)
        {
            (ulong, string, ulong, string, string) personParams = ParseForPerson(parameters[0..5]);
            string classType = parameters[5];
            ulong miles = ulong.Parse(parameters[6]);
            return new Passanger(personParams.Item1, personParams.Item2, personParams.Item3, personParams.Item4, personParams.Item5, classType, miles);
        }
    }
}
