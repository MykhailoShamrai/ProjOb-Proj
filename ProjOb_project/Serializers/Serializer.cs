using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjOb_project.Items;

namespace ProjOb_project.Serializers
{
    abstract internal class Serializer
    {
        // Abstract method for proper serialization. Takes absolute path to destination file and collection to serialize 
        abstract protected void SerializeObjects(string path, IEnumerable<ItemParsable> collection);

        // Static method which takes name of file to serialization, IEnumrable collection with ItemParsable elements for serialiyation and Serializer object
        // which depends on type of serialization. Method should serialize collection in second argument to file in first argument
        static public void SerializeToFile(string nameOfFile, IEnumerable<ItemParsable> collection, Serializer serializer) // zmienic
        {
            serializer.SerializeObjects(nameOfFile, collection);
        }
    }
}
