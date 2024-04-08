using ProjOb_project.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Visitors.Creating
{
    /// <summary>
    /// Abstract class using visitor pattern for parsing ItemParsable objects from files
    /// </summary>

    internal interface ObjectCreatingVisitor
    {
        abstract public void visitAirport(Airport airport);
        abstract public void visitCargo(Cargo cargo);
        abstract public void visitCargoPlane(CargoPlane cargoPlane);
        abstract public void visitCrew(Crew crew);
        abstract public void visitFlight(Flight flight);
        abstract public void visitPassanger(Passanger passanger);
        abstract public void visitPassangerPlane(PassangerPlane passangerPlane);
    }
}
