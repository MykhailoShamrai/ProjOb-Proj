using Avalonia.Rendering;
using FlightTrackerGUI;
using ProjOb_project.GUI;
using ProjOb_project.Items;
using ProjOb_project.Parsers;
using ProjOb_project.Visitors;
using System.Reflection.Metadata;

namespace ProjOb_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ServerTCPHandler handler = ServerTCPHandler.getInstance();
            //ConsoleService service = ConsoleService.getInstance();
            //handler.Run();
            //service.ReadFromConsole();

            List<ItemParsable> items;
            items = Parser.ReadFromFile("example_data.ftr", new FtrParser(), new FtrParseVisitor());

            Thread thread = new Thread(()=>Runner.Run());
            thread.IsBackground = true;
            thread.Start();

            FlightGuiDataAdapter adapter = new FlightGuiDataAdapter();

            while(true) 
            {
                Thread.Sleep(1000);
                GUIHandler.ActualiseFlights(DateTime.Now);
                Runner.UpdateGUI(adapter);
            }
        }
        //public void Start()
       // {
        //    Runner.Run();
        //}
    }

}
