using ProjOb_project.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjOb_project.Items
{
    // Abstract class for planes named Plane. Class Plane inherited from ItemParsable
    abstract internal class Plane : ItemParsable
    {
        [JsonInclude]
        private ulong _id;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public ulong Id
        {
            get { return _id; }
            set { _id = value; }
        }
        [JsonInclude]
        private string _serial;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public string Serial
        {
            get { return _serial; }
        }
        [JsonInclude]
        private string _countryIso;
        [JsonInclude]
        private string _model;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public string Model
        {
            get { return _model; }
        }

        public Plane(ulong _id, string _serial, string _countryIso, string _model)
        {
            this._id = _id;
            this._serial = _serial;
            this._countryIso = _countryIso;
            this._model = _model;
        }
    }
}
