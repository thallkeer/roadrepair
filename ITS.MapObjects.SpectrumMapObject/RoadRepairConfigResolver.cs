using ITS.Core.ManagerInterfaces;
using ITS.Core.RoadRepairing.ManagerInterfaces;
using ITS.Core.RoadRepairing.ServiceInterfaces;
using ITS.GIS.MapEntities.Renderer;
using ITS.Managers.RoadRepairingManagers.Managers;
using ITS.MapObjects.BaseMapObject.Misc;
using ITS.MapObjects.BaseMapObject.Misc.PluginAttributes;
using ITS.MapObjects.RoadRepairingMapObject.Properties;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using ITS.ProjectBase.Utils.Container;
using ITS.GIS.MapEntities.Loader;
using ITS.MapObjects.RoadRepairingMapObject.IModels;
using ITS.MapObjects.RoadRepairingMapObject.IPresenters;
using ITS.MapObjects.RoadRepairingMapObject.IViews;
using ITS.MapObjects.RoadRepairingMapObject.Models;
using ITS.MapObjects.RoadRepairingMapObject.Presenters;
using ITS.MapObjects.RoadRepairingMapObject.Views;

namespace ITS.MapObjects.RoadRepairingMapObject
{
    /// <summary>
    /// Регистратор компонентов плагина в IoC-контейнере.
    /// </summary>
    public class RoadRepairConfigResolver : IUnityConfigResolver
    {
        #region Implementation of IUnityConfigResolver

        public void ConfigureContainer(IUnityContainer container)
        {
            // Менеджер ресурсов.
            container.RegisterInstance(Resources.ResourceManager);

            // Панель с кнопками.
            container.RegisterType<IMapObjectManager, RoadRepairPanel>(RoadRepairConstants.ToolName);

            //// Регистрация менеджеров.
            container.RegisterType<IRoadRepairManager, RoadRepairManager>(
                new Interceptor(new InterfaceInterceptor()),
                new InterceptionBehavior<RoadRepairUpdateInterception>());

            container.RegisterType<IWorkSortManager, WorkSortManager>(
                new Interceptor(new InterfaceInterceptor()));
           

            //Регистрация MVP
            container.RegisterType<IRoadRepairModel, RoadRepairModel>(new ContainerControlledLifetimeManager());

            container.RegisterType<IRoadRepairEditPresenter, RoadRepairEditPresenter>()
                .RegisterType<IRoadRepairEditView, RoadRepairEditView>();
               

            container.RegisterType<BaseView>();

            container.RegisterType<IRoadRepairInfoView, RoadRepairInfoView>();

            container.RegisterType<IWorkSortCatalogView, WorkSortCatalogView>();

          
            container.RegisterType<IRoadRepairSummaryView, RoadRepairSummaryView>()
                .RegisterType<IRoadRepairFindPresenter, RoadRepairSummaryPresenter>();

            if (RoadRepairConstants.CustomRendererEnabled)
            {
                // Кастомный отрисовщик.
                container.Resolve<ILayerRendererContainer>().AddRenderer(new RoadRepairLayerRenderer());

                Container.MainContainer.RegisterType<ICustomLayerLoader, RoadRepairLayerLoader>(Resources
                    .RoadRepairAlias);
            }

            // Пути хостов.
            Container.MainContainer.RegisterInstance(new ClientHostConfiguration<IRoadRepairService>("rr/roadrepair"));
            Container.MainContainer.RegisterInstance(new ClientHostConfiguration<IWorkSortService>("ws/worksort"));
        }

        #endregion
    }
}