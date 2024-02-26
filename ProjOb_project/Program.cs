using System.Text.Json;

namespace ProjOb_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ItemParsable> listOfObjects = Parser.ReadFromFile("example_data.ftr", new FtrParser());
            Serializer.SerializeToFile("objects.json", listOfObjects, new SerializerForJson());

            // TO Później wyrzucić
            //////
            /////
            string path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, "objects.json");
            using (StreamReader sr = new StreamReader(path))
            {
                string tmp = sr.ReadToEnd();
                List<ItemParsable> listOfCopies = JsonSerializer.Deserialize<List<ItemParsable>>(tmp)!;
            }
        }
    }
}
