using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ITS.Core.RoadRepairing.Domain;
using ITS.Core.RoadRepairing.Domain.Enums;
using ITS.MapObjects.BaseMapObject.FilterControls;
using ITS.MapObjects.RoadRepairingMapObject.EventArgses;
using ITS.MapObjects.RoadRepairingMapObject.IPresenters;
using ITS.MapObjects.RoadRepairingMapObject.IViews;
using ITS.MapObjects.RoadRepairingMapObject.Presenters;

namespace ITS.MapObjects.RoadRepairingMapObject.Views
{
    /// <summary>
    /// Форма поиска
    /// </summary>
   
    public partial class RoadRepairSummaryView : Form, IRoadRepairSummaryView
    {
        #region Private Fields and Consts
       
        private const string FeatureObjectColumn = "FeatureObject";
        private const string IDColumn = "RoadRepairId";
        private const string RepairTypeColumn = "RepairType";
        private const string WorkTypeColumn = "WorkType";
        private const string WorkSortColumn = "WorkSort";
        private const string StatusColumn = "Status";
        private const string AddressColumn = "Address";
        private const string CustomerColumn = "Performer";
        private const string PerformerColumn = "Customer";
        private const string OwnerColumn = "Owner";
        private const string RepairStartColumn = "RepairStart";
        private const string RepairEndColumn = "RepairEnd";
        private const string RepairStartFactColumn = "RepairStartFact";
        private const string RepairEndFactColumn = "RepairEndFact";

        private static readonly Dictionary<string, string> RRColumnHeaders;
        private static readonly Dictionary<string, int> RRColumnWidths;
        private IEnumerable<RoadRepairDTO> _model;

        #endregion

        #region Constructors

        static RoadRepairSummaryView()
        {
            RRColumnHeaders = new Dictionary<string, string>();
            RRColumnWidths = new Dictionary<string, int>();

            RRColumnHeaders[IDColumn] = "Идентификатор";
            RRColumnHeaders[AddressColumn] = "Адрес";
            RRColumnHeaders[PerformerColumn] = "Исполнитель работ";
            RRColumnHeaders[OwnerColumn] = "Владелец автодороги";
            RRColumnHeaders[CustomerColumn] = "Заказчик работ";
            RRColumnHeaders[RepairTypeColumn] = "Класс работ";
            RRColumnHeaders[WorkTypeColumn] = "Вид работ";
            RRColumnHeaders[WorkSortColumn] = "Описание работ";
            RRColumnHeaders[StatusColumn] = "Статус работ";
            RRColumnHeaders[RepairStartColumn] = "Дата начала";
            RRColumnHeaders[RepairEndColumn] = "Дата окончания";
            RRColumnHeaders[RepairStartFactColumn] = "Дата начала фактическая";
            RRColumnHeaders[RepairEndFactColumn] = "Дата окончания фактическая";


            //RRColumnWidths[AddressColumn] = 250;
            //RRColumnWidths[NoteColumn] = 250;
            //RRColumnWidths[RepairTypeColumn] = 50;
            //RRColumnWidths[RepairStatusColumn] = 50;
            //RRColumnWidths[WorkTypeColumn] = 50;
            //RRColumnWidths[WorkSortColumn] = 50;
            //RRColumnWidths[RepairStartColumn] = 50;
            //RRColumnWidths[RepairEndColumn] = 50;

        }
        public RoadRepairSummaryView()
            : this(new RoadRepairSummaryPresenter())
        {
        }

        public RoadRepairSummaryView(IRoadRepairFindPresenter presenter)
        {
            InitializeComponent();
            InitRoadRepairListView(RRColumnHeaders, RRColumnWidths);
            presenter.Init(this);
        }
        #endregion
        
        #region Implementation of IRoadRepairFindView

        public IEnumerable<RoadRepairDTO> Model
        {
            get => _model;
            set
            {
                _model = value ?? new List<RoadRepairDTO>();
                AddItemsToRoadRepairList(_model);
            }
        }

        public ICollection<ITS.Core.Domain.Filters.Filter> RoadRepairFilters
        {
            get { return flowPanelAddedRoadRepairFilters.Controls.OfType<FilterContainer>().Select(fc => fc.GetFilter()).ToList(); }
        }

        public void FillRoadRepairFilters(IDictionary<ITS.Core.Domain.Filters.Filter, object> filterDictionary)
        {
            filterValueControlRoadrepair.FillFilters(filterDictionary);
        }

        public event EventHandler<EventArgs> LoadRoadRepair;

        public event EventHandler<RoadRepairDTOEventArgs> ShowOnMap;

        public event EventHandler<RoadRepairDTOEventArgs> EditRoadRepair;

        public event EventHandler<EventArgs> ExportToWord;

        public void View()
        {
            ShowDialog();
        }
        #endregion

