using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GeoAPI.Geometries;
using GeoAPI.Operations.Buffer;
using ITS.Core.Enums;
using ITS.Core.RoadRepairing.Domain;
using ITS.Core.RoadRepairing.ManagerInterfaces;
using ITS.GIS.CoreToGeoTranslators;
using ITS.GIS.MapEntities;
using ITS.GIS.MapEntities.Styles;
using ITS.MapObjects.RoadRepairingMapObject.Views;
using ITS.ProjectBase.Utils.AsyncWorking;
using Microsoft.Practices.Unity;
using ITS.Core.RoadRepairing.Domain.Enums;
using System.Drawing;
using ITS.Core.Domain.Districts;
using ITS.MapObjects.RoadRepairingMapObject.EventArgses;
using ITS.MapObjects.RoadRepairingMapObject.IPresenters;
using ITS.MapObjects.RoadRepairingMapObject.IViews;
using ITS.MapObjects.RoadRepairingMapObject.Reports;

namespace ITS.MapObjects.RoadRepairingMapObject.Presenters
{
    /// <summary>
    /// Представитель информации о дорожном ремонте.
    /// </summary>
    public class RoadRepairSummaryPresenter : IRoadRepairFindPresenter
    {
        private readonly IRoadRepairManager _roadrepairManager;

        public RoadRepairSummaryPresenter()
        {
        }

        public RoadRepairSummaryPresenter(IRoadRepairManager roadRepairManager)
        {
            _roadrepairManager = roadRepairManager;
        }

        [Dependency]
        public IMap Map { get; set; }

        #region IPresenter Members

        public void Init(IRoadRepairSummaryView view)
        {
            view.LoadRoadRepair += Load_Handler;
            view.EditRoadRepair += EditRoadRepair_Handler;
            view.ShowOnMap += ShowOnMap_Handler;
            view.ExportToWord += Export_Handler;
            InitView(view);
        }

        #endregion

        private void InitView(IRoadRepairSummaryView view)
        {
            view.FillRoadRepairFilters(new Dictionary<Core.Domain.Filters.Filter, object>
            {
                {new Core.Domain.Filters.Filter {PropertyName = "Идентификатор", FilterType=FilterType.Id,PropertyPath="RoadRepairId"},null},
                {new Core.Domain.Filters.Filter {PropertyName = "Адрес", FilterType=FilterType.String,PropertyPath="Address"},null},
                {new Core.Domain.Filters.Filter {PropertyName = "Тип ремонта", FilterType=FilterType.Selector,PropertyPath="RepairType"},GetTypeTree()},
                {new Core.Domain.Filters.Filter {PropertyName = "Тип работ", FilterType=FilterType.Selector,PropertyPath="WorkType"},GetWorkTypeTree()},
                {new Core.Domain.Filters.Filter {PropertyName = "Описание работ", FilterType=FilterType.String,PropertyPath="WorkSort"},null},
                //{new Core.Domain.Filters.Filter {PropertyName = "Примечания", FilterType=FilterType.String,PropertyPath="Note"},null},
                {new Core.Domain.Filters.Filter {PropertyName = "Статус",FilterType=FilterType.Selector,PropertyPath="Status"},GetStatusTree()},
                {new Core.Domain.Filters.Filter {PropertyName = "Исполнитель работ", FilterType=FilterType.String,PropertyPath="Performer"},null},
                {new Core.Domain.Filters.Filter {PropertyName = "Заказчик работ", FilterType=FilterType.String,PropertyPath="Customer"},null},
                {new Core.Domain.Filters.Filter {PropertyName = "Владелец автодороги", FilterType=FilterType.String,PropertyPath="Owner"},null},
                {new Core.Domain.Filters.Filter {PropertyName = "Дата начала", FilterType=FilterType.Date,PropertyPath="RepairStart"},null},
                {new Core.Domain.Filters.Filter {PropertyName = "Дата окончания", FilterType=FilterType.Date,PropertyPath="RepairEnd"},null},
                {new Core.Domain.Filters.Filter {PropertyName = "Дата начала фактическая", FilterType=FilterType.Date,PropertyPath="RepairStartFact"},null},
                {new Core.Domain.Filters.Filter {PropertyName = "Дата окончания фактическая", FilterType=FilterType.Date,PropertyPath="RepairEndFact"},null}
            });
        }
        private Dictionary<TreeNode, object> GetTypeTree()
        {
            return
                Enum.GetValues(typeof(RepairType))
                    .Cast<RepairType>()
                    .ToDictionary<RepairType, TreeNode, object>(type => new TreeNode(RepairTypeHelper.GetName(type)), type => type);
        }
        private Dictionary<TreeNode, object> GetWorkTypeTree()
        {
            return
                Enum.GetValues(typeof(WorkType))
                    .Cast<WorkType>()
                    .ToDictionary<WorkType, TreeNode, object>(type => new TreeNode(WorkTypeHelper.GetName(type)), type => type);
        }
        
