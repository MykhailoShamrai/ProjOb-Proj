using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;

namespace ProjOb_project.Serializers
{
    // Class SerializerForJson for json serialization. Inherited from Serializer class
    internal class SerializerForJson : Serializer
    {
        // Overriden method which serialize collection with json serialization to file in path
        protected override void SerializeObjects(string path, IEnumerable<ItemParsable> collection)
        {
            string jsonString = JsonSerializer.Serialize(collection);
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(jsonString);
            }
        }
    }
}
