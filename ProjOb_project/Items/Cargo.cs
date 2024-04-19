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
        private ulong _id;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public ulong Id
        {
            get { return _id; }
            set { _id = value; }
        }
        [JsonInclude]
        private float _weight;
        [JsonInclude]
        private string _code;
        [JsonInclude]
        private string _description;

        public Cargo(ulong _id, float _weight, string _code, string _description)
        {
            Id = _id;
            this._weight = _weight;
            this._code = _code;
            this._description = _description;
        }

        public void acceptCreatingVisitor(ObjectCreatingVisitor visitor)
        {
            visitor.visitCargo(this);
        }

        public int Update(NetworkSourceSimulator.IDUpdateArgs args)
        {
            ulong old_id = args.ObjectID;
            ulong new_id = args.NewObjectID;
            lock (Database.AllObjectsLock)
            {
                foreach (ItemParsable item in Database.AllObjects)
                {
                    if (new_id == item.Id)
                    {
                        return -1;
                    }
                }
                Id = new_id;
                lock (Database.DictionaryForCargoLock)
                {
                    Database.DictionaryForCargo.Remove(old_id);
                    Database.DictionaryForCargo.Add(new_id, this);
                }
            }
            return 0;
        }
    }
}
