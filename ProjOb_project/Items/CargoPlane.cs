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
    // Class for Cargo Plane inherited from Plane, and Plane inherited from ItemParsable
    internal class CargoPlane: Plane, IReportable
    {
        [JsonInclude]
        private float _maxLoad;

        public CargoPlane(ulong _id, string _serial, string _countryIso, string _model, float _maxLoad) :
            base(_id, _serial, _countryIso, _model)
        {
            this._maxLoad = _maxLoad;
        }

        public override void acceptCreatingVisitor(ObjectCreatingVisitor visitor)
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
    }
}
