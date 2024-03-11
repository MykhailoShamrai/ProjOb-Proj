﻿using ProjOb_project.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjOb_project.Items
{
    // Class for Passanger inherited from Person, Person inherited from ItemParsable
    internal class Passanger : Person, ILoadable
    {
        static public int FieldsCount { get; set; } = 7;
        [JsonInclude]
        private string _class;
        [JsonInclude]
        private ulong _miles;

        public Passanger(ulong _id, string _name, ulong _age, string _phone, string _email, string _class, ulong _miles) :
            base(_id, _name, _age, _phone, _email)
        {
            this._class = _class;
            this._miles = _miles;
        }

        public override void acceptVisitor(Visitor visitor)
        {
            visitor.visitPassanger(this);
        }
    }
}