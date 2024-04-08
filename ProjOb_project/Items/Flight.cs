using ProjOb_project.Visitors.Creating;
using System.Text.Json.Serialization;


namespace ProjOb_project.Items
{
    // Class for Flights inherited from ItemParsable
    internal class Flight : ItemParsable, IJsonOnDeserialized
    {
        [JsonInclude]
        private ulong _id;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public ulong Id
        {
            get { return _id; } 
        }
        [JsonInclude]
        private ulong _originAsId;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public ulong OriginAsId
        {
            get { return _originAsId; }
        }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public Airport? OriginAirport { get; set; } = null;
        [JsonInclude]
        private ulong _targetAsId;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public ulong TargetAsId
        {
            get { return _targetAsId; }
        }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public Airport? TargetAirport { get; set; } = null;
        [JsonInclude]
        private string _takeOffTime;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public string TakeOffTime
        {
            get { return _takeOffTime; }
        }
        [JsonInclude]
        private string _landingTime;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public string LandingTime
        {
            get { return _landingTime; }
        }
        [JsonInclude]
        private float? _longtitude;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public float? Longtitude
        {
            get { return _longtitude; }
            set {  _longtitude = value; }
        }
        [JsonInclude]
        private float? _latitude;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public float? Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }
        [JsonInclude]
        private float? _amsl;
        [JsonInclude]
        private ulong _planeAsId;

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public Plane? Plane { get; set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public ulong PlaneAsId
        {
            get { return _planeAsId; }
        }

        [JsonInclude]
        private ulong[] _crewAsId;

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public ulong[] CrewAsId
        {
            get
            {
                ulong[] tmp = new ulong[_crewAsId.Length];
                Array.Copy(_crewAsId, tmp, _crewAsId.Length);
                return tmp;
            }
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public List<Crew> CrewList { get; set; } = new List<Crew>();

        [JsonInclude]
        private ulong[] _loadAsId;

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public ulong[] LoadAsId
        {
            get
            {
                ulong[] tmp = new ulong[_loadAsId.Length];
                Array.Copy(_loadAsId, tmp, _loadAsId.Length);
                return tmp;
            }
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public List<ILoadable> LoadList { get; set; } = new List<ILoadable>();

        public Flight(ulong _id, ulong _originAsId, ulong _targetAsId, string _takeOffTime, string _landingTime, float? _longtitude, float? _latitude, float? _amsl, ulong _planeAsId, ulong[] _crewAsId, ulong[] _loadAsId)
        {
            this._id = _id;
            this._originAsId = _originAsId;
            this._targetAsId = _targetAsId;
            this._takeOffTime = _takeOffTime;
            this._landingTime = _landingTime;
            this._longtitude = _longtitude;
            this._latitude = _latitude;
            this._amsl = _amsl;
            this._planeAsId = _planeAsId;
            this._crewAsId = _crewAsId;
            this._loadAsId = _loadAsId;
        }

        public override void acceptCreatingVisitor(ObjectCreatingVisitor visitor)
        {
            visitor.visitFlight(this);
        }

        /// <summary>
        /// Overrided method OnDeserialized for linking all objects with ids from CrewAsId and LoadAsId
        /// </summary>
        public void OnDeserialized()
        {
            acceptCreatingVisitor(new FtrParseVisitor());
        }
    }
}