        //private Dictionary<TreeNode, object> GetWorkSortTree()
        //{
        //    return
        //        Enum.GetValues(typeof(WorkSort))
        //            .Cast<WorkSort>()
        //            .ToDictionary<WorkSort, TreeNode, object>(type => new TreeNode(WorkSortHelper.GetString(type)), type => type);
        //}
        private Dictionary<TreeNode, object> GetStatusTree()
        {
            return
                Enum.GetValues(typeof(RoadRepairStatus))
                    .Cast<RoadRepairStatus>()
                    .ToDictionary<RoadRepairStatus, TreeNode, object>(type => new TreeNode(StatusTypeHelper.GetName(type)), type => type);
        }
        private void Load_Handler(object sender, EventArgs e)
        {
            var view = (IRoadRepairSummaryView)sender;

            var roadrepairsFilters =
                new List<ITS.Core.Domain.Filters.Filter>(new[]
                {
                    new ITS.Core.Domain.Filters.Filter
                    {
                        FilterType = FilterType.String,
                        Function = FilterFunc.Eq,
                        PropertyPath = "FeatureObject.Layer.Map.Alias",
                        Values = new[] {Map.Alias},
                        PropertyName = "Карта"
                    }
                });
            roadrepairsFilters.AddRange(view.RoadRepairFilters);


            IEnumerable<RoadRepairDTO> filteredRoadRepair = null;
            AsyncLoaderForm.ShowMarquee((a, b) =>
                filteredRoadRepair = _roadrepairManager.FilterRoadRepairs(roadrepairsFilters), "Идет загрузка дорожных работ");
            view.Model = filteredRoadRepair;
        }

        private void EditRoadRepair_Handler(object sender, RoadRepairDTOEventArgs e)
        {
            RoadRepair roadrepair = _roadrepairManager.GetByFeature(e.RoadRepair.FeatureObject.ID);
            var addView = RoadRepairConstants.Container.Resolve<IRoadRepairEditView>(new ParameterOverride("roadrepair", roadrepair), new ParameterOverride("address",new Address()));
            addView.ShowViewDialog();
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки перемещения к месторасположению 
        /// </summary>
        private void ShowOnMap_Handler(object sender, RoadRepairDTOEventArgs e)
        {
            Map.ClearTempLayer();
            Map.CoordSys.ChangeLocationTo(e.RoadRepair.FeatureObject.Geometry.Centroid.X, e.RoadRepair.FeatureObject.Geometry.Centroid.Y);

            IGeometry geometry = e.RoadRepair.FeatureObject.GetFeature().Geometry.Buffer(0.2, 4, EndCapStyle.Flat);
            Map.AddToTempLayer(new Feature(geometry.Difference(e.RoadRepair.FeatureObject.Geometry), new AreaStyle(new InteriorStyle(Color.Green), new LineStyle(Color.Green, 2f))));

            Map.BeginRedraw();
        }

        private void Export_Handler(object sender, EventArgs e)
        {
            var view = (IRoadRepairSummaryView)sender;
            if (view.Model != null)
            {
                var dialog = new SaveFileDialog();
                dialog.Filter = "Doc files (*.rtf)|*.rtf";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    AsyncLoaderForm.ShowMarquee((s, ee) =>
                        {
                            try
                            {
                                RoadRepairSummaryReport.ReportMake(dialog.FileName, view.Model.ToList());
                                MessageBox.Show("Сводная ведомость успешно экспортирована в Word", "Экспорт в Word...");

                                ReportHelper.Open(dialog.FileName);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Произошла ошибка экспорта", "Экспорт в Word...");
                            }
                        },
                        "Идет формирование отчета...");

                }
            }
            else MessageBox.Show("Сводная ведомость пуста!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
