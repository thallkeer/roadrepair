using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITS.Core.Domain.Districts;
using ITS.Core.Domain.FeatureObjects;
using ITS.Core.Domain.Organizations;
using ITS.Core.RoadRepairing.Domain.Enums;
using JetBrains.Annotations;

namespace ITS.Core.RoadRepairing.Domain
{
    [Serializable]
    public class RoadRepairDTO
    {
        #region DataProperties

        public long RoadRepairId { get; set; }

        public Address Address { get; set; }

        public RepairType RepairType { get; set; }

        public WorkType WorkType { get; set; }

        public string WorkSort { get; set; }

        public RoadRepairStatus Status { get; set; }

        [CanBeNull] public Organization Performer { get; set; }

        [CanBeNull] public Organization Customer { get; set; }

        [CanBeNull] public Organization Owner { get; set; }

        public DateTime? RepairStart { get; set; }

        public DateTime? RepairEnd { get; set; }

        public DateTime? RepairStartFact { get; set; }

        public DateTime? RepairEndFact { get; set; }

        public FeatureObject FeatureObject { get; set; }

        #endregion
    }
}
