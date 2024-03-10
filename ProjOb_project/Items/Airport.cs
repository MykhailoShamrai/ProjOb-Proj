using ProjOb_project.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjOb_project.Items
{
    // Class for Airport inherited from ItemParsable
    internal class Airport : ItemParsable
    {
        static public int FieldsCount { get; set; } = 7;

        [JsonInclude]
        private ulong _id;
        [JsonInclude]
        private string _name;
        [JsonInclude]
        private string _code;
        [JsonInclude]
        private float _longtitude;
        [JsonInclude]
        private float _latitude;
        [JsonInclude]
        private float _amsl;
        [JsonInclude]
        private string _countryIso;

        public Airport(ulong _id, string _name, string _code, float _longtitude, float _latitude, float _amsl, string _countryIso)
        {
            this._id = _id;
            this._name = _name;
            this._code = _code;
            this._longtitude = _longtitude;
            this._latitude = _latitude;
            this._amsl = _amsl;
            this._countryIso = _countryIso;
        }

        public override void acceptVisitor(Visitor visitor)
        {
            visitor.visitAirport(this);
        }
    }
}
