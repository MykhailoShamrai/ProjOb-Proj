using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjOb_project
{
    internal class CargoPlane: Plane
    {
        [JsonInclude]
        private float _maxLoad;

        public CargoPlane(ulong _id, string _serial, string _countryIso, string _model, float _maxLoad):
            base(_id, _serial, _countryIso, _model) 
        {
            this._maxLoad = _maxLoad;
        }
    }
}
