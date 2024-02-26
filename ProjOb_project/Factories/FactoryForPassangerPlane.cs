using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.NewFolder
{
    internal class FactoryForPassangerPlane : FactoryForParsable
    {
        public override ItemParsable CreateParsable(string[] parameters)
        {
            (ulong, string, string, string) passangerPlanePlaneParams = ParseForPlane(parameters[0..4]);
            ushort firstClassSize = ushort.Parse(parameters[4]);
            ushort businessClassSize = ushort.Parse(parameters[5]);
            ushort economyClassSize = ushort.Parse(parameters[6]);
            return new PassangerPlane(passangerPlanePlaneParams.Item1, passangerPlanePlaneParams.Item2, passangerPlanePlaneParams.Item3, passangerPlanePlaneParams.Item4, firstClassSize, businessClassSize, economyClassSize);
        }
    }
}
