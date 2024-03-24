using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjOb_project.Items;

namespace ProjOb_project.Factories
{
    // Class FactoryForPassanger inherited from FactoryForParsable. Is used for creating instances of Passanger class.
    internal class FactoryForPassanger : FactoryForParsable
    {
        // Overriden method from creating ItemParsable object, in this case object will be of Passanger class.
        public override Passanger CreateParsable(string[] parameters)
        {
            (ulong, string, ulong, string, string) personParams = ParseForPerson(parameters[0..5]);
            string classType = parameters[5];
            ulong miles = ulong.Parse(parameters[6]);
            Passanger tmp = new Passanger(personParams.Item1, personParams.Item2, personParams.Item3, personParams.Item4, personParams.Item5, classType, miles);
            lock (Database.DictionaryForPassangerLock)
            {
                Database.DictionaryForPassanger.Add(personParams.Item1, tmp);
            }
            return tmp;
        }
    }
}
