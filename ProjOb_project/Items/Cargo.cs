using ProjOb_project.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjOb_project.Items
{
    // Class for Cargo inherited from ItemParsable
    internal class Cargo : ItemParsable, ILoadable
    {
        static public int FieldsCount { get; set; } = 4;
        [JsonInclude]
        private ulong _id;
        [JsonInclude]
        private float _weight;
        [JsonInclude]
        private string _code;
        [JsonInclude]
        private string _description;

        public Cargo(ulong _id, float _weight, string _code, string _description)
        {
            this._id = _id;
            this._weight = _weight;
            this._code = _code;
            this._description = _description;
        }

        public override void acceptVisitor(Visitor visitor)
        {
            visitor.visitCargo(this);
        }
    }
}
