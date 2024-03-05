using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.NewFolder
{
    // Class FactoryForPassanger inherited from FactoryForParsable. Is used for creating instances of Passanger class.
    internal class FactoryForPassanger : FactoryForParsable
    {
        static internal Dictionary<ulong, Passanger> DictionaryForPassanger = new Dictionary<ulong, Passanger>();
        // Overriden method from creating ItemParsable object, in this case object will be of Passanger class.
        public override ItemParsable CreateParsable(string[] parameters)
        {
            (ulong, string, ulong, string, string) personParams = ParseForPerson(parameters[0..5]);
            string classType = parameters[5];
            ulong miles = ulong.Parse(parameters[6]);
            return new Passanger(personParams.Item1, personParams.Item2, personParams.Item3, personParams.Item4, personParams.Item5, classType, miles);
        }
    }
}
