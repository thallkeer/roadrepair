using System;
using ITS.Core.Domain;
using ITS.Core.RoadRepairing.Domain.Enums;

namespace ITS.Core.RoadRepairing.Domain
{
    [Serializable]
    public class WorkSort : DomainObject<long>
    {
        public WorkSort() { }

        public RepairType RepairType { get; set; }
        public WorkType WorkType { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }

        public override void CopyFrom(DomainObject<long> T)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            var hashCode = 894269444;
            hashCode = hashCode * -1521134295 + RepairType.GetHashCode();
            hashCode = hashCode * -1521134295 + WorkType.GetHashCode();
            //hashCode = hashCode * -1521134295 + Description.GetHashCode();
            return hashCode;
        }
    }
}
