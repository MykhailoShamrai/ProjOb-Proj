using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Serializers
{
    abstract internal class Serializer
    {
        // Abstract method for proper serialization. Takes absolute path to destination file and collection to serialize 
        abstract protected void SerializeObjects(string path, IEnumerable<ItemParsable> collection);

        // Static method which takes name of file to serialization or relative path in regard to Output directory, IEnumrable collection with ItemParsable elements for serialiyation and Serializer object
        // which depends on type of serialization. Method should serialize collection in second argument to file in first argument
        static public void SerializeToFile(string nameOfFile, IEnumerable<ItemParsable> collection, Serializer serializer)
        {
            string path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, nameOfFile);
            serializer.SerializeObjects(path, collection);
        }
    }
}
