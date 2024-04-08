using ProjOb_project.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Visitors.Media
{
    internal class Radio: IMediaVisitor
    {
        public string Name { get; set; }
        public Radio(string name)
        {
            Name = name;
        }

        public string Visit(Airport airport)
        {
            return $"Reporting for {Name}, Ladies and gentelmen, we are at the {airport.Name} airport.";
        }

        public string Visit(CargoPlane plane)
        {
            return $"Reporting for {Name}, Ladies and gentelmen, we are seeing the {plane.Serial} aircraft fly above us";
        }

        public string Visit(PassangerPlane plane)
        {
            return $"Reporting for {Name}, Ladies and gentelmen, we’ve just witnessed {plane.Serial} take off.";
        }
    }
}