        #region Private Fields

        private void InitRoadRepairListView(Dictionary<string, string> columnHeaders,
            Dictionary<string, int> columnWidths)
        {
            dgRoadrepairs.DataSource = new BindingList<RoadRepairDTO>();
            dgRoadrepairs.Columns[RepairTypeColumn].HeaderText = columnHeaders[RepairTypeColumn];
            dgRoadrepairs.Columns[WorkTypeColumn].HeaderText = columnHeaders[WorkTypeColumn];
            dgRoadrepairs.Columns[WorkSortColumn].HeaderText = columnHeaders[WorkSortColumn];
            dgRoadrepairs.Columns[AddressColumn].HeaderText = columnHeaders[AddressColumn];
            dgRoadrepairs.Columns[PerformerColumn].HeaderText = columnHeaders[PerformerColumn];
            dgRoadrepairs.Columns[OwnerColumn].HeaderText = columnHeaders[OwnerColumn];
            dgRoadrepairs.Columns[CustomerColumn].HeaderText = columnHeaders[CustomerColumn];
            dgRoadrepairs.Columns[StatusColumn].HeaderText = columnHeaders[StatusColumn];
            dgRoadrepairs.Columns[FeatureObjectColumn].Visible = false;
            //dgRoadrepairs.Columns[IDColumn].HeaderText = columnHeaders[IDColumn];
            dgRoadrepairs.Columns[IDColumn].Visible = false;
            
            //dgRoadrepairs.Columns[IDColumn].HeaderText = columnHeaders[IDColumn];


          

            dgRoadrepairs.Columns[RepairStartColumn].HeaderText = columnHeaders[RepairStartColumn];
            dgRoadrepairs.Columns[RepairEndColumn].HeaderText = columnHeaders[RepairEndColumn];
            dgRoadrepairs.Columns[RepairStartFactColumn].HeaderText = columnHeaders[RepairStartFactColumn];
            dgRoadrepairs.Columns[RepairEndFactColumn].HeaderText = columnHeaders[RepairEndFactColumn];

            //dgRoadrepairs.Columns[AddressColumn].MinimumWidth = 100;
            //dgRoadrepairs.Columns[NoteColumn].MinimumWidth = 50;
            //dgRoadrepairs.Columns[RepairStartColumn].MinimumWidth = 50;
            //dgRoadrepairs.Columns[RepairEndColumn].MinimumWidth = 50;
            //dgRoadrepairs.Columns[RepairTypeColumn].MinimumWidth = 50;
            //dgRoadrepairs.Columns[WorkTypeColumn].MinimumWidth =     50;
            //dgRoadrepairs.Columns[WorkSortColumn].MinimumWidth =    50;
            //dgRoadrepairs.Columns[RepairStatusColumn].MinimumWidth = 50;


           
            dgRoadrepairs.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgRoadrepairs.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dgRoadrepairs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgRoadrepairs.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgRoadrepairs.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgRoadrepairs.Columns[0].Width = 20;
            dgRoadrepairs.Columns[1].Width = 20;
            dgRoadrepairs.AutoResizeColumns();
        }

