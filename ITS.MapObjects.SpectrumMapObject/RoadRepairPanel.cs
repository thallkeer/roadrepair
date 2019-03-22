using System;
using System.Reflection;
using ITS.Client.Interface.StateMachine;
using ITS.GIS.CoreToGeoTranslators;
using ITS.GIS.MapEntities;
using ITS.GIS.MapEntities.Renderer;
using ITS.GIS.UIControls.Tools;
using ITS.MapObjects.BaseMapObject.Misc;
using ITS.MapObjects.BaseMapObject.Misc.PluginAttributes;
using Microsoft.Practices.Unity;
using ITS.MapObjects.EditGeometryPlugin.Tools;
using System.Windows.Forms;
using ITS.Core.ManagerInterfaces.Features;
using ITS.Core.Domain.FeatureObjects;
using GeoAPI.Geometries;
using ITS.ProjectBase.Utils.AsyncWorking;
using System.Collections.Generic;
using System.Linq;
using ITS.Core.Domain.Districts;
using ITS.ProjectBase.Utils.EventBroker.EventBrokerExtension;
using ITS.Core.RoadRepairing.Domain;
using ITS.Core.RoadRepairing.ManagerInterfaces;
using ITS.MapObjects.RoadRepairingMapObject.Properties;
using ITS.Core.Enums;
using ITS.Core.ManagerInterfaces.Districts;
using ITS.MapObjects.RoadRepairingMapObject.IViews;
using NetTopologySuite.Geometries;


namespace ITS.MapObjects.RoadRepairingMapObject
{
    /// <summary>
    /// Панель плагина.
    /// </summary>
    public class RoadRepairPanel : IMapObjectManager
    {
        #region Private fields

        private RoadRepair _currentRRepair;
        private LayerObject _RRepairLayer;
        private IGeometry _geometry;
        private bool _flag;
        private IStateMachine _stateMachine;
        private IMap _map;
        private ILayerManager _layerManager;
        private IRoadRepairManager _RRepairManager;
        private IToolManager _toolManager;
        private IAddressManager _addressManager;
        private IFeatureManager _featureManager;
        private IStyleManager _styleManager;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает панель плагина.
        /// </summary>
        public RoadRepairPanel()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Менеджер инструментов.
        /// </summary>
        private IToolManager ToolManager => _toolManager ?? (_toolManager = RoadRepairConstants.Container.Resolve<IToolManager>());

        /// <summary>
        /// Менеджер адресов.
        /// </summary>
        private IAddressManager AddressManager => _addressManager ?? (_addressManager = RoadRepairConstants.Container.Resolve<IAddressManager>());

        /// <summary>
        /// Машина состояний.
        /// </summary>
        private IStateMachine StateMachine => _stateMachine ?? (_stateMachine = RoadRepairConstants.Container.Resolve<IStateMachine>());

        /// <summary>
        /// Карта.
        /// </summary>
        private IMap Map => _map ?? (_map = RoadRepairConstants.Container.Resolve<IMap>());

        /// <summary>
        /// Менеджер слоёв.
        /// </summary>
        private ILayerManager LayerManager => _layerManager ?? (_layerManager = RoadRepairConstants.Container.Resolve<ILayerManager>());

        /// <summary>
        /// Менеджер дорожного ремонта.
        /// </summary>
        private IRoadRepairManager RoadRepairManager => _RRepairManager ??
                                                        (_RRepairManager = RoadRepairConstants.Container.Resolve<IRoadRepairManager>());

        /// <summary>           
        /// Получение слоя ремонта на карте или возращение пустого значения.
        /// </summary>
        private IVectorLayer RoadRepairLayerOnMap
        {
            get { return Map.Layers.FirstOrDefault(l => l.Alias == Resources.RoadRepairAlias) as IVectorLayer; }
        }

        /// <summary>     
        /// Получения слояДорожный ремонта.
        /// </summary>
        private LayerObject RoadRepairLayer => _RRepairLayer ?? (_RRepairLayer = LayerManager.GetByAlias(Map.Alias, Resources.RoadRepairAlias));

        #endregion

        #region IMapObjectManager Members

