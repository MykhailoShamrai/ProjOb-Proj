using ProjOb_project.Visitors.Creating;
using ProjOb_project.Visitors.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjOb_project.Items
{
    // Class for Airport inherited from ItemParsable
    internal class Airport : ItemParsable, IReportable
    {
        [JsonInclude]
        private ulong _id;
        [JsonInclude]
        private string _name;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public string Name
        {
            get { return _name; }
        }
        [JsonInclude]
        private string _code;
        [JsonInclude]
        private float? _longtitude;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public float Longtitude
        {
            get { return _longtitude ?? default(float); }
        }
        [JsonInclude]
        private float? _latitude;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public float Latitude
        {
            get { return _latitude ?? default(float); }
        }
        [JsonInclude]
        private float? _amsl;
        [JsonInclude]
        private string _countryIso;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public string Country
        {
            get { return _countryIso; }
        }

        public Airport(ulong _id, string _name, string _code, float? _longtitude, float? _latitude, float? _amsl, string _countryIso)
        {
            this._id = _id;
            this._name = _name;
            this._code = _code;
            this._longtitude = _longtitude;
            this._latitude = _latitude;
            this._amsl = _amsl;
            this._countryIso = _countryIso;
        }

        public override void acceptCreatingVisitor(ObjectCreatingVisitor visitor)
        {
            visitor.visitAirport(this);
        }

        /// <summary>
        /// Accepting a visitor for reporting.
        /// </summary>
        /// <param name="visitor">ImediaVisitor visitor object</param>
        /// <returns>visitor returns suitable string</returns>
        public string acceptMediaVisitor(IMediaVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
