﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjOb_project
{
    [JsonDerivedType(typeof(Airport), typeDiscriminator: "AI")]
    [JsonDerivedType(typeof(Flight), typeDiscriminator: "FL")]
    [JsonDerivedType(typeof(Cargo), typeDiscriminator: "CA")]
    [JsonDerivedType(typeof(Passanger), typeDiscriminator: "P")]
    [JsonDerivedType(typeof(Crew), typeDiscriminator: "C")]
    [JsonDerivedType(typeof(PassangerPlane), typeDiscriminator: "PP")]
    [JsonDerivedType(typeof(CargoPlane), typeDiscriminator: "CP")]

    abstract internal class ItemParsable
    { }
}