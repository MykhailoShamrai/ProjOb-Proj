using ProjOb_project.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Visitors.Media
{
    internal class Television: IMediaVisitor
    {
        public string Name { get; set; }
        public Television(string name)
        { 
            Name = name;
        }

        public string Visit(Airport airport)
        {
            return $"<An image of {airport.Name} airport>";
        }

        public string Visit(CargoPlane plane)
        {
            return $"<An image of {plane.Serial} cargo plane>";
        }

        public string Visit(PassangerPlane plane)
        {
            return $"<An image of {plane.Serial} passenger plane>";
        }
    }
}
