using ProjOb_project.Items.Listeners;
using ProjOb_project.Visitors.Creating;
using ProjOb_project.Visitors.Log;
using ProjOb_project.Visitors.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjOb_project.Items
{
    // Class for Crew inherited from Person, Person inherited from ItemParsable
    internal class Crew : Person, IListenerID, IListenerContact
    {
        [JsonInclude]
        private ushort _practise;
        [JsonInclude]
        private string _role;

        public Crew(ulong _id, string _name, ulong _age, string _phone, string _email, ushort _practise, string _role) :
            base(_id, _name, _age, _phone, _email)
        {
            this._practise = _practise;
            this._role = _role;
        }

        public void acceptCreatingVisitor(ObjectCreatingVisitor visitor)
        {
            visitor.visitCrew(this);
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
                visitor.visitSuccessfully(this, args);
                Id = new_id;
                lock (Database.DictionaryForCrewLock)
                {
                    Database.DictionaryForCrew.Remove(old_id);
                    Database.DictionaryForCrew.Add(new_id, this);
                }
            }
            return 0;
        }

        public int Update(NetworkSourceSimulator.ContactInfoUpdateArgs args, ContactChangedVisitor visitor)
        {
            visitor.visitSuccessfully(this, args);
            Phone = args.PhoneNumber;
            Email = args.EmailAddress;
            return 0;
        }
    }
}
