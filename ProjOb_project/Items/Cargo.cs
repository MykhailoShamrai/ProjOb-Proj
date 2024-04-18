using ProjOb_project.Items.Listeners;
using ProjOb_project.Visitors.Creating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjOb_project.Items
{
    // Class for Cargo inherited from ItemParsable
    internal class Cargo : ItemParsable, ILoadable, IListenerID
    {
        [JsonInclude]
        private float _weight;
        [JsonInclude]
        private string _code;
        [JsonInclude]
        private string _description;

        public Cargo(ulong _id, float _weight, string _code, string _description)
        {
            this._id = _id;
            this._weight = _weight;
            this._code = _code;
            this._description = _description;
        }

        public override void acceptCreatingVisitor(ObjectCreatingVisitor visitor)
        {
            visitor.visitCargo(this);
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
                    lock (Database.DictionaryForCargoLock)
                    {
                        Database.DictionaryForCargo.Remove(old_id);
                        Database.DictionaryForCargo.Add(new_id, this);
                    }
                }
            }
        }
    }
}
