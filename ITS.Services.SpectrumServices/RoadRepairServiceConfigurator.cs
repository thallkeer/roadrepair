using ITS.Core.ServiceInterfaces;
using ITS.Core.RoadRepairing.DataInterfaces;
using ITS.Core.RoadRepairing.ServiceInterfaces;
using ITS.Data.RoadRepairing.DAO;
using ITS.Services.RoadRepairingServices.Services;
using Microsoft.Practices.Unity;

namespace ITS.Services.RoadRepairingServices
{
    /// <summary>
    ///     Конфигуратор сервисов.
    /// </summary>
    public class RoadRepairServiceConfigurator : IServiceConfigurator
    {
        /// <summary>
        ///     Конфигурирует сервис.
        /// </summary>
        /// <param name="container">Контейнер.</param>
        /// <param name="manager">Менеджер хостов.</param>
        public void Configure(IUnityContainer container, IServiceHostManager manager)
        {
            container.RegisterType<IRoadRepairDAO, RoadRepairDAO>();
            manager.Register(typeof(IRoadRepairService), typeof(RoadRepairService), "rr/roadrepair");

            container.RegisterType<IWorkSortDAO, WorkSortDAO>();
            manager.Register(typeof(IWorkSortService), typeof(WorkSortService), "ws/worksort");

        }
    }
}