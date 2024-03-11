using ProjOb_project.Items;

namespace ProjOb_project
{
    internal static class Database
    {
        static public List<ItemParsable> AllObjects { get; set; } = new List<ItemParsable>();
        static public Dictionary<ulong, PassangerPlane> DictionaryForPassangerPlane { get; set; } = new Dictionary<ulong, PassangerPlane>();
        static public Dictionary<ulong, Passanger> DictionaryForPassanger { get; set; } = new Dictionary<ulong, Passanger>();
        static public Dictionary<ulong, Flight> DictionaryForFlight { get; set; } = new Dictionary<ulong, Flight>();
        static public Dictionary<ulong, Crew> DictionaryForCrew { get; set; } = new Dictionary<ulong, Crew>();
        static public Dictionary<ulong, CargoPlane> DictionaryForCargoPlane { get; set; } = new Dictionary<ulong, CargoPlane>();
        static public Dictionary<ulong, Cargo> DictionaryForCargo { get; set; } = new Dictionary<ulong, Cargo>();
        static public Dictionary<ulong, Airport> DictionaryForAirport { get; set; } = new Dictionary<ulong, Airport>();
    }
}
