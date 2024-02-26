﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjOb_project
{
    internal class PassangerPlane: Plane
    {
        [JsonInclude]
        private ushort _firstClassSize;
        [JsonInclude]
        private ushort _businessClassSize;
        [JsonInclude]
        private ushort _economyClassSize;

        public PassangerPlane(ulong _id, string _serial, string _countryIso, string _model, ushort _firstClassSize, ushort _businessClassSize,  ushort _economyClassSize)
            :base(_id, _serial, _countryIso, _model)
        {
            this._firstClassSize = _firstClassSize;
            this._businessClassSize = _businessClassSize;
            this._firstClassSize = _firstClassSize;
        }
    }
}