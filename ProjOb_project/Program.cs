using ProjOb_project.Items;
using ProjOb_project.Parsers;
using ProjOb_project.Serializers;
using ProjOb_project.Visitors;
using System.Diagnostics;

namespace ProjOb_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<ItemParsable> listOfObjects = Parser.ReadFromFile("example_data.ftr", new FtrParser(), new FtrParseVisitor());
            //Serializer.SerializeToFile("objects.json", listOfObjects, new SerializerForJson());
            Thread.CurrentThread.Name = "MAintThread";
            ServerTCPHandler handler = ServerTCPHandler.getInstance();
            handler.Run();
            string readLine;
            while (true)
            {
                readLine = Console.ReadLine()!;
                switch (readLine)
                {
                    case "exit":
                        return;
                    case "print":
                        handler.MakeASnapshot();
                        break;
                }
                
            }
            
        }
    }
}
