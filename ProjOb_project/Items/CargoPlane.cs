using ProjOb_project.Items.Listeners;
using ProjOb_project.Visitors.Creating;
using ProjOb_project.Visitors.Logs;
using ProjOb_project.Visitors.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjOb_project.Items
{
    // Class for Cargo Plane inherited from Plane, and Plane inherited from ItemParsable
    internal class CargoPlane: Plane, IReportable, IListenerID
    {
        [JsonInclude]
        private float _maxLoad;

        public CargoPlane(ulong _id, string _serial, string _countryIso, string _model, float _maxLoad) :
            base(_id, _serial, _countryIso, _model)
        {
            this._maxLoad = _maxLoad;
        }

        public void acceptCreatingVisitor(ObjectCreatingVisitor visitor)
        {
            visitor.visitCargoPlane(this);
        }

        /// <summary>
        /// Accepting a visitor for reporting.
        /// </summary>
        /// <param name="visitor">IMediaVisitor visitor object</param>
        /// <returns>visitor returns suitable string</returns>
        public string acceptMediaVisitor(IMediaVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public int Update(NetworkSourceSimulator.IDUpdateArgs args, IdChangedVisitor visitor)
        {
            ulong old_id = args.ObjectID;
            ulong new_id = args.NewObjectID;
            lock (Database.AllObjectsLock)
            {
                foreach (ItemParsable item in Database.AllObjects)
                {
                    if (new_id == item.Id)
                    {
                        visitor.visitError(this, args);
                        return -1;
                    }
                }
                Id = new_id;
                lock (Database.DictionaryForAirportLock)
                {
                    Database.DictionaryForCargoPlane.Remove(old_id);
                    Database.DictionaryForCargoPlane.Add(new_id, this);
                }
            }
            visitor.visitSuccessfully(this, args);
            return 0;
        }
    }
}
