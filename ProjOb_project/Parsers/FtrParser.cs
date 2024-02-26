using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Parsers
{
    internal class FtrParser : Parser
    {
        public override (string, string[]) FindClass(string line)
        {
            string[] parameters = line.Split(',');
            return (parameters[0], parameters[1..parameters.Length]);
        }
    }
}
