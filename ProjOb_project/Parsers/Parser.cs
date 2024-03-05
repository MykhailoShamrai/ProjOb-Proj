using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjOb_project.NewFolder;

namespace ProjOb_project.Parsers
{
    // Abstract class for parsers, for reading parameters and class identifier from text files
    abstract internal class Parser
    {
        // Field of CultureInfo type, for parsing float variable with 'dot' like 1.25
        static private readonly CultureInfo _cultureForFloatsFtr = new CultureInfo("en-US");

        // Array of string field for parsing string like [1;2;3;4] to array
        static private readonly string[] _separatorsForFtr = { ";", "[", "]" };

        // Abstract method for finding identifier for class written in a file. Method must return Identifier in first string, and all parameters of found class
        abstract public (string, string[]) FindClass(string line);

        // Static method for reading objects from file. Method returns list of ItemParsable objects. Each object is created by FactoryForParsable object in dictionary dictWithFactories,
        // which contains every Factory. Method require as a parameters string which contains filename or relative path in regard to Output directory. Second parameter is Parser object with 
        // apropriate to file type parser.
        static public List<ItemParsable> ReadFromFile(string filename, Parser parser)
        {
            List<ItemParsable> collection = new List<ItemParsable>();
            Dictionary<string, FactoryForParsable> dictWithFactories = FactoryForParsable.CreateAllFactories();
            string classType;
            string[] parameters;
            string? line;
            string path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, filename);
            using (StreamReader sr = new StreamReader(path))
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
            foreach(var item in FactoryForFlight.DictionaryForFlight)
            {
                item.Value.LoadLists();
            }
            return collection;
        }

        // Method for parsing a string like [1;2;3;4] to array of ulong. Takes as a parameter string for parsing. Method doesn't check correctness of argument.
        static public ulong[] ParseParam2UIntTab(string param)
        {
            string[] tab = param.Split(_separatorsForFtr, StringSplitOptions.RemoveEmptyEntries);
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
            return float.Parse(param, _cultureForFloatsFtr);
        }
    }
}
