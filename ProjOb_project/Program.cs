namespace ProjOb_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServerTCPHandler handler = ServerTCPHandler.getInstance();
            ConsoleService service = ConsoleService.getInstance();
            handler.Run();
            service.ReadFromConsole();
        }
    }
}
