using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;

namespace ProjOb_project
{
    internal class SerializerForJson: Serializer
    {
        public override void SerializeObjects(string path, IEnumerable<ItemParsable> collection)
        {
            string jsonString = JsonSerializer.Serialize(collection);
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(jsonString);
            }
        }
    }
}
