namespace ProjOb_project
{
    internal class ConsoleService
    {
        public event Action? PrintEvent;
        public event Action? ExitEvent;
        private static ConsoleService? _instance = null;

        private static readonly object _lock = new object();

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

        public void OnPrintEvent()
        {
            PrintEvent?.Invoke();
        }

        public void OnExitEvent()
        {
            ExitEvent?.Invoke();
        }

        public void ReadFromConsole()
        {
            while (true)
            {
                switch (Console.ReadLine()!)
                {
                    case "print":
                        OnPrintEvent();
                        break;
                    case "exit":
                        OnExitEvent();
                        return;
                }
            }
        }
    }
}
