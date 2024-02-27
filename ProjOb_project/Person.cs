using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjOb_project
{
    // Abstract class for persons named Person. Class Person inherited from ItemParsable
    abstract internal class Person: ItemParsable
    {
        [JsonInclude]
        private ulong _id;
        [JsonInclude]
        private string _name;
        [JsonInclude]
        private ulong _age;
        [JsonInclude]
        private string _phone;
        [JsonInclude]
        private string _email;

        public Person(ulong id = default, string name= default, ulong age = default, string phone = default, string email = default)
        {
            _id = id;
            _name = name;
            _age = age;
            _phone = phone;
            _email = email;
        }
    }
}
