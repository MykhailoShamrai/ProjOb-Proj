using ProjOb_project.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.LineReaders
{
    internal class CrewLineReader: BinaryLineReader
    {
        public override string[] ReadFieldsFromMessage(uint size, byte[] tab)
        {
            ushort currentOffset = OFFSET_SIZE;
            string[] fields = new string[Crew.FieldsCount];
            ulong Id = BitConverter.ToUInt64(tab, currentOffset);
            currentOffset += sizeof(ulong);
            fields[0] = Id.ToString();
            ushort nameLength = BitConverter.ToUInt16(tab, currentOffset);
            currentOffset += sizeof(ushort);
            fields[1] = Encoding.ASCII.GetString(tab, currentOffset, nameLength).Trim('\0');
            currentOffset += nameLength;
            ushort age = BitConverter.ToUInt16(tab, currentOffset);
            currentOffset += sizeof(ushort);
            fields[2] = age.ToString();
            fields[3] = Encoding.ASCII.GetString(tab, currentOffset, 12).Trim('\0');
            currentOffset += 12;
            ushort emailLength = BitConverter.ToUInt16(tab, currentOffset);
            currentOffset += sizeof(ushort);
            fields[4] = Encoding.ASCII.GetString(tab, currentOffset, emailLength).Trim('\0');
            currentOffset += emailLength;
            ushort practise = BitConverter.ToUInt16(tab, currentOffset);
            currentOffset += sizeof(ushort);
            fields[5] = practise.ToString();
            char role = Encoding.ASCII.GetChars(tab, currentOffset, 1)[0]; /// ???
            fields[6] = role.ToString();
            return fields;
        }
    }
}