        public string ToolName
        {
            get { return RoadRepairConstants.ToolName; }
        }

        public string ToolVersion
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(2); }
        }

        #endregion

        #region Create Tool Methods

        private EditGeometryTool CreateEditGeometryTool()
        {
            return RoadRepairConstants.Container.Resolve<EditGeometryTool>();
        }

        private PolygonTool CreatePolygonTool()
        {
            return RoadRepairConstants.Container.Resolve<PolygonTool>();
        }

        private DeleteTool CreateDeleteTool()
        {
            return RoadRepairConstants.Container.Resolve<DeleteTool>();
        }

        #endregion

        #region RoadRepair Panel Buttons

        #region Создание дорожного ремонта

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Functional("AddRoadRepair", FunctionalType.Tool, typeof(RoadRepairPanelResourceHelper))]
        [ChangeEnableOn("ITS.RoadRepair.EndEdit", "ITS.RoadRepair.BeginEdit")]
        [ChangeCheckedOn("AddRoadRepair", "ChangeMapTool")]
        [ToolAction("AddRoadRepair", "ItemClick")]
        public void MapClickForPolygon(object sender, EventArgs e)
        {
           
            var tool = CreatePolygonTool();
            tool.PolygonCreated += PolygonTool_OnPolygonCreated;
            ToolManager.TurnOn(tool);
        }

        [ToolAction("AddRoadRepair", "ClickOnOtherTool")]
        public void ClickOnOtherToolPolygon(object sender, EventArgs e)
        {
            var tool = ToolManager.CurrentTool as PolygonTool;
            if (tool != null)
            {
                tool.FinishedOrCancel();
                ToolManager.TurnOff();
                tool.PolygonCreated -= PolygonTool_OnPolygonCreated;
            }
        }

        #endregion

        #region Удаление Дорожного ремонта

        [Functional("DeleteRoadRepair", FunctionalType.Tool, typeof(RoadRepairPanelResourceHelper))]
        [ChangeEnableOn("ITS.RoadRepair.EndEdit", "ITS.RoadRepair.BeginEdit")]
        [ChangeCheckedOn("DeleteRoadRepair", "ChangeMapTool")]
        [ToolAction("DeleteRoadRepair", "MapClick")]
        public void MapClickDeleteRoadRepair(object sender, EventArgs e)
        {
            var args = e as MapClickEventArgs;
            if (args == null) return;

            var info = GetFeatureByClickCoordinate(args.ClickCoordinate);

            if (info != null)
            {
                DeleteRoadRepair(info);
            }
        }

        #endregion

        #region Редактирование ремонта дороги

        [Functional("EditRoadRepair", FunctionalType.Tool, typeof(RoadRepairPanelResourceHelper))]
        [ChangeEnableOn("ITS.RoadRepair.EndEdit", "ITS.RoadRepair.BeginEdit")]
        [ChangeCheckedOn("EditRoadRepair", "ChangeMapTool")]
        [ToolAction("EditRoadRepair", "MapClick")]
        public void MapClickRoadRepairEdit(object sender, EventArgs e)
        {
            var args = e as MapClickEventArgs;
            if (args == null) return;
            var info = GetFeatureByClickCoordinate(args.ClickCoordinate);
            if (info != null)
            {
                EditRoadRepair(info);
                //StateMachine.SelectFeature(info);

                //var roadRepair = RoadRepairManager.GetByFeature(info.FeatureId);

                //if (roadRepair != null)
                //{
                //    IRoadRepairModel model = new RoadRepairModel(RoadRepairManager, FeatureManager, AddressManager);
                //    var presenter = new RoadRepairEditPresenter();
                //    IRoadRepairEditView editView = new RoadRepairEditView(presenter, model, roadRepair.FeatureObject.ID, true);
                //    editView.ShowForm();
                //}
                //StateMachine.SelectNone();
                //Map.BeginRedraw();
            }
        }

        #endregion

        #region Редактирование геометрии

        [Functional("EditGeometryRoadRepair", FunctionalType.Tool, typeof(RoadRepairPanelResourceHelper))]
        [ChangeCheckedOn("EditGeometryRoadRepair", "ChangeMapTool")]
        [ToolAction("EditGeometryRoadRepair", "MapDown")]
        public void MapDownSelectEditGeometryRoadRepair(object sender, EventArgs e)
        {
            var args = e as MapClickEventArgs;
            if (args == null)
                return;

            if (!_flag)
            {
                StateMachine.SelectNone();

                InfoOfFeature info = GetFeatureByClickCoordinate(args.ClickCoordinate);

                try
                {
                    if (info != null)
                        AsyncLoaderForm.ShowMarquee(
                            (s, ee) => { _currentRRepair = RoadRepairManager.GetByFeature(info.FeatureId); },
                            "Загрузка дорожной работы для редактирования");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        string.Format("Ошибка редактирования дорожной работы{0}{1}", Environment.NewLine, ex.Message),
                        "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (info != null)
                {
                    if (info.Feature.Geometry is IPolygon)
                    {
                        _geometry = (IGeometry)info.Feature.Geometry.Clone();
                        if (BeginEdit != null)
                        {
                            BeginEdit(this, EventArgs.Empty);
                        }
                        var infoFeature = Map.AddToTempLayer(info.Feature);
                        StateMachine.SelectFeature(infoFeature, false);
                        RendererSettings.NonDrawingFeatures.Add(info.FeatureId);

                        var tool = CreateEditGeometryTool();
                        ToolManager.TurnOn(tool);

                        _flag = true;
                    }
                }
            }
        }

        #endregion

        [Publishes("ITS.RoadRepair.BeginEdit")]
        public event EventHandler<EventArgs> BeginEdit;

        [Publishes("ITS.RoadRepair.EndEdit")]
        public event EventHandler<EventArgs> EndEdit;
        
        #region Вкладка Ведомости

        #region Сводная ведомость

        [Functional("FindRoadRepair", FunctionalType.Tool, typeof(RoadRepairPanelResourceHelper))]
        [ChangeEnableOn("ITS.RoadRepair.EndEdit", "ITS.RoadRepair.BeginEdit")]
        [ChangeCheckedOn("FindRoadRepair", "ChangeMapTool")]
        [ToolAction("FindRoadRepair", "ItemClick")]
        public void ClickFindRoadRepair(object sender, EventArgs e)
        {
            var add = RoadRepairConstants.Container.Resolve<IRoadRepairSummaryView>();
            add.View();
            Map.ClearTempLayer();
            Map.BeginRedraw();
        }

        #endregion

        #region Информация о дорожной работе

        [Functional("InfoRoadRepair", FunctionalType.Tool, typeof(RoadRepairPanelResourceHelper))]
        [ChangeEnableOn("ITS.RoadRepair.EndEdit", "ITS.RoadRepair.BeginEdit")]
        [ChangeCheckedOn("InfoRoadRepair", "ChangeMapTool")]
        [ToolAction("InfoRoadRepair", "MapClick")]
        public void MapClickRoadRepairInfo(object sender, EventArgs e)
        {
            var args = e as MapClickEventArgs;
            if (args == null)
                return;


            var info = GetFeatureByClickCoordinate(args.ClickCoordinate);

            if (info != null)
            {
                try
                {
                    // Получили ремонт.
                    RoadRepair roadrepair = null;
                    AsyncLoaderForm.ShowMarquee((s, ee) => { roadrepair = RoadRepairManager.GetByFeature(info.FeatureId); },
                        "Загрузка информации о дорожной работе");

                    // Если не получили, выходим.
                    if (roadrepair == null) return;

                    // Отображаем информацию о дорожной работе
                    var addView =
                        RoadRepairConstants.Container.Resolve<IRoadRepairInfoView>(new ParameterOverride("roadrepair",
                            roadrepair));
                    addView.ShowViewDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        string.Format("Ошибка просмотра информации о дорожной работе{0}{1}", Environment.NewLine,
                            ex.Message), "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        [Functional("WorkSortCatalog", FunctionalType.Tool, typeof(RoadRepairPanelResourceHelper))]
        [ChangeEnableOn("ITS.RoadRepair.EndEdit", "ITS.RoadRepair.BeginEdit")]
        [ChangeCheckedOn("WorkSortCatalog", "ChangeMapTool")]
        [ToolAction("WorkSortCatalog", "ItemClick")]
        public void ClickWorkSortCatalog(object sender, EventArgs e)
        {
            var add = RoadRepairConstants.Container.Resolve<IWorkSortCatalogView>();
            add.ShowView();
            //Map.ClearTempLayer();
            //Map.BeginRedraw();
        }

        #endregion

        #region Вкладка Инструменты
        #endregion

        #region Вкладка История изменений
        #endregion

        #region Вкладка Сохранение изменений

        #region Кнопка "Применить"

        [Functional("Accept", FunctionalType.Tool, typeof(RoadRepairPanelResourceHelper), true)]
        [ChangeEnableOn("", "ITS.Client.MapInterfaceController.FeatureNone")]
        [ChangeEnableOn("ITS.RoadRepair.BeginEdit", "ITS.RoadRepair.EndEdit")]
        [ToolAction("Accept", "ItemClick")]
        public void Accept(object sender, EventArgs e)
        {
            try
            {
                Map.RemoveFromTempLayer(StateMachine.SelectedFeatures.FirstOrDefault().Feature);
                var roadrepairFeature = StateMachine.SelectedFeatures.FirstOrDefault().Feature;

                if (RoadRepairLayerOnMap.Features.ContainsKey(_currentRRepair.FeatureObject.ID))
                {
                    RendererSettings.NonDrawingFeatures.Remove(_currentRRepair.FeatureObject.ID);
                }

                _currentRRepair.FeatureObject.Geometry = roadrepairFeature.Geometry;
                _currentRRepair = RoadRepairManager.Edit(_currentRRepair);
                ToolManager.TurnOff();
                StateMachine.SelectNone();
                _flag = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("Ошибка редактирования дорожной работы{0}{1}", Environment.NewLine, ex.Message),
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (EndEdit != null)
            {
                EndEdit(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Кнопка "Отмена"

        [Functional("Cancel", FunctionalType.Tool, typeof(RoadRepairPanelResourceHelper), true)]
        [ChangeEnableOn("", "ITS.Client.MapInterfaceController.FeatureNone")]
        [ChangeEnableOn("ITS.RoadRepair.BeginEdit", "ITS.RoadRepair.EndEdit")]
        [ToolAction("Cancel", "ItemClick")]
        public void Cancel(object sender, EventArgs e)
        {
            Map.RemoveFromTempLayer(StateMachine.SelectedFeatures.FirstOrDefault().Feature);

            if (RoadRepairLayerOnMap.Features.ContainsKey(_currentRRepair.FeatureObject.ID))
            {
                RendererSettings.NonDrawingFeatures.Remove(_currentRRepair.FeatureObject.ID);
            }

            ToolManager.TurnOff();

            StateMachine.SelectedFeatures.FirstOrDefault().Feature.Geometry = _geometry;
            Map.BeginRedrawRegion(StateMachine.SelectedFeatures.FirstOrDefault().Feature.Envelope);

            _flag = false;

            if (EndEdit != null)
            {
                EndEdit(this, EventArgs.Empty);
            }
            StateMachine.SelectNone();
        }

        #endregion

        #endregion

        #region Вкладка Статус

        [Publishes("IsRoadRepairDrawInProgressOn")]
        public static event EventHandler<EventArgs> IsRoadRepairDrawInProgressOn;

        [Publishes("IsRoadRepairDrawInProgressOff")]
        public static event EventHandler<EventArgs> IsRoadRepairDrawInProgressOff;

        [Publishes("IsRoadRepairDrawMadeOn")]
        public static event EventHandler<EventArgs> IsRoadRepairDrawMadeOn;

        [Publishes("IsRoadRepairDrawMadeOff")]
        public static event EventHandler<EventArgs> IsRoadRepairDrawMadeOff;

        [Publishes("IsRoadRepairDrawWillBeMadeOn")]
        public static event EventHandler<EventArgs> IsRoadRepairDrawWillBeMadeOn;

        [Publishes("IsRoadRepairDrawWillBeMadeOff")]
        public static event EventHandler<EventArgs> IsRoadRepairDrawWillBeMadeOff;

        #region Кнопка "Отобразить выполняющиеся ремонты"

        /// <summary>
        /// Обрабатывает нажатие кнопки "Выполняющиеся".
        /// </summary>
        [Functional("SelectRoadRepairInProgress", FunctionalType.Tool, typeof(RoadRepairPanelResourceHelper), selected: true)]
        [ChangeCheckedOn("IsRoadRepairDrawInProgressOn", "IsRoadRepairDrawInProgressOff")]
        [ToolAction("SelectRoadRepairInProgress", "ItemClick")]
        public void OnRoadRepairInProgressShow(object sender, EventArgs e)
        {
            RoadRepairConstants.IsDrawInProgress = !RoadRepairConstants.IsDrawInProgress;
            if (RoadRepairConstants.IsDrawInProgress)
            {
                if (IsRoadRepairDrawInProgressOn != null)
                    IsRoadRepairDrawInProgressOn(null, null);
            }
            else
            {
                if (IsRoadRepairDrawInProgressOff != null)
                    IsRoadRepairDrawInProgressOff(null, null);
            }
            Map.BeginRedraw();
        }

        #endregion

        #region Кнопка "Отобразить запланированные ремонты"

        /// <summary>
        /// Обрабатывает нажатие кнопки "Будут выполнены".
        /// </summary>
        [Functional("SelectRoadRepairWillBeMade", FunctionalType.Tool, typeof(RoadRepairPanelResourceHelper), selected: true)]
        [ChangeCheckedOn("IsRoadRepairDrawWillBeMadeOn", "IsRoadRepairDrawWillBeMadeOff")]
        [ToolAction("SelectRoadRepairWillBeMade", "ItemClick")]
        public void OnRoadRepairWillBeMadeShow(object sender, EventArgs e)
        {
            RoadRepairConstants.IsDrawWillBeMade = !RoadRepairConstants.IsDrawWillBeMade;
            if (RoadRepairConstants.IsDrawWillBeMade)
            {
                if (IsRoadRepairDrawWillBeMadeOn != null)
                    IsRoadRepairDrawWillBeMadeOn(null, null);
            }
            else
            {
                if (IsRoadRepairDrawWillBeMadeOff != null)
                    IsRoadRepairDrawWillBeMadeOff(null, null);
            }
            Map.BeginRedraw();
        }

        #endregion

        #region Кнопка "Отобразить завершенные ремонты"

        /// <summary>
        /// Обрабатывает нажатие кнопки "Завершенные".
        /// </summary>
        [Functional("SelectRoadRepairMade", FunctionalType.Tool, typeof(RoadRepairPanelResourceHelper), selected: true)]
        [ChangeCheckedOn("IsRoadRepairDrawMadeOn", "IsRoadRepairDrawMadeOff")]
        [ToolAction("SelectRoadRepairMade", "ItemClick")]
        public void OnRoadRepairMadeShow(object sender, EventArgs e)
        {
            RoadRepairConstants.IsDrawMade = !RoadRepairConstants.IsDrawMade;
            if (RoadRepairConstants.IsDrawMade)
            {
                if (IsRoadRepairDrawMadeOn != null)
                    IsRoadRepairDrawMadeOn(null, null);
            }
            else
            {
                if (IsRoadRepairDrawMadeOff != null)
                    IsRoadRepairDrawMadeOff(null, null);
            }
            Map.BeginRedraw();
        }

        #endregion

        #endregion

#endregion
        
        #region Event Handlers

        private void PolygonTool_OnPolygonCreated(IFeature feature)
        {
            var tool = ToolManager.CurrentTool as PolygonTool;
            if (tool != null)
            {
                ToolManager.TurnOff();
                if (feature != null)
                {
                    CreateNewRoadRepair(feature);
                }
                ToolManager.TurnOn(tool);
            }
        }

        #endregion

        #region Private Methods

        private InfoOfFeature GetFeatureByClickCoordinate(Coordinate coord)
        {
            var infos = Map.GetAllFeature(coord, 20);

            if (infos.Any())
            {
                InfoOfFeature info = null;
                infos = infos.Where(a => a.LayerAlias == Resources.RoadRepairAlias).ToArray();
                if (infos.Count() > 1)
                {
                    var listRoadRepair = new List<string>();
                    AsyncLoaderForm.ShowMarquee(
                        (s, ee) =>
                        {
                            listRoadRepair = infos
                                .Select(info2 => RoadRepairManager.GetByFeature(info2.FeatureId).ToString()).ToList();
                        }, "Загрузка ремонтируемых дорог");

                    var form = new SelectFeatureForm(listRoadRepair);
                    form.ShowDialog();

                    info = form.SelectedItem >= 0 ? infos[form.SelectedItem] : null;
                }
                else
                {
                    if (infos.Length > 0)
                    {
                        info = infos.Single();
                    }
                }
                return info;
            }
            return null;
        }

        private Street GetStreetByClickCoordinate(Coordinate coord)
        {
            var infos = Map.GetAllFeature(coord);

            if (infos.Any())
            {
                infos = infos.Where(a => a.LayerAlias == "ДОРОГИ").ToArray();
                var info = AddressManager.GetAddressesByFeatureObjectId(infos[0].FeatureId);
                if (info.Count() != 0)
                    return info.ToList().ElementAt(0).Street;
                return null;
            }
            return null;
        }

        private void CreateNewRoadRepair(IFeature roadrepairFeature)
        {
            if (roadrepairFeature == null)
                throw new ArgumentNullException(nameof(roadrepairFeature));
            
            var featureObject = roadrepairFeature.GetFeatureObject();
            RoadRepairLayer.AddFeature(featureObject);

            Point point = new Point(featureObject.Geometry.Centroid.Coordinate);
            List<AddressType> adrTypes = new List<AddressType>{AddressType.Highway,AddressType.Street};
            
            var address = AddressManager.GetAddressByPointClick(Map.Alias, point, adrTypes);
            //var addresses = AddressManager.GetAddressesByFeatureObjectId(featureObject.ID);
           
            
            //var street = GetStreetByClickCoordinate(featureObject.Geometry.Centroid.Coordinate);
            
            var roadrepair = new RoadRepair
            {
                FeatureObject = featureObject
            };


            var addView =
                RoadRepairConstants.Container.Resolve<IRoadRepairEditView>(new ParameterOverride("roadrepair", roadrepair),new ParameterOverride("address",address));

            addView.ShowViewDialog();
        }

        private void DeleteRoadRepair(InfoOfFeature args)
        {
            
            if (MessageBox.Show(@"Удалить дорожный ремонт?", @"Подтверждение", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var roadrepair = RoadRepairManager.GetByFeature(args.FeatureId);
                    if (roadrepair != null)
                    {
                       RoadRepairManager.Delete(roadrepair);//true-удален
                        //if (isDeleted) RoadRepairManager.DeleteAllAddressesForRoadRepair(roadrepair.ID);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $@"Ошибка удаления дорожной работы{Environment.NewLine}{ex.Message}",
                        @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditRoadRepair(InfoOfFeature args)
        {
            StateMachine.SelectFeature(args);
            try
            {
                RoadRepair roadrepair = null;
                AsyncLoaderForm.ShowMarquee((s, ee) => { roadrepair = RoadRepairManager.GetByFeature(args.FeatureId); },
                    "Загрузка дорожной работы для редактирования");

                ///TODO: ПОТОМ УБРАТЬ
                Point point = new Point(roadrepair.FeatureObject.Geometry.Centroid.Coordinate);
                List<AddressType> adrTypes = new List<AddressType> { AddressType.Highway, AddressType.Street };

                var address = AddressManager.GetAddressByPointClick(Map.Alias, point, adrTypes);
                ///
                var addView =
                    RoadRepairConstants.Container.Resolve<IRoadRepairEditView>(new ParameterOverride("roadrepair",
                        roadrepair), new ParameterOverride("address", address));
                addView.ShowViewDialog();
                StateMachine.SelectNone();
                Map.BeginRedraw();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $@"Ошибка редактирования дорожного ремонта{Environment.NewLine}{ex.Message}",
                    @"Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

       

        #endregion
    }
}