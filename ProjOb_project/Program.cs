using Avalonia.Rendering;
using FlightTrackerGUI;
using ProjOb_project.GUI;
using ProjOb_project.Items;
using ProjOb_project.Parsers;
using ProjOb_project.Visitors;
using System.Reflection.Metadata;
using ProjOb_project.TCPServer;
using ProjOb_project.Visitors.Creating;
using ProjOb_project.Publishers;

namespace ProjOb_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleService cs = ConsoleService.getInstance();
            List<ItemParsable> items;
            EventManager events = new EventManager();

            items = Parser.ReadFromFile("example_data.ftr", new FtrParser(), new FtrParseVisitorWithPublishers(events));

            ServerTCPHandler handler = ServerTCPHandler.getInstance(events);
            handler.Run();

            GUIHandler.StartGUI();
            GUIHandler.StartUpdatingGUI();

            cs.ReadFromConsole();
        }
    }

}