        private void AddItemsToRoadRepairList(IEnumerable<RoadRepairDTO> roadrepairs)
        {
            dgRoadrepairs.DataSource = roadrepairs;
            if (!roadrepairs.Any())
                MessageBox.Show("Данные по критериям поиска не найдены!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Обработка отображения данных в таблице TODO:взять отсюда отображение данных и добавить в справочник
        /// </summary>
        private void RoadRepairGridCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (dgRoadrepairs.Columns[e.ColumnIndex].Name)
            {
                case IDColumn:
                {
                    var id = ((RoadRepairDTO) dgRoadrepairs.Rows[e.RowIndex].DataBoundItem).RoadRepairId;
                    e.Value = id.ToString();
                    e.FormattingApplied = true;
                    break;
                }
                case AddressColumn:
                {
                    var address = ((RoadRepairDTO) dgRoadrepairs.Rows[e.RowIndex].DataBoundItem).Address;
                    e.Value = address == null ? "не определён" : address.FullAddress;
                    e.FormattingApplied = true;
                    break;
                }
                case RepairTypeColumn:
                {
                    var repairType = ((RoadRepairDTO) dgRoadrepairs.Rows[e.RowIndex].DataBoundItem).RepairType;
                    e.Value = RepairTypeHelper.GetName(repairType);
                    e.FormattingApplied = true;
                    break;
                }

                case WorkTypeColumn:
                {
                    var workType = ((RoadRepairDTO) dgRoadrepairs.Rows[e.RowIndex].DataBoundItem).WorkType;
                    e.Value = WorkTypeHelper.GetName(workType);
                    e.FormattingApplied = true;
                    break;
                }

                case WorkSortColumn:
                {
                    var workSort = ((RoadRepairDTO) dgRoadrepairs.Rows[e.RowIndex].DataBoundItem).WorkSort;
                    e.Value = workSort;
                    e.FormattingApplied = true;
                    break;
                }
                case PerformerColumn:
                {
                    var performer = ((RoadRepairDTO) dgRoadrepairs.Rows[e.RowIndex].DataBoundItem).Performer;
                    e.Value = performer != null ? performer.Name : "";
                    e.FormattingApplied = true;
                    break;
                }
                case CustomerColumn:
                {
                    var customer = ((RoadRepairDTO)dgRoadrepairs.Rows[e.RowIndex].DataBoundItem).Customer;
                    e.Value = customer != null ? customer.ToString() : "";
                    e.FormattingApplied = true;
                    break;
                }
                case OwnerColumn:
                {
                    var owner = ((RoadRepairDTO)dgRoadrepairs.Rows[e.RowIndex].DataBoundItem).Owner;
                    e.Value = owner != null ? owner.ToString() : "";
                    e.FormattingApplied = true;
                    break;
                }
                case StatusColumn:
                {
                    var status = ((RoadRepairDTO) dgRoadrepairs.Rows[e.RowIndex].DataBoundItem).Status;
                    e.Value = StatusTypeHelper.GetName(status);
                    e.FormattingApplied = true;
                    break;
                }

                case RepairStartColumn:
                {
                    var repairStart = ((RoadRepairDTO) dgRoadrepairs.Rows[e.RowIndex].DataBoundItem).RepairStart;
                    e.Value = repairStart?.ToShortDateString() ?? "";
                    e.FormattingApplied = true;
                    break;
                }

                case RepairEndColumn:
                {
                    var repairEnd = ((RoadRepairDTO) dgRoadrepairs.Rows[e.RowIndex].DataBoundItem).RepairEnd;
                    e.Value = repairEnd?.ToShortDateString() ?? "";
                    e.FormattingApplied = true;
                    break;
                }
                case RepairStartFactColumn:
                {
                    var repairStart = ((RoadRepairDTO)dgRoadrepairs.Rows[e.RowIndex].DataBoundItem).RepairStartFact;
                    e.Value = repairStart?.ToShortDateString() ?? "";
                    e.FormattingApplied = true;
                    break;
                }

                case RepairEndFactColumn:
                {
                    var repairEnd = ((RoadRepairDTO)dgRoadrepairs.Rows[e.RowIndex].DataBoundItem).RepairEndFact;
                    e.Value = repairEnd?.ToShortDateString() ?? "";
                    e.FormattingApplied = true;
                    break;
                }
            }
        }

        private void DropFilterProperties()
        {
            filterValueControlRoadrepair.AddFilterControls(flowPanelAddedRoadRepairFilters.Controls.OfType<FilterContainer>().Select(fc => fc.FilterControl));
            flowPanelAddedRoadRepairFilters.Controls.Clear();
        }
        #endregion

        #region EventHandlers

        private void ApplyFilter_ClickHandler(object sender, EventArgs e)
        {
            LoadRoadRepair?.Invoke(this, EventArgs.Empty);
        }

        private void DropFilter_ClickHandler(object sender, EventArgs e)
        {
            DropFilterProperties();
        }

        private void ExportWord_ClickHandler(object sender, EventArgs e)
        {
            ExportToWord?.Invoke(this, EventArgs.Empty);
        }

        private void RoadrepairsGrid_CellContentClickHandler(object sender, DataGridViewCellEventArgs e)
        {
            if (dgRoadrepairs.Columns[e.ColumnIndex].Name == EditRoadRepairColumn.Name)
            {
                EditRoadRepair?.Invoke(this, new RoadRepairDTOEventArgs((RoadRepairDTO)dgRoadrepairs.Rows[e.RowIndex].DataBoundItem));
            }
            if (dgRoadrepairs.Columns[e.ColumnIndex].Name == ShowOnMapColumn.Name)
            {
                ShowOnMap?.Invoke(this, new RoadRepairDTOEventArgs((RoadRepairDTO)dgRoadrepairs.Rows[e.RowIndex].DataBoundItem));
            }
        }

        private void btnAddRoadRepairFilter_Click(object sender, EventArgs e)
        {
            var f = filterValueControlRoadrepair.GetFilterControl();
            if (f != null)
            {
                var fc = new FilterContainer(f);
                flowPanelAddedRoadRepairFilters.Controls.Add(fc);
                fc.Delete += FcOnRoadRepairFilterDelete;
            }
        }

        private void FcOnRoadRepairFilterDelete(FilterContainer fc)
        {
            flowPanelAddedRoadRepairFilters.Controls.Remove(fc);
            filterValueControlRoadrepair.AddFilterControl(fc.FilterControl);
        }
        
    #endregion
    }
}
