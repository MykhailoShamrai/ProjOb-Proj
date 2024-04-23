using ProjOb_project.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project.Visitors.Log
{
    internal class ContactChangedVisitor
    {
        public void visitSuccessfully(Passanger passanger, NetworkSourceSimulator.ContactInfoUpdateArgs args)
        {
            Logers.Logger.LogMessage($"{DateTime.Now.ToString("HH:mm:ss")}| Passanger with Id {passanger.Id} that had number:{passanger.Phone} and email: {passanger.Email} changed number to {args.PhoneNumber} and email to {args.EmailAddress}");
        }

        public void visitSuccessfully(Crew crew, NetworkSourceSimulator.ContactInfoUpdateArgs args)
        {
            Logers.Logger.LogMessage($"{DateTime.Now.ToString("HH:mm:ss")}| Crew with Id {crew.Id} that had number:{crew.Phone} and email: {crew.Email} changed number to {args.PhoneNumber} and email to {args.EmailAddress}");
        }
    }
}
