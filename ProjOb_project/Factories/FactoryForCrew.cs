using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjOb_project.Items;



namespace ProjOb_project.Factories
{
    // Class FactoryForCrew inherited from FactoryForParsable. Is used for creating instances of Crew class.
    internal class FactoryForCrew : FactoryForParsable
    { 
        // Overriden method from creating ItemParsable object, in this case object will be of Crew class.
        public override Crew CreateParsable(string[] parameters)
        {
            (ulong, string, ulong, string, string) personParams = ParseForPerson(parameters[0..5]);
            ushort practice = ushort.Parse(parameters[5]);
            string role = parameters[6];
            Crew tmp = new Crew(personParams.Item1, personParams.Item2, personParams.Item3, personParams.Item4, personParams.Item5, practice, role);
            Database.DictionaryForCrew.Add(personParams.Item1, tmp);
            return tmp;
        }
    }
}
