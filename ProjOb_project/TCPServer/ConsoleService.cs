using ProjOb_project.Items;
using ProjOb_project.Visitors.Media;

namespace ProjOb_project.TCPServer
{
    internal class ConsoleService
    {
        /// <summary>
        /// Two events, for printing "exit" and "print" on console. _instance private field for singletone pattern.
        /// </summary>
        public event Action? PrintEvent;
        public event Action? ReportEvent;
        public event Action? ExitEvent;
        private static ConsoleService? _instance = null;

        /// <summary>
        /// Object for locking while instance of ConsolService created.
        /// </summary>
        private static readonly object _lock = new object();

        /// <summary>
        /// Private constructor to not able creating many instances. 
        /// </summary>
        private ConsoleService()
        {
            ReportEvent += WriteReport;
        }

        /// <summary>
        /// Singleton pattern getInstance method.
        /// </summary>
        /// <returns></returns>
        // https://refactoring.guru/design-patterns/singleton/csharp/example#example-1
        public static ConsoleService getInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ConsoleService();
                    }
                }
            }
            return _instance;
        }

        /// <summary>
        /// Invoking a PrintEvent event.
        /// </summary>
        private void OnPrintEvent()
        {
            PrintEvent?.Invoke();
        }

        /// <summary>
        /// Invokin a OnExitvent event.
        /// </summary>
        private void OnExitEvent()
        {
            ExitEvent?.Invoke();
        }

        private void OnReportEvent()
        {
            ReportEvent?.Invoke();
        }

        private void WriteReport()
        {
            List<IMediaVisitor> visitorsList = new List<IMediaVisitor>
            {
                new Television("Telewizja Abelowa"),
                new Television("Kanał TV-tensor"),
                new Radio("Radio Kwantyfikator"),
                new Radio("Radio Shmem"),
                new Newspaper("Gazeta Kategoryczna"),
                new Newspaper("Dziennik Politechniczny")
            };
            List<IReportable> repList = IReportable.Dictionaries2IReportableList();
            NewsGenerator newsGenerator = new NewsGenerator(visitorsList, repList);
            string? res;
            while ((res = newsGenerator.GenerateNextNews()) != null)
                Console.WriteLine(res);
        }

        /// <summary>
        /// Public method for reading from console.
        /// </summary>
        public void ReadFromConsole()
        {
            while (true)
            {
                switch (Console.ReadLine()!)
                {
                    case "print":
                        OnPrintEvent();
                        break;
                    case "report":
                        OnReportEvent();
                       break;
                    case "exit":
                        OnExitEvent();
                        return;
                }
            }
        }
    }
}
