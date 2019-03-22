using System;
using System.Collections.Generic;
using ITS.Core.RoadRepairing.Domain;
using ITS.Core.Domain.Photos;
using ITS.Core.Domain.Organizations;
using ITS.Core.RoadRepairing.Domain.Enums;

namespace ITS.MapObjects.RoadRepairingMapObject.IViews
{
    /// <summary>
    /// Интерфейс вида добавления и изменения ремонта дороги.
    /// </summary>
    public interface IRoadRepairEditView : IBaseView
    {
        /// <summary>
        /// Редактируемый ремонта дороги.
        /// </summary>
        //RoadRepair EditableRoadRepair { get; set; }

        /// <summary>
        /// Окончание изменения ремонта дороги
        /// </summary>
        event Action<long?, RoadRepair> EditRoadRepair;

        /// <summary>
        /// Добавление ремонта дороги.
        /// </summary>
        event Action<long?, RoadRepair> AddRoadRepair;
        
        

        //List<string> ComboBoxWorkSortCurrent { set; }
    
        List<WorkSort> WorkSorts { set; }
    }
}