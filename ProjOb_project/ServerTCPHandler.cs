using NetworkSourceSimulator;
using ProjOb_project.Factories;
using ProjOb_project.LineReaders;
using ProjOb_project.Serializers;
using ProjOb_project.Visitors;
using System.Text;


namespace ProjOb_project
{
    internal class ServerTCPHandler
    {
        const int MIN_OFFSET_MS = 10;
        const int MAX_OFFSET_MS = 20;

        private static readonly object _lockSingleton = new object();
        private readonly object _queueLock = new object();
        private readonly object _serializationLock = new object();

        private ConsoleService _consoleService;
        private Thread _thread_for_objects_creating;
        private Thread _thread_for_generating;
        private NetworkSourceSimulator.NetworkSourceSimulator _simulator;

        private static ServerTCPHandler? _handler = null;
        private static Queue<Message> _messageQueue = new Queue<Message>();

        /// <summary>
        /// Private constructor for adding default methods for Thread fields and adding them IsBackground property for correct ending. 
        /// Also field of type 
        /// </summary>
        private ServerTCPHandler()
        {
            Directory.CreateDirectory("Snapshots");
            _consoleService = ConsoleService.getInstance();
            _thread_for_generating = new Thread(Start);
            _thread_for_objects_creating = new Thread(ReadBinary);
            _thread_for_generating.IsBackground = true;
            _thread_for_objects_creating.IsBackground = true;
            _simulator = new NetworkSourceSimulator.NetworkSourceSimulator("example_data.ftr", MIN_OFFSET_MS, MAX_OFFSET_MS);
            _simulator.OnNewDataReady += AddMessage2Queue;
            _consoleService.PrintEvent += MakeASnapshot;
            _consoleService.ExitEvent += MakeASnapshot;
        }

        /// <summary>
        /// Method for returning an instance of ServerTCPHandler class. Uses lock statement for not creating a ot of instances by other threads.
        /// </summary>
        /// <returns>Method returns an instance of type ServerTCPHandler, which is created only once regarding to singleton pattern</returns>
        // https://refactoring.guru/design-patterns/singleton/csharp/example#example-1
        public static ServerTCPHandler getInstance()
        {
            if (_handler == null)
            {
                lock (_lockSingleton)
                {
                    if (_handler == null)
                    {
                        _handler = new ServerTCPHandler();
                    }
                }
            }
            return _handler;
        }


        /// <summary>
        /// A method for one of the threads for creating objects and addning them to Database. It uses lock statement to add objects to Database static class.
        /// This method uses static readonly Dictionary from FactoryForParsable and BinaryLineReader classes for creating correct object with correct parameters.
        /// </summary>
        private void ReadBinary()
        {
            while (true)
            {
                lock (_queueLock)
                {
                    if (_messageQueue.Count > 0)
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

        private void MakeASnapshot()
        {
            StringBuilder sb = new StringBuilder("snapshot_");
            DateTime dateTime = DateTime.Now;
            string tmp = dateTime.ToString("HH_mm_ss");
            sb.Append(tmp);
            sb.Append(".json");
            sb.Insert(0, "./Snapshots/");
            FtrParseVisitor ftrParseVisitor = new FtrParseVisitor();
            lock (_serializationLock)
            {
                Serializer.SerializeToFile(sb.ToString(), Database.AllObjects, new SerializerForJson());
                foreach (var kvp in Database.AllObjects)
                {
                    kvp.acceptVisitor(ftrParseVisitor);
                }
            }
        }

        private void AddMessage2Queue(object sender, NewDataReadyArgs args)
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

        // TODO: Warto przerobić Database, w sensie może warto zmienić lokalizację ogólnej listy obiektów

        public void Run()
        {
            _thread_for_generating.Start();
            _thread_for_objects_creating.Start();
        }
    }
}
