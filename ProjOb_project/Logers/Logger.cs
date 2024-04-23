using ProjOb_project.Publishers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Logers
{
    internal static class Logger
    {
        static private DateTime _now = DateTime.Now;
        private static string GetCurrentFileName()
        {
            string filename = "./Log/" + _now.Date.ToString("dd_MM") + ".txt";
            return filename;
        }


        public static void LogMessage(string log)
        {
            using (StreamWriter sw = new StreamWriter(GetCurrentFileName(), true))
            {
                sw.WriteLine(log);
            }
        }
    }
}
