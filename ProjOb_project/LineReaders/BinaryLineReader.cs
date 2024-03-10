using NetworkSourceSimulator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.LineReaders
{

    abstract internal class BinaryLineReader
    {
        protected const ushort TYPENAME_SIZE = 3;
        protected const ushort LENGTH_SIZE = 4;
        protected const ushort OFFSET_SIZE = TYPENAME_SIZE + LENGTH_SIZE;
        static (string, uint) ReadSizeAndType(Message msg)
        {
            byte[] bytes = msg.MessageBytes;
            string type = Encoding.ASCII.GetString(bytes, 0, TYPENAME_SIZE);
            uint size = BitConverter.ToUInt32(bytes, TYPENAME_SIZE);
            return (type, size);
        }
        abstract public string[] ReadFieldsFromMessage(uint size, byte[] tab);
    }
}
