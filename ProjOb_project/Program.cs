using ProjOb_project.Items;
using ProjOb_project.Parsers;
using ProjOb_project.Serializers;
using ProjOb_project.Visitors;

namespace ProjOb_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ItemParsable> listOfObjects = Parser.ReadFromFile("example_data.ftr", new FtrParser(), new FtrParseVisitor());
            Serializer.SerializeToFile("objects.json", listOfObjects, new SerializerForJson());

            //ServerTCPHandler handler = ServerTCPHandler.getInstance();
            //handler.Run();
            //Console.WriteLine("www");
            //while (Console.ReadLine() != "exit") {
            //}
            //Console.WriteLine("Main thread exits");
        }
    }
}
