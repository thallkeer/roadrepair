using System.Collections.Generic;
using ITS.Core.RoadRepairing.Domain;
using ITS.MapObjects.RoadRepairingMapObject.IModels;
using ITS.MapObjects.RoadRepairingMapObject.IViews;

namespace ITS.MapObjects.RoadRepairingMapObject.IPresenters
{
    /// <summary>
    /// Интерфейс представителя добавления и изменения ремонта дороги.
    /// </summary>
    public interface IRoadRepairEditPresenter : IBasePresenter<IRoadRepairEditView,IRoadRepairModel>
    {
    }
}