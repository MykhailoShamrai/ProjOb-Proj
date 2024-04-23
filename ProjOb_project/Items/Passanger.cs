using ProjOb_project.Items.Listeners;
using ProjOb_project.Visitors.Creating;
using ProjOb_project.Visitors.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjOb_project.Items
{
    // Class for Passanger inherited from Person, Person inherited from ItemParsable
    internal class Passanger : Person, ILoadable, IListenerID
    {
        [JsonInclude]
        private string _class;
        [JsonInclude]
        private ulong _miles;

        public Passanger(ulong _id, string _name, ulong _age, string _phone, string _email, string _class, ulong _miles) :
            base(_id, _name, _age, _phone, _email)
        {
            this._class = _class;
            this._miles = _miles;
        }

        public void acceptCreatingVisitor(ObjectCreatingVisitor visitor)
        {
            visitor.visitPassanger(this);
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
                lock (Database.DictionaryForPassangerLock)
                {
                    Database.DictionaryForPassanger.Remove(old_id);
                    Database.DictionaryForPassanger.Add(new_id, this);
                }
            }
            visitor.visitSuccessfully(this, args);
            return 0;
        }
    }
}
