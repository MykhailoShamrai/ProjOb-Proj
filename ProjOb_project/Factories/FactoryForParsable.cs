using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ProjOb_project.Parsers;

namespace ProjOb_project.NewFolder
{
    // Abstract class for all factories for classes inherited from ItemParsable.
    abstract internal class FactoryForParsable
    {
        // Abstract creating method for ItemParsable object. As a parameter is array of strings. Each string contains field of object of class defined by ItemParsable.
        // Parameter 'parameters' contains an array in order of constructor parameters for ItemParsable.
        
        abstract public ItemParsable CreateParsable(string[] parameters);

        // Static method, that parses parameters for Person class from array of string, where array of string 'parameters' contains parameters in string in sequence of Person
        // constructor parameters.
        static protected (ulong, string, ulong, string, string) ParseForPerson(string[] parameters)
        {
            ulong id = ulong.Parse(parameters[0]);
            string name = parameters[1];
            ulong age = ulong.Parse(parameters[2]);
            string phone = parameters[3];
            string email = parameters[4];
            return (id, name, age, phone, email);
        }

        // Static method, that parses parameters for Plane class from array of string, where array of string 'parameters' contains parameters in string in sequence of Plane
        // constructor parameters.
        static protected (ulong, string, string, string) ParseForPlane(string[] parameters)
        {
            ulong id = ulong.Parse(parameters[0]);
            string serial = parameters[1];
            string countryIso = parameters[2];
            string model = parameters[3];
            return (id, serial, countryIso, model);
        }

        // Static method, that parses parameters for 3 fields: longtitude, latitude and amsl. Array of strings 'parameters' must contain data for this 3 fields in order
        // longtitude, latitude, amsl.
        static protected (float, float, float) ParseCoordinates(string[] parameters)
        {
            float longitude = Parser.ParseStringWithDot2Float(parameters[0]);
            float latitude = Parser.ParseStringWithDot2Float(parameters[1]);
            float amsl = Parser.ParseStringWithDot2Float(parameters[2]);
            return (longitude, latitude, amsl);
        }

        // Public methot for creating all Factories of inherited from ItemParsable classes. For keys are used sequences of letters from .ftr file. This dictionary is used 
        // for reading from files and creating proper objects.
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
