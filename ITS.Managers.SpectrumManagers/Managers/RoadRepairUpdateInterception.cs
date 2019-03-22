using ITS.Core.RoadRepairing.Domain;
using ITS.Managers.BaseManagers;


namespace ITS.Managers.RoadRepairingManagers.Managers
{
    /// <summary>
    /// Обновление карты при изменении ремонта.
    /// </summary>
   public class RoadRepairUpdateInterception : MapUpdateInterceptor<RoadRepair, long>
    {
    }
}
