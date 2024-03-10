
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkSourceSimulator;

namespace ProjOb_project
{
    internal class ServerTCPHandler
    {
        const int MIN_OFFSET_MS = 1000;
        const int MAX_OFFSET_MS = 2000;
        private Thread _thread_for_generating;
        private static ServerTCPHandler? _handler = null;
        private NetworkSourceSimulator.NetworkSourceSimulator _simulator;
        private ServerTCPHandler()
        {
            _thread_for_generating = new Thread(Start);
            _thread_for_generating.IsBackground = true;
            _simulator = new NetworkSourceSimulator.NetworkSourceSimulator("example_data.ftr", 1000, 2000);
            _simulator.OnNewDataReady += NewDataReadyHandler;
        }

        public static ServerTCPHandler getInstance()
        {
            if (_handler == null)
                _handler = new ServerTCPHandler();
            return _handler;
        }

        public void NewDataReadyHandler(object sender, NewDataReadyArgs args)
        {
            Console.WriteLine($"{args}");
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
