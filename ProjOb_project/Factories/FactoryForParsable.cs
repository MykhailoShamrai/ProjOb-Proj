using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.NewFolder
{
    abstract internal class FactoryForParsable
    {
        abstract public ItemParsable CreateParsable(string[] parameters);
        static protected (ulong, string, ulong, string, string) ParseForPerson(string[] parameters)
        {
            ulong id = ulong.Parse(parameters[0]);
            string name = parameters[1];
            ulong age = ulong.Parse(parameters[2]);
            string phone = parameters[3];
            string email = parameters[4];
            return (id, name, age, phone, email);
        }

        static protected (ulong, string, string, string) ParseForPlane(string[] parameters)
        {
            ulong id = ulong.Parse(parameters[0]);
            string serial = parameters[1];
            string countryIso = parameters[2];
            string model = parameters[3];
            return (id, serial, countryIso, model);
        }

        static protected (float, float, float) ParseCoordinates(string[] parameters)
        {
            float longitude = Parser.ParseStringWithDot2Float(parameters[0]);
            float latitude = Parser.ParseStringWithDot2Float(parameters[1]);
            float amsl = Parser.ParseStringWithDot2Float(parameters[2]);
            return (longitude, latitude, amsl);
        }

        static public Dictionary<string, FactoryForParsable> CreateAllFactories()
        {
            Dictionary<string, FactoryForParsable> res = new Dictionary<string, FactoryForParsable>
            {
                { "C", new FactoryForCrew() },
                { "P", new FactoryForPassanger() },
                { "CA", new FactoryForCargo() },
                { "CP", new FactoryForCargoPlane() },
                { "PP", new FactoryForPassangerPlane() },
                { "AI", new FactoryForAirport() },
                { "FL", new FactoryForFlight() }
            };
            return res;
        }
    }
}
