using ProjOb_project.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Visitors.Media
{
    internal class Newspaper: MediaVisitor
    {
        public string Name { get; set; }
        public Newspaper(string name)
        {
            Name = name;
        }

        public string Visit(Airport airport)
        {
            return $"{Name} - A report from the {airport.Name} airport, {airport.Country}.";
        }

        public string Visit(CargoPlane plane)
        {
            return $"{Name} - An interview with the crew of {plane.Serial}.";
        }

        public string Visit(PassangerPlane plane)
        {
            return $"{Name} - Breaking news! {plane.Model} naircraft loses EASA fails certification after inspection of {plane.Serial}.";
        }
    }
}
