
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkSourceSimulator;
using ProjOb_project.Factories;
using ProjOb_project.Items;
using ProjOb_project.LineReaders;
using ProjOb_project.Serializers;
using ProjOb_project.Visitors;

namespace ProjOb_project
{
    internal class ServerTCPHandler
    {
        const int MIN_OFFSET_MS = 10;
        const int MAX_OFFSET_MS = 20;
        
        private readonly object _queueLock = new object();
        private readonly object _serializationLock = new object();

        private Thread _thread_for_objects_creating;
        private Thread _thread_for_generating;

        private static ServerTCPHandler? _handler = null;
        private static Queue<Message> _messageQueue = new Queue<Message>();
        private NetworkSourceSimulator.NetworkSourceSimulator _simulator;
        private ServerTCPHandler()
        {
            _thread_for_generating = new Thread(Start);
            _thread_for_objects_creating = new Thread(ReadBinary);
            _thread_for_generating.IsBackground = true;
            _thread_for_objects_creating.IsBackground = true;
            _simulator = new NetworkSourceSimulator.NetworkSourceSimulator("example_data.ftr", MIN_OFFSET_MS, MAX_OFFSET_MS);
            _simulator.OnNewDataReady += AddMessage2Queue;
        }

        public static ServerTCPHandler getInstance()
        {
            if (_handler == null)
                _handler = new ServerTCPHandler();
            return _handler;
        }


        public void ReadBinary()
        {
            while(true)
            {
                lock (_queueLock)
                {
                    if(_messageQueue.Count > 0)
                    {
                        (string, uint, byte[]) typeAndByte = BinaryLineReader.ReadSizeAndType(_messageQueue.Dequeue());
                        string[] fieldVars = BinaryLineReader.AllLineReaders[typeAndByte.Item1].ReadFieldsFromMessage(typeAndByte.Item2, typeAndByte.Item3);
                        lock (_serializationLock)
                        { 
                            Database.AllObjects.Add(FactoryForParsable.AllFactoriesDictionary[typeAndByte.Item1].CreateParsable(fieldVars));
                        }
                    }
                }
            }
        }

        public void MakeASnapshot()
        {
            StringBuilder sb = new StringBuilder("snapshot_");
            DateTime dateTime = DateTime.Now;
            sb.Append(dateTime.Hour);
            sb.Append("_");
            sb.Append(dateTime.Minute);
            sb.Append("_");
            sb.Append(dateTime.Second);
            sb.Append(".json");
            FtrParseVisitor ftrParseVisitor = new FtrParseVisitor();
            lock(_serializationLock)
            {
                Serializer.SerializeToFile(sb.ToString(), Database.AllObjects, new SerializerForJson());
                foreach(var kvp in Database.AllObjects)
                {
                    kvp.acceptVisitor(ftrParseVisitor);
                }
            }
        }

        public void AddMessage2Queue(object sender, NewDataReadyArgs args)
        {
            lock (_queueLock)
            {
                _messageQueue.Enqueue(_simulator.GetMessageAt(args.MessageIndex));
            }
        }

        private static void Start()
        {
            _handler!._simulator.Run();
        }

        // TODO: Comentarze, do tego warto przerobic formatowanie daty w metodach i klasach gdzie to jest potrzebne. Warto przerobić Database, w sensie może warto zmienić lokalizację ogólnej listy obiektów
        // Zrobić porządek w klasie TCP i w ogóle zastanowić się nad czyszczeniem kodu

        public void Run()
        {
            _thread_for_generating.Start();
            _thread_for_objects_creating.Start();
        }
    }
}
