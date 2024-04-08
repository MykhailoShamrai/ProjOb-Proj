using ProjOb_project.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Visitors.Media
{
    internal interface MediaVisitor
    {
        public string Name { get; set; }

        public abstract string Visit(Airport airport);
        public abstract string Visit(PassangerPlane plane);
        public abstract string Visit(CargoPlane plane);
    }
}
