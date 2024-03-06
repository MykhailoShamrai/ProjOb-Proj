using System.Text.Json;
using ProjOb_project.Items;
using ProjOb_project.Parsers;
using ProjOb_project.Serializers;

namespace ProjOb_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ItemParsable> listOfObjects = Parser.ReadFromFile("example_data.ftr", new FtrParser());
            Serializer.SerializeToFile("objects.json", listOfObjects, new SerializerForJson());
        }
    }
}
