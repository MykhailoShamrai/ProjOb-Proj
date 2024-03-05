using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.NewFolder
{
    // Class FactoryForCrew inherited from FactoryForParsable. Is used for creating instances of Crew class.
    internal class FactoryForCrew : FactoryForParsable
    {
        static internal Dictionary<ulong, Crew> DictionaryForCrew = new Dictionary<ulong, Crew>();

        // Overriden method from creating ItemParsable object, in this case object will be of Crew class.
        public override ItemParsable CreateParsable(string[] parameters)
        {
            (ulong, string, ulong, string, string) personParams = ParseForPerson(parameters[0..5]);
            ushort practice = ushort.Parse(parameters[5]);
            string role = parameters[6];
            Crew tmp = new Crew(personParams.Item1, personParams.Item2, personParams.Item3, personParams.Item4, personParams.Item5, practice, role);
            DictionaryForCrew.Add(personParams.Item1, tmp);
            return tmp;
        }
    }
}
