using ITS.Core.RoadRepairing.Domain;

namespace ITS.MapObjects.RoadRepairingMapObject.IViews
{
    /// <summary>
    /// Интерфейс вида информации о ремонте.
    /// </summary>
    public interface IRoadRepairInfoView : IBaseView
    {
        RoadRepair RoadRepair { get; set; }
    }
}