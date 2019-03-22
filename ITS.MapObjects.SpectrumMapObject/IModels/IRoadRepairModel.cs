using System;
using System.Collections.Generic;
using ITS.Core.Domain.Districts;
using ITS.Core.RoadRepairing.Domain;
using ITS.Core.RoadRepairing.Domain.Enums;

namespace ITS.MapObjects.RoadRepairingMapObject.IModels
{
    /// <summary>
    /// Интерфейс модели фильтра Дорожных ремонтов.
    /// </summary>
    public interface IRoadRepairModel
    {
        //RoadRepair EditableRoadRepair { get; set; }

        //void RoadRepairAdd();
        //void RoadRepairEdit();
        void RoadRepairAdd(long? addressId, RoadRepair roadRepair);
        void RoadRepairEdit(long? addressId, RoadRepair roadRepair);

        //List<string> ChangeDescription(int repairType, int workType);

        List<WorkSort> GetWorkSorts();
    }
}