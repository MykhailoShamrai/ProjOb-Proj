using NetworkSourceSimulator;
using ProjOb_project.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.LineReaders
{

    abstract internal class BinaryLineReader
    { 
        /// <summary>
        /// Class for reading Messages from TCP server in, where message is binary array. 
        /// </summary>
        /// 
        public Dictionary<string, BinaryLineReader> AllLineReaders = CreateAllReaders();

        protected const ushort TYPENAME_SIZE = 3;
        protected const ushort LENGTH_SIZE = 4;
        protected const ushort OFFSET_SIZE = TYPENAME_SIZE + LENGTH_SIZE;
        static (string, uint, byte[]) ReadSizeAndType(Message msg)
        {
            byte[] bytes = msg.MessageBytes;
            string type = Encoding.ASCII.GetString(bytes, 0, TYPENAME_SIZE);
            uint size = BitConverter.ToUInt32(bytes, TYPENAME_SIZE);
            return (type, size, bytes);
        }
        abstract public string[] ReadFieldsFromMessage(uint size, byte[] tab);
        /// <summary>
        /// Private static method for creating all BinaryReaders, and adding them to dictionary. It will be handful in parsing messages while taking TCP messages from server.
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, BinaryLineReader> CreateAllReaders()
        {
            Dictionary<string, BinaryLineReader> res = new Dictionary<string, BinaryLineReader>
            {
                { "NCR", new CrewLineReader() },
                { "NPA", new PassangerLineReader() },
                { "NCA", new CargoLineReader() },
                { "NCP", new CargoPlaneLineReader() },
                { "NPP", new PassangerPlaneLineReader() },
                { "NAI", new AirportLineReader() },
                { "NFL", new FlightLineReader() }
            };
            return res;
        }
    }

}
