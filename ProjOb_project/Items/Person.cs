using ProjOb_project.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjOb_project.Items
{
    // Abstract class for persons named Person. Class Person inherited from ItemParsable
    abstract internal class Person : ItemParsable
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
        private string _name;
        [JsonInclude]
        private ulong _age;
        [JsonInclude]
        private string _phone;
        [JsonInclude]
        private string _email;

        public Person(ulong _id, string _name, ulong _age, string _phone, string _email)
        {
            this._id = _id;
            this._name = _name;
            this._age = _age;
            this._phone = _phone;
            this._email = _email; 
        }
    }
}
