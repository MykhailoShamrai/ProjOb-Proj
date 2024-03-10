using ProjOb_project.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.LineReaders
{
    internal class PassangerPlaneLineReader : BinaryLineReader
    {
        public override string[] ReadFieldsFromMessage(uint size, byte[] tab)
        {
            ushort currentOffset = OFFSET_SIZE;
            string[] fields = new string[Passanger.FieldsCount];
            ulong Id = BitConverter.ToUInt64(tab, currentOffset);
            fields[0] = Id.ToString();
            currentOffset += sizeof(ulong);
            fields[1] = Encoding.ASCII.GetString(tab, currentOffset, 10);
            currentOffset += 10;
            fields[2] = Encoding.ASCII.GetString(tab, currentOffset, 3);
            currentOffset += 3;
            ushort modelLength = BitConverter.ToUInt16(tab, currentOffset);
            currentOffset += sizeof(ushort);
            fields[3] = Encoding.ASCII.GetString(tab, currentOffset, modelLength);
            currentOffset += modelLength;
            ushort firstClassSize = BitConverter.ToUInt16(tab, currentOffset);
            currentOffset += sizeof(ushort);
            fields[4] = firstClassSize.ToString();
            ushort businessClassSize = BitConverter.ToUInt16(tab, currentOffset);
            currentOffset += sizeof(ushort);
            fields[5] = businessClassSize.ToString();
            ushort economyClassSize = BitConverter.ToUInt16(tab, currentOffset);
            fields[6] = economyClassSize.ToString();
            return fields;
        }
    }
}
