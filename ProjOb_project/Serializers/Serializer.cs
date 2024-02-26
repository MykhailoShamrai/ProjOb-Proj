using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Serializers
{
    abstract internal class Serializer
    {
        abstract public void SerializeObjects(string path, IEnumerable<ItemParsable> collection);
        static public void SerializeToFile(string nameOfFile, IEnumerable<ItemParsable> collection, Serializer serializer)
        {
            string path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, nameOfFile);
            serializer.SerializeObjects(path, collection);
        }
    }
}
