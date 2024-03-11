using NetworkSourceSimulator;
using ProjOb_project.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.LineReaders
{
    internal class AirportLineReader: BinaryLineReader
    {
        public override string[] ReadFieldsFromMessage(uint size, byte[] tab)
        {
            ushort currentOffset = OFFSET_SIZE;
            string[] fields = new string[Airport.FieldsCount];
            ulong Id = BitConverter.ToUInt64(tab, currentOffset);
            fields[0] = Id.ToString();
            currentOffset += sizeof(ulong);
            ushort nameLength = BitConverter.ToUInt16(tab, currentOffset);
            currentOffset += sizeof(ushort);
            fields[1] = Encoding.ASCII.GetString(tab, currentOffset, nameLength);
            currentOffset += nameLength;
            fields[2] = Encoding.ASCII.GetString(tab, currentOffset, 3).Trim('\0');
            currentOffset += 3;
            float longitude = BitConverter.ToSingle(tab, currentOffset);
            currentOffset += sizeof(float);
            fields[3] = longitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
            float latitude = BitConverter.ToSingle(tab, currentOffset);
            currentOffset += sizeof(float);
            fields[4] = latitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
            float amsl = BitConverter.ToSingle(tab, currentOffset);
            currentOffset += sizeof(float);
            fields[5] = amsl.ToString(System.Globalization.CultureInfo.InvariantCulture);
            fields[6] = Encoding.ASCII.GetString(tab, currentOffset, 3).Trim('\0');
            return fields;
        }
    }
}
