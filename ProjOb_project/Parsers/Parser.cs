using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjOb_project.NewFolder;

namespace ProjOb_project
{
    abstract internal class Parser
    {
        static private readonly CultureInfo _cultureForFloatsFtr = new CultureInfo("en-US");
        static private readonly string[] _separatorsForFtr = { ";", "[", "]" };

        abstract public (string, string[]) FindClass(string line);
        static public List<ItemParsable> ReadFromFile(string filename, Parser parser)
        {
            List<ItemParsable> collection = new List<ItemParsable>();
            Dictionary<string, FactoryForParsable> dictWithFactories = FactoryForParsable.CreateAllFactories();
            string classType;
            string[] parameters;
            string? line;
            string path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, filename);
            using(StreamReader sr = new StreamReader(path))
            {
                while((line = sr.ReadLine()) != null)
                {
                    (classType, parameters) = parser.FindClass(line);
                    if(dictWithFactories.ContainsKey(classType))
                    {
                        collection.Add(dictWithFactories[classType].CreateParsable(parameters));
                    }
                }
            }
            return collection;
        }
        static public ulong[] ParseParam2UIntTab(string param)
        {
            string[] tab = param.Split(_separatorsForFtr, System.StringSplitOptions.RemoveEmptyEntries);
            ulong[] result = new ulong[tab.Length];
            for (int i = 0; i < tab.Length; i++)
            {
                result[i] = ulong.Parse(tab[i]);
            }
            return result;
        }

        static public float ParseStringWithDot2Float(string param)
        {
            return float.Parse(param, _cultureForFloatsFtr);
        }
    }
}
