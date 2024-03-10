using ProjOb_project.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.LineReaders
{
    internal class FlightReader: BinaryLineReader
    {
        public override string[] ReadFieldsFromMessage(uint size, byte[] tab)
        {
            ushort currentOffset = OFFSET_SIZE;
            string[] fields = new string[Flight.FieldsCount];
            ulong Id = BitConverter.ToUInt64(tab, currentOffset);
            currentOffset += sizeof(ulong);
            fields[0] = Id.ToString();
            ulong originAsId = BitConverter.ToUInt64(tab, currentOffset);
            currentOffset += sizeof(ulong);
            fields[1] = originAsId.ToString();
            ulong targetAsId = BitConverter.ToUInt64(tab, currentOffset);
            currentOffset += sizeof(ulong);
            fields[2] = targetAsId.ToString();
            long takeOfMsUTC = BitConverter.ToInt64(tab, currentOffset);
            currentOffset += sizeof(long);
            fields[3] = DateTime.UnixEpoch.AddMilliseconds(takeOfMsUTC).Hour.ToString() + 
                ":" + DateTime.UnixEpoch.AddMilliseconds(takeOfMsUTC).Minute.ToString();
            long landingMsUTC = BitConverter.ToInt64(tab, currentOffset);
            currentOffset += sizeof(long);
            fields[4] = DateTime.UnixEpoch.AddMilliseconds(landingMsUTC).Hour.ToString() +
                ":" + DateTime.UnixEpoch.AddMilliseconds(landingMsUTC).Minute.ToString();

            fields[5] = ""; // Longtitude
            fields[6] = ""; // Latitude
            fields[7] = ""; // AMSL

            ulong planeId = BitConverter.ToUInt64(tab, currentOffset);
            currentOffset += sizeof(ulong);
            fields[8] = planeId.ToString();
            ushort crewCount = BitConverter.ToUInt16(tab, currentOffset);
            currentOffset += sizeof(ushort);
            ulong[] crewTmp = new ulong[crewCount];
            for(int i = 0; i < crewCount; i++)
            {
                crewTmp[i] = BitConverter.ToUInt64(tab, currentOffset);
                currentOffset += sizeof(ulong);
            }
            StringBuilder sb = new StringBuilder(String.Join(";", crewTmp));
            sb.Append("]");
            sb.Insert(0, "[");
            fields[9] = sb.ToString();

            ushort loadCount = BitConverter.ToUInt16(tab,currentOffset);
            currentOffset += sizeof(ushort);
            ulong[] loadTmp = new ulong[loadCount];
            for (int i = 0; i < loadCount; i++)
            {
                loadTmp[i] = BitConverter.ToUInt64(tab, currentOffset);
                currentOffset += sizeof(ulong);
            }
            sb = new StringBuilder(String.Join(";", loadTmp));
            sb.Append("]");
            sb.Insert(0, "[");
            fields[10] = sb.ToString();
            return fields;
        }
    }
}
