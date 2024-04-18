using NetworkSourceSimulator;
using ProjOb_project.Factories;
using ProjOb_project.LineReaders;
using ProjOb_project.Publishers;
using ProjOb_project.Serializers;
using ProjOb_project.Visitors.Creating;
using System.Text;


namespace ProjOb_project.TCPServer
{
    internal class ServerTCPHandler
    {
        const int MIN_OFFSET_MS = 2;
        const int MAX_OFFSET_MS = 10;

        /// <summary>
        /// Variables for locking. _lockSingleton - locking variable for creating an instance of ServerTCPHandler. _queueLock - locking variable for locking a queue while adding a new message and creating a new 
        /// ItemParsable object. _serializationLock - locking variable for serialization and locking Database static fields.
        /// </summary>
        private static readonly object _lockSingleton = new object();
        private readonly object _queueLock = new object();

        /// <summary>
        /// ConsoleService instance for adding event handling methods. 
        /// Two threads objects for running server, and for adding messages to Queue.
        /// Instance of NetworkSourceSimulator to controle server.
        /// </summary>
        private ConsoleService _consoleService;
        private Thread _thread_for_objects_creating;
        private Thread _thread_for_generating;
        private NetworkSourceSimulator.NetworkSourceSimulator _simulator;

        /// <summary>
        /// _handler is an instance of a class for singleton design pattern.
        /// Queue _messageQueue is required for adding new messages handled from server.
        /// </summary>
        private static ServerTCPHandler? _handler = null;
        private static Queue<Message> _messageQueue = new Queue<Message>();

        /// <summary>
        /// Private constructor for adding default methods for Thread fields and adding them IsBackground property for correct ending. 
        /// Also Directory "Snapshots" is creating, if wasn't created erlier. It's important, that same method is added for ExitEvent. Int time of exiting, shapshot is also created.
        /// </summary>
        private ServerTCPHandler()
        {
            Directory.CreateDirectory("Snapshots");
            _consoleService = ConsoleService.getInstance();
            _thread_for_generating = new Thread(Start);
            _thread_for_objects_creating = new Thread(ReadBinary);
            _thread_for_generating.IsBackground = true;
            _thread_for_objects_creating.IsBackground = true;
            _simulator = new NetworkSourceSimulator.NetworkSourceSimulator("example.ftre", MIN_OFFSET_MS, MAX_OFFSET_MS);
            _simulator.OnNewDataReady += AddMessage2Queue;
            _consoleService.PrintEvent += MakeASnapshot;
        }

        /// <summary>
        /// Method for returning an instance of ServerTCPHandler class. Uses lock statement for not creating a ot of instances by other threads.
        /// </summary>
        /// <returns>Method returns an instance of type ServerTCPHandler, which is created only once regarding to singleton pattern</returns>
        // https://refactoring.guru/design-patterns/singleton/csharp/example#example-1
        public static ServerTCPHandler getInstance(EventManager? manaager = null)
        {
            if (_handler == null)
            {
                lock (_lockSingleton)
                {
                    if (_handler == null)
                    {
                        _handler = new ServerTCPHandler();
                        if (manaager != null)
                        {
                            _handler._simulator.OnIDUpdate += manaager.onIDPublisher.Notify;
                        }
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
            FtrParseVisitor ftrParseVisitor = new FtrParseVisitor();
            Message msg;
            while (true)
            {
                lock (_queueLock)
                {
                    if (_messageQueue.Count > 0)
                    {
                        msg = _messageQueue.Dequeue();
                    }
                    else
                    {
                        continue;
                    }
                }
                (string, uint, byte[]) typeAndByte = BinaryLineReader.ReadSizeAndType(msg);
                string[] fieldVars = BinaryLineReader.AllLineReaders[typeAndByte.Item1].ReadFieldsFromMessage(typeAndByte.Item2, typeAndByte.Item3);
                lock (Database.AllObjectsLock)
                {
                    Database.AllObjects.Add(FactoryForParsable.AllFactoriesDictionary[typeAndByte.Item1].CreateParsable(fieldVars));
                    foreach (var kvp in Database.AllObjects)
                    {
                        kvp.acceptCreatingVisitor(ftrParseVisitor);
                    }
                }
            }
        }

        /// <summary>
        /// A method for handling event ConsleService.PrintEvent. Creates a snapshot from List of all objects in Database class. Creates snapshot in "Snapshots" directory. Name of snapshot will be in form:
        /// snapshot_HH_MM_SS.json, where HH - an hour of snapshot creating, MM - a minute of shapshot creating and SS - a second of creating.
        /// </summary>
        private void MakeASnapshot()
        {
            StringBuilder sb = new StringBuilder("snapshot_");
            FtrParseVisitor ftrParseVisitor = new FtrParseVisitor();
            DateTime dateTime = DateTime.Now;
            string tmp = dateTime.ToString("HH_mm_ss");
            sb.Append(tmp);
            sb.Append(".json");
            sb.Insert(0, "./Snapshots/");
            lock (Database.AllObjectsLock)
            {
                Serializer.SerializeToFile(sb.ToString(), Database.AllObjects, new SerializerForJson());
                foreach (var kvp in Database.AllObjects)
                {
                    kvp.acceptCreatingVisitor(ftrParseVisitor);
                }
            }
        }

        /// <summary>
        /// A method for handling event OnNewDataReady from server. Adds last message to Queue _messageQueue.
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="args">NewDataReadyArgs argument of event</param>
        private void AddMessage2Queue(object sender, NewDataReadyArgs args)
        {
            lock (_queueLock)
            {
                _messageQueue.Enqueue(_simulator.GetMessageAt(args.MessageIndex));
            }
        }

        /// <summary>
        /// Method for starting a server in _simulator. This method is default method for thread _threadForGenerating.
        /// </summary>
        private void Start()
        {
            _handler!._simulator.Run();
        }

        /// <summary>
        /// Public method for starting server and handling messages.
        /// </summary>
        public void Run()
        {
            _thread_for_generating.Start();
            _thread_for_objects_creating.Start();
        }
    }
}
