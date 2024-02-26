﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjOb_project
{
    internal class Flight: ItemParsable
    {
        [JsonInclude]
        private ulong _id;
        [JsonInclude]
        private ulong _originAsId;
        [JsonInclude]
        private ulong _targetAsId;
        [JsonInclude]
        private string _takeOffTime;
        [JsonInclude]
        private string _landingTime;
        [JsonInclude]
        private float _longtitude;
        [JsonInclude]
        private float _latitude;
        [JsonInclude]
        private float _amsl;
        [JsonInclude]
        private ulong _planeAsId;
        [JsonInclude]
        private ulong[] _crewAsId;
        [JsonInclude]
        private ulong[] _loadAsId;

        public Flight(ulong _id, ulong _originAsId, ulong _targetAsId, string _takeOffTime, string _landingTime, float _longtitude, float _latitude, float _amsl, ulong _planeAsId, ulong[] _crewAsId, ulong[] _loadAsId)
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
    }
}