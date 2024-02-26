using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjOb_project
{
    internal class Crew: Person
    {
        [JsonInclude]
        private ushort _practise;
        [JsonInclude]
        private string _role;

        public Crew(ulong _id, string _name, ulong _age, string _phone, string _email, ushort _practise, string _role): 
            base(_id, _name, _age, _phone, _email)
        {
            this._practise = _practise;
            this._role = _role;
        }
    }
}
