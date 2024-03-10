using ProjOb_project.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.LineReaders
{
    internal class CargoLineReader: BinaryLineReader
    {
        public override string[] ReadFieldsFromMessage(uint size, byte[] tab)
        {
            ushort currentOffset = OFFSET_SIZE;
            string[] fields = new string[Cargo.FieldsCount];
            ulong Id = BitConverter.ToUInt64(tab, currentOffset);
            currentOffset += sizeof(ulong);
            fields[0] = Id.ToString();
            float weight = BitConverter.ToSingle(tab, currentOffset);
            currentOffset += sizeof(float);
            fields[1] = weight.ToString(System.Globalization.CultureInfo.InvariantCulture);
            fields[2] = Encoding.ASCII.GetString(tab, currentOffset, 6);
            currentOffset += 6;
            ushort descLength = BitConverter.ToUInt16(tab, currentOffset);
            currentOffset += sizeof(ushort);
            fields[3] = Encoding.ASCII.GetString(tab, currentOffset, descLength);
            return fields;
        }
    }
}
