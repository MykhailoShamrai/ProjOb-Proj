
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkSourceSimulator;
using ProjOb_project.Factories;
using ProjOb_project.Items;
using ProjOb_project.LineReaders;

namespace ProjOb_project
{
    internal class ServerTCPHandler
    {
        const int MIN_OFFSET_MS = 10;
        const int MAX_OFFSET_MS = 200;
        private Thread _thread_for_generating;
        private static ServerTCPHandler? _handler = null;
        private NetworkSourceSimulator.NetworkSourceSimulator _simulator;
        private ServerTCPHandler()
        {
            _thread_for_generating = new Thread(Start);
            _thread_for_generating.IsBackground = true;
            _simulator = new NetworkSourceSimulator.NetworkSourceSimulator("example_data.ftr", 1000, 2000);
            _simulator.OnNewDataReady += ReadBinary;
        }

        public static ServerTCPHandler getInstance()
        {
            if (_handler == null)
                _handler = new ServerTCPHandler();
            return _handler;
        }

        //public void NewDataReadyHandler(object sender, NewDataReadyArgs args)
        //{
        //    Console.WriteLine($"{args}");
        //}

        public void ReadBinary(object sender, NewDataReadyArgs args)
        {
            (string, uint, byte[]) typeAndByte = BinaryLineReader.ReadSizeAndType(_simulator.GetMessageAt(args.MessageIndex));
            string[] fieldVars = BinaryLineReader.AllLineReaders[typeAndByte.Item1].ReadFieldsFromMessage(typeAndByte.Item2, typeAndByte.Item3);
            var tmp = FactoryForParsable.AllFactoriesDictionary[typeAndByte.Item1].CreateParsable(fieldVars);
        }

        private static void Start()
        {
            _handler!._simulator.Run();
        }

        public void Run()
        {
            _thread_for_generating.Start();
        }
        

    }
}
