﻿using ProjOb_project.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.LineReaders
{
    internal class CrewReader: BinaryLineReader
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
            fields[1] = Encoding.ASCII.GetString(tab, currentOffset, nameLength);
            currentOffset += nameLength;
            ushort age = BitConverter.ToUInt16(tab, currentOffset);
            currentOffset += sizeof(ushort);
            fields[2] = age.ToString();
            fields[3] = Encoding.ASCII.GetString(tab, currentOffset, 12);
            currentOffset += 12;
            ushort emailLength = BitConverter.ToUInt16(tab, currentOffset);
            currentOffset += sizeof(ushort);
            fields[4] = Encoding.ASCII.GetString(tab, currentOffset, emailLength);
            currentOffset += emailLength;
            char role = Encoding.ASCII.GetChars(tab, currentOffset, 1)[0]; /// ???
            fields[5] = role.ToString();
            return fields;
        }
    }
}
