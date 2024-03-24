using ProjOb_project.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.LineReaders
{
    internal class CargoPlaneLineReader: BinaryLineReader
    {
        static private int FieldsCount = 5;
        /// <summary>
        /// Overriden method for returning sting array for CargoPlane object with parameters in good order for FactoryMethod.
        /// </summary>
        /// <param name="size">Size of message</param>
        /// <param name="tab">Array of bits of the message</param>
        /// <returns></returns>
        public override string[] ReadFieldsFromMessage(uint size, byte[] tab)
        {
            ushort currentOffset = OFFSET_SIZE;
            string[] fields = new string[FieldsCount];
            ulong Id = BitConverter.ToUInt64(tab, currentOffset);
            currentOffset += sizeof(ulong);
            fields[0] = Id.ToString();
            fields[1] = Encoding.ASCII.GetString(tab, currentOffset, 10).Trim('\0');
            currentOffset += 10;
            fields[2] = Encoding.ASCII.GetString(tab, currentOffset, 3).Trim('\0');
            currentOffset += 3;
            ushort modelLenght = BitConverter.ToUInt16(tab, currentOffset);
            currentOffset += sizeof(ushort);
            fields[3] = Encoding.ASCII.GetString(tab, currentOffset, modelLenght).Trim('\0');
            currentOffset += modelLenght;
            float maxLoad = BitConverter.ToSingle(tab, currentOffset);
            fields[4] = maxLoad.ToString();
            return fields;
        }
    }
}
