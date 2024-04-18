using ProjOb_project.Items.Listeners;
using ProjOb_project.Visitors.Creating;
using ProjOb_project.Visitors.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjOb_project.Items
{
    // Class for Passanger Plane inherited from Plane, Plane inherited from ItemParsable
    internal class PassangerPlane : Plane, IReportable, IListenerID
    {
        [JsonInclude]
        private ushort _firstClassSize;
        [JsonInclude]
        private ushort _businessClassSize;
        [JsonInclude]
        private ushort _economyClassSize;

        public PassangerPlane(ulong _id, string _serial, string _countryIso, string _model, ushort _firstClassSize, ushort _businessClassSize, ushort _economyClassSize)
            : base(_id, _serial, _countryIso, _model)
        {
            this._firstClassSize = _firstClassSize;
            this._businessClassSize = _businessClassSize;
            this._firstClassSize = _firstClassSize;
            this._economyClassSize = _economyClassSize;
        }

        public override void acceptCreatingVisitor(ObjectCreatingVisitor visitor)
        {
            visitor.visitPassangerPlane(this);
        }

        /// <summary>
        /// Accepting a visitor for reporting.
        /// </summary>
        /// <param name="visitor">ImediaVisitor visitor object</param>
        /// <returns>visitor returns suitable string</returns>
        public string acceptMediaVisitor(IMediaVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public void Update(NetworkSourceSimulator.IDUpdateArgs args)
        {
            ulong old_id = args.ObjectID;
            ulong new_id = args.NewObjectID;
            if (_id == old_id)
            {
                lock (Database.AllObjectsLock)
                {
                    foreach (ItemParsable item in Database.AllObjects)
                    {
                        if (new_id == item.Id)
                        {
                            return;
                        }
                    }
                    Id = new_id;
                    lock (Database.DictionaryForPassangerPlaneLock)
                    {
                        Database.DictionaryForPassangerPlane.Remove(old_id);
                        Database.DictionaryForPassangerPlane.Add(new_id, this);
                    }
                }
            }
        }
    }
}
