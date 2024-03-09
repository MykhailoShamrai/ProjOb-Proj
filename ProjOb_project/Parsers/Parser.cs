using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using ProjOb_project.Items;
using ProjOb_project.Factories;
using ProjOb_project.Visitors;

namespace ProjOb_project.Parsers
{
    // Abstract class for parsers, for reading parameters and class identifier from text files
    abstract internal class Parser
    {
        // Abstract method for finding identifier for class written in a file. Method must return Identifier in first string, and all parameters of found class
        abstract public (string, string[]) FindClass(string line);

        // Static method for reading objects from file. Method returns list of ItemParsable objects. Each object is created by FactoryForParsable object in dictionary dictWithFactories,
        // which contains every Factory. Method require as a parameters string which contains filename. Second parameter is Parser object with 
        // apropriate to file type parser.
        static public List<ItemParsable> ReadFromFile(string filename, Parser parser, Visitor visitor)
        {
            List<ItemParsable> collection = new List<ItemParsable>();
            Dictionary<string, FactoryForParsable> dictWithFactories = FactoryForParsable.CreateAllFactories();
            string classType;
            string[] parameters;
            string? line;
            using (StreamReader sr = new StreamReader(filename))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    // If we can read the line, find class identifier and parameters, and then find apropriate Factory object in dictionary. After that add newly created object to list.
                    (classType, parameters) = parser.FindClass(line);
                    if (dictWithFactories.ContainsKey(classType))
                    {
                        collection.Add(dictWithFactories[classType].CreateParsable(parameters));
                    }
                }
            }
            // Linking all objects from arrays of uint to lists of required objects in flights
            foreach(ItemParsable parsable in collection)
            {
                parsable.acceptVisitor(visitor);
            }
            return collection;
        }

        // Method for parsing a string like [1;2;3;4] to array of ulong. Takes as a parameter string for parsing. Method doesn't check correctness of argument.
        static public ulong[] ParseParam2UIntTab(string param)
        {
            param = param.Trim('[', ']');
            string[] tab = param.Split(";");
            ulong[] result = new ulong[tab.Length];
            for (int i = 0; i < tab.Length; i++)
            {
                result[i] = ulong.Parse(tab[i]);
            }
            return result;
        }

        // Method for parsing string that contains single value written with 'dot' like 1.25
        static public float ParseStringWithDot2Float(string param)
        {
            return float.Parse(param, CultureInfo.InvariantCulture);
        }
    }
}
