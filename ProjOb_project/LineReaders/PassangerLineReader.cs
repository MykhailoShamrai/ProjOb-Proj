﻿using ProjOb_project.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.LineReaders
{
    internal class PassangerLineReader: BinaryLineReader
    {
        static private int FieldsCount = 7;
        /// <summary>
        /// Overriden method for returning sting array for Passanger object with parameters in good order for FactoryMethod.
        /// </summary>
        /// <param name="size">Size of message</param>
        /// <param name="tab">Array of bits of the message</param>
        /// <returns></returns>
        public override string[] ReadFieldsFromMessage(uint size, byte[] tab)
        {
            ushort currentOffset = OFFSET_SIZE;
            string[] fields = new string[FieldsCount];
            ulong Id = BitConverter.ToUInt64(tab, currentOffset);
            fields[0] = Id.ToString();
            currentOffset += sizeof(ulong);
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
            char classOf = Encoding.ASCII.GetChars(tab, currentOffset, 1)[0];
            currentOffset += 1;
            fields[5] = classOf.ToString();
            ulong miles = BitConverter.ToUInt64(tab, currentOffset);
            fields[6] = miles.ToString();
            return fields;
        }
    }
}
