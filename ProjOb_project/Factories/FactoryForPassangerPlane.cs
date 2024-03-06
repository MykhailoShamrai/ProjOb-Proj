using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjOb_project.Items;

namespace ProjOb_project.NewFolder
{
    // Class FactoryForPassangerPlane inherited from FactoryForParsable. Is used for creating instances of PassangerPlane class.
    internal class FactoryForPassangerPlane : FactoryForParsable
    {
        static internal Dictionary<ulong, PassangerPlane> DictionaryForPassangerPlane = new Dictionary<ulong, PassangerPlane>();
        // Overriden method from creating ItemParsable object, in this case object will be of PassangerPlane class.
        public override ItemParsable CreateParsable(string[] parameters)
        {
            (ulong, string, string, string) passangerPlanePlaneParams = ParseForPlane(parameters[0..4]);
            ushort firstClassSize = ushort.Parse(parameters[4]);
            ushort businessClassSize = ushort.Parse(parameters[5]);
            ushort economyClassSize = ushort.Parse(parameters[6]);
            PassangerPlane tmp = new PassangerPlane(passangerPlanePlaneParams.Item1, passangerPlanePlaneParams.Item2, passangerPlanePlaneParams.Item3, passangerPlanePlaneParams.Item4, firstClassSize, businessClassSize, economyClassSize);
            DictionaryForPassangerPlane.Add(passangerPlanePlaneParams.Item1, tmp);
            return tmp;
        }
    }
}
