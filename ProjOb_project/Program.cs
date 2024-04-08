using Avalonia.Rendering;
using FlightTrackerGUI;
using ProjOb_project.GUI;
using ProjOb_project.Items;
using ProjOb_project.Parsers;
using ProjOb_project.Visitors;
using System.Reflection.Metadata;
using ProjOb_project.TCPServer;
using ProjOb_project.Visitors.Creating;

namespace ProjOb_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleService cs = ConsoleService.getInstance();
            List<ItemParsable> items;
            items = Parser.ReadFromFile("example_data.ftr", new FtrParser(), new FtrParseVisitor());
            ServerTCPHandler handler = ServerTCPHandler.getInstance();

            GUIHandler.StartGUI();
            GUIHandler.StartUpdatingGUI();

            cs.ReadFromConsole();
        }
    }

}
