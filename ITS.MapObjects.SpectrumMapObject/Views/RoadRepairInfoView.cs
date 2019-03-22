using ITS.Core.RoadRepairing.Domain;
using ITS.Core.RoadRepairing.Domain.Enums;
using ITS.Core.RoadRepairing.ManagerInterfaces;
using ITS.MapObjects.RoadRepairingMapObject.IViews;
using Microsoft.Practices.Unity;

namespace ITS.MapObjects.RoadRepairingMapObject.Views
{
    /// <summary>
    /// Форма информации о дорожном ремонте.
    /// </summary>
    public partial class RoadRepairInfoView : BaseView, IRoadRepairInfoView
    {
        #region Constructors

        /// <summary>
        /// Конструктор отображения информации о дорожном ремонте.
        /// </summary>
        /// <param name="roadrepair">ремонт.</param>
        public RoadRepairInfoView(RoadRepair roadrepair)
        {
            InitializeComponent();
            roadRepairManager = RoadRepairConstants.Container.Resolve<IRoadRepairManager>();
            RoadRepair = roadrepair;
        }

        #endregion

        #region Fields

        private RoadRepair _roadrepair;
        private readonly IRoadRepairManager roadRepairManager;
        private const string STRING_OrgNotSet = "<Не задан>";

        #endregion

        #region Properties

        public RoadRepair RoadRepair
        {
            get  => _roadrepair; 
            set
            {
                _roadrepair = value;
                if (_roadrepair != null)
                {
                   
                    labelStatus.Text = _roadrepair.StatusAsString.ToLower();
                    labelRepairType.Text = _roadrepair.TypeAsString.ToLower();
                    string workType = _roadrepair.WorkType==WorkType.Others?"":
                        "Работы " + _roadrepair.WorkTypeAsString.ToLower() + ", ";
                    tbWorkSort.Text = workType + _roadrepair.WorkSort.ToLower();
                    var probAddress = roadRepairManager.GetAddressByRoadRepairId(_roadrepair.ID);
                    tbAddress.Text = probAddress == null ? "Не определён" +
                                                           "" : probAddress.FullAddress;
                    labelStart.Text = _roadrepair.RepairStart?.ToShortDateString() ?? "";
                    labelEnd.Text = _roadrepair.RepairEnd?.ToShortDateString() ?? "";
                    labelStartFact.Text = _roadrepair.RepairStartFact?.ToShortDateString() ?? "";
                    labelEndFact.Text = _roadrepair.RepairEndFact?.ToShortDateString() ?? "";
                    tbOwner.Text = _roadrepair.Owner != null
                        ? _roadrepair.Owner.ToString()
                        : STRING_OrgNotSet;
                    tbPerformer.Text = _roadrepair.Performer != null
                        ? _roadrepair.Performer.ToString()
                        : STRING_OrgNotSet;
                    tbCustomer.Text = _roadrepair.Customer != null
                        ? _roadrepair.Customer.ToString()
                        : STRING_OrgNotSet;
                }
                
            }
        }
        #endregion

        private void groupBox2_Enter(object sender, System.EventArgs e)
        {

        }

        private void label15_Click(object sender, System.EventArgs e)
        {

        }
    }
}