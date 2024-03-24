using ProjOb_project.Items;

namespace ProjOb_project
{
    /// <summary>
    /// Static database class with Dictionaries for each type of objects (ItemParsable) and one List for all created objects.
    /// </summary>
    internal static class Database
    {
        public static readonly object AllObjectsLock = new object();
        public static readonly object DictionaryForPassangerPlaneLock = new object();
        public static readonly object DictionaryForPassangerLock = new object();
        public static readonly object DictionaryForFlightLock = new object();
        public static readonly object DictionaryForCrewLock = new object();
        public static readonly object DictionaryForCargoPlaneLock = new object();
        public static readonly object DictionaryForCargoLock = new object();
        public static readonly object DictionaryForAirportLock = new object();
        public static readonly object CurrentFlightsListLock = new object();


        static public List<ItemParsable> AllObjects { get; set; } = new List<ItemParsable>();
        static public Dictionary<ulong, PassangerPlane> DictionaryForPassangerPlane { get; set; } = new Dictionary<ulong, PassangerPlane>();
        static public Dictionary<ulong, Passanger> DictionaryForPassanger { get; set; } = new Dictionary<ulong, Passanger>();
        static public Dictionary<ulong, Flight> DictionaryForFlight { get; set; } = new Dictionary<ulong, Flight>();
        static public Dictionary<ulong, Crew> DictionaryForCrew { get; set; } = new Dictionary<ulong, Crew>();
        static public Dictionary<ulong, CargoPlane> DictionaryForCargoPlane { get; set; } = new Dictionary<ulong, CargoPlane>();
        static public Dictionary<ulong, Cargo> DictionaryForCargo { get; set; } = new Dictionary<ulong, Cargo>();
        static public Dictionary<ulong, Airport> DictionaryForAirport { get; set; } = new Dictionary<ulong, Airport>();

        /// <summary>
        /// List for current Flights, that are active.
        /// </summary>
        static public List<Flight> CurrentFlightsList { get; set; } = new List<Flight>();
    }
}
