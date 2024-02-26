using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.NewFolder
{
    internal class FactoryForCrew : FactoryForParsable
    {
        public override ItemParsable CreateParsable(string[] parameters)
        {
            (ulong, string, ulong, string, string) personParams = ParseForPerson(parameters[0..5]);
            ushort practice = ushort.Parse(parameters[5]);
            string role = parameters[6];
            return new Crew(personParams.Item1, personParams.Item2, personParams.Item3, personParams.Item4, personParams.Item5, practice, role);
        }
    }
}
