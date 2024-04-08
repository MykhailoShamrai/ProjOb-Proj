using ProjOb_project.Visitors.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Items
{
    internal interface IReportable
    {
        public abstract string acceptMediaVisitor(IMediaVisitor visitor);

        public static List<IReportable> Dictionaries2IReportableList()
        {
            List<IReportable> list = new List<IReportable>();
            lock (Database.DictionaryForCargoPlaneLock)
            {
                list.AddRange(Database.DictionaryForCargoPlane.Values.ToList());
            }
            lock (Database.DictionaryForPassangerPlane)
            {
                list.AddRange(Database.DictionaryForPassangerPlane.Values.ToList());
            }
            lock (Database.DictionaryForAirportLock)
            {
                list.AddRange(Database.DictionaryForAirport.Values.ToList());
            }
            return list;
        }
    }
}
