using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ITS.Core.Domain.Districts;
using ITS.Core.Domain.Organizations;
using ITS.Core.Enums;
using ITS.Core.RoadRepairing.Domain;
using ITS.Core.RoadRepairing.Domain.Enums;
using ITS.MapObjects.EditBaseDictionariesPlugin;
using ITS.MapObjects.EditBaseDictionariesPlugin.ViewInterfaces.Organizations;
using ITS.MapObjects.RoadRepairingMapObject.IModels;
using ITS.MapObjects.RoadRepairingMapObject.IPresenters;
using ITS.MapObjects.RoadRepairingMapObject.IViews;
using Microsoft.Practices.Unity;
using NHibernate.Util;


namespace ITS.MapObjects.RoadRepairingMapObject.Views
{
    /// <summary>
    /// Форма добавления и изменения .
    /// </summary>
    public partial class RoadRepairEditView : BaseView, IRoadRepairEditView
    {
        #region Fields

        private RoadRepair _roadrepair;

        private bool _isEdit;
        private const string STRING_OrgNotSet = "<Не задан>";
        private const string STRING_AdrNotSet = "<Адрес не определен>";
        private Address _address;
        #endregion


        #region Constructors

        /// <summary>
        /// Конструктор добавления или редактирования ремонта дороги.
        /// </summary>
        /// <param name="presenter">Представитель.</param>
        /// <param name="model">Модель.</param>
        /// <param name="roadrepair">Работа</param>
        /// <param name="address">Адрес</param>
        public RoadRepairEditView(IRoadRepairEditPresenter presenter, IRoadRepairModel model, RoadRepair roadrepair,
            Address address)
        {
            InitializeComponent();

            //cB_RepairStatusType.DataSource = Enum.GetValues(typeof(RoadRepairStatus)).Cast<RoadRepairStatus>()
            //    .Select(t => t.GetDescription()).ToList();
            //cB_RepairType.DataSource = Enum.GetValues(typeof(RepairType)).Cast<RepairType>()
            //    .Select(t => t.GetDescription()).ToList();
            //cB_WorkType.DataSource = Enum.GetValues(typeof(WorkType)).Cast<WorkType>().Select(t => t.GetDescription())
            //    .ToList();
            ////cB_WorkSort.DataSource = Enum.GetValues(typeof(WorkSort)).Cast<WorkSort>().Select(t => t.GetDescription()).ToList();
            //cB_WorkSort.DropDownStyle = ComboBoxStyle.DropDownList;
            //cB_WorkSort.DrawMode = DrawMode.OwnerDrawFixed;
            //cB_WorkSort.DrawItem += cB_WorkSort_DrawItem;
            //cB_WorkSort.DropDownClosed += cB_WorkSort_DropDownClosed;
            //cB_WorkSort.MouseLeave += cB_WorkSort_Leave;
            presenter.Init(this, model);
            //var repairType = RepairTypeHelper.GetByName(cB_RepairType.SelectedItem.ToString());
            //var workType = WorkTypeHelper.GetByName(cB_WorkType.SelectedItem.ToString());
            //cB_WorkSort.DataSource = GetDescripts((int) repairType, (int) workType);
            //cB_WorkSort.SelectedItem = cB_WorkSort.Items.First();
            var rts = RepairTypeHelper.GetNames();
            var wts = WorkTypeHelper.GetNames();
            foreach (var elem in rts)
            {
                treeWorkSorts.Nodes.Add(elem.Key.ToString(), elem.Value);
                foreach (var wt in wts)
                {
                    var describes = GetDescripts((int)elem.Key, (int)wt.Key);
                    if (describes.Count > 0)
                    {
                        treeWorkSorts.Nodes[elem.Key.ToString()].Nodes.Add(wt.Key.ToString(), wt.Value);

                        foreach (var desc in describes)
                        {
                            treeWorkSorts.Nodes[elem.Key.ToString()].Nodes[wt.Key.ToString()].Nodes.Add(desc);
                        }
                    }
                }
            }

            _roadrepair = roadrepair;
            _address = address;
            _isEdit = !roadrepair.IsTransient(); //isTransient == true - не сохранен в базе
            if (_isEdit)
            {
                FillControlsWithData();
            }

        }

        #endregion

        #region forToolTip

        //private void cB_WorkType_MouseHover(object sender, EventArgs e)
        //{
        //    if (!cB_WorkType.DroppedDown &&
        //        TextRenderer.MeasureText(cB_WorkType.SelectedItem.ToString(), cB_WorkType.Font).Width >
        //        cB_WorkType.Width)
        //    {
        //        toolTipDescribe.Show(cB_WorkType.SelectedItem.ToString(), cB_WorkType, cB_WorkType.Location.X,
        //            cB_WorkType.Location.Y);
        //    }
        //}

        //private void cB_WorkSort_MouseHover(object sender, EventArgs e)
        //{
        //    if (cB_WorkSort.SelectedItem != null && !cB_WorkSort.DroppedDown &&
        //        TextRenderer.MeasureText(cB_WorkSort.SelectedItem.ToString(), cB_WorkSort.Font).Width >
        //        cB_WorkSort.Width)
        //    {
        //        toolTipDescribe.Show(cB_WorkSort.SelectedItem.ToString(), cB_WorkSort, cB_WorkSort.Location.X,
        //            cB_WorkSort.Location.Y);
        //    }
        //}

        //private void cB_WorkSort_DropDownClosed(object sender, EventArgs e)
        //{
        //    toolTipDescribe.Hide(cB_WorkSort);
        //}

        //private void cB_WorkSort_Leave(object sender, EventArgs e)
        //{
        //    toolTipDescribe.Hide(cB_WorkSort);
        //}

        //private void cB_WorkSort_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //    if (e.Index < 0)
        //    {
        //        return;
        //    }

        //    string text = cB_WorkSort.GetItemText(cB_WorkSort.Items[e.Index]);
        //    e.DrawBackground();
        //    using (SolidBrush br = new SolidBrush(e.ForeColor))
        //    {
        //        e.Graphics.DrawString(text, e.Font, br, e.Bounds);
        //    }

        //    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected && cB_WorkSort.DroppedDown)
        //    {
        //        if (TextRenderer.MeasureText(text, cB_WorkSort.Font).Width > cB_WorkSort.Width)
        //        {
        //            toolTipDescribe.Show(text, cB_WorkSort, e.Bounds.Right, e.Bounds.Bottom);
        //        }
        //        else
        //        {
        //            toolTipDescribe.Hide(cB_WorkSort);
        //        }
        //    }

        //    e.DrawFocusRectangle();
        //}

        #endregion

        #region Properties

        ///// <summary>
        ///// Редактируемый ремонт дороги
        ///// </summary>
        //public RoadRepair EditableRoadRepair
        //{
        //    get
        //    {
        //        _roadrepair.RepairStart = checkRepairStart.Checked ? (DateTime?) dtPickerStart.Value : null;
        //        _roadrepair.RepairEnd = checkRepairEnd.Checked ? (DateTime?) dtPickerEnd.Value : null;
        //        _roadrepair.RepairStartFact =
        //            checkRepairStartFact.Checked ? (DateTime?) dtPickerStartFact.Value : null;
        //        _roadrepair.RepairEndFact = checkRepairEndFact.Checked ? (DateTime?) dtPickerEndFact.Value : null;
        //        _roadrepair.RepairType = RepairTypeHelper.GetByName(cB_RepairType.SelectedItem.ToString());
        //        _roadrepair.WorkType = WorkTypeHelper.GetByName(cB_WorkType.SelectedItem.ToString());
        //        _roadrepair.WorkSort = cB_WorkSort.SelectedItem?.ToString() ??
        //                               GetDescripts((int) _roadrepair.RepairType, (int) _roadrepair.WorkType)
        //                                   .FirstOrNull().ToString();
        //        _roadrepair.Status = StatusTypeHelper.GetByName(cB_RepairStatusType.SelectedItem.ToString());


        //        return _roadrepair;

        //    }
        //    set
        //    {
        //        _roadrepair = value;
        //        if (_roadrepair != null && _roadrepair.ID != 0)
        //        {
        //            dtPickerStart.Value = _roadrepair.RepairStart ?? DateTime.Now;
        //            dtPickerEnd.Value = _roadrepair.RepairEnd ?? DateTime.Now;
        //            dtPickerStartFact.Value = _roadrepair.RepairStartFact ?? DateTime.Now;
        //            dtPickerEndFact.Value = _roadrepair.RepairEndFact ?? DateTime.Now;
        //            cB_RepairType.SelectedItem = _roadrepair.RepairType;
        //            cB_WorkType.SelectedItem = _roadrepair.WorkType;
        //            if (cB_WorkSort.DataSource == null)
        //            {
        //                cB_WorkSort.DataSource = GetDescripts((int) _roadrepair.RepairType, (int) _roadrepair.WorkType);
        //            }

        //            cB_WorkSort.SelectedItem = _roadrepair.WorkSort;
        //            cB_RepairStatusType.SelectedItem = _roadrepair.Status;
        //            tbOwner.Text = _roadrepair.Owner != null
        //                ? _roadrepair.Owner.ToString()
        //                : STRING_OrgNotSet;
        //            tbPerformer.Text = _roadrepair.Performer != null
        //                ? _roadrepair.Performer.ToString()
        //                : STRING_OrgNotSet;
        //            tbCustomer.Text = _roadrepair.Customer != null
        //                ? _roadrepair.Customer.ToString()
        //                : STRING_OrgNotSet;
        //            UpdateModel?.Invoke();
        //        }
        //    }
        //}

        public List<WorkSort> WorkSorts { private get; set; }

        #endregion

        #region Private Methods

        private List<string> GetDescripts(int repairType, int workType)
        {
            var descs =
                from workSort in WorkSorts
                where (int) workSort.RepairType == repairType
                      && (int) workSort.WorkType == workType
                select workSort.Description;
            return descs.ToList();
        }

        private void getOrganizationView()
        {
            var toolName = EditBaseDictionariesPanelConfigResolver.ResourceManager.GetObject("ToolName");
            if (toolName == null) return;
            RoadRepairConstants.OrganizationView = ProjectBase.Utils.Container.Container
                .PluginContainer(toolName.ToString())
                .Resolve<ISelectOrganizationView>(
                    new ParameterOverrides {{"organization", new Organization()}});
        }

        private RoadRepair GetRoadRepair(short selectFlag)
        {
            _roadrepair.Note = textBoxNote.Text;
            _roadrepair.RepairStart = checkRepairStart.Checked ? (DateTime?) dtPickerStart.Value : null;
            _roadrepair.RepairEnd = checkRepairEnd.Checked ? (DateTime?) dtPickerEnd.Value : null;
            _roadrepair.RepairStartFact = _roadrepair.RepairStart;
            _roadrepair.RepairEndFact = _roadrepair.RepairEnd;
            ///TODO:раскомментить
            //_roadrepair.RepairStartFact = checkRepairStartFact.Checked ? (DateTime?) dtPickerStartFact.Value : null;
            //_roadrepair.RepairEndFact = checkRepairEndFact.Checked ? (DateTime?) dtPickerEndFact.Value : null;

            //_roadrepair.RepairType = RepairTypeHelper.GetByName(cB_RepairType.SelectedItem.ToString());
            //_roadrepair.WorkType = WorkTypeHelper.GetByName(cB_WorkType.SelectedItem.ToString());
            /*_roadrepair.WorkSort = cB_WorkSort.SelectedItem == null ? "" : cB_WorkSort.SelectedItem.ToString();          */

            if (selectFlag == 1)
            {
                _roadrepair.RepairType = RepairTypeHelper.GetByName(treeWorkSorts.SelectedNode.Parent.Text);
                _roadrepair.WorkType = WorkTypeHelper.GetByName(treeWorkSorts.SelectedNode.Text);
            }
            else if (selectFlag == 2)
            {
                _roadrepair.RepairType = RepairTypeHelper.GetByName(treeWorkSorts.SelectedNode.Parent.Parent.Text);
                _roadrepair.WorkType = WorkTypeHelper.GetByName(treeWorkSorts.SelectedNode.Parent.Text);
                _roadrepair.WorkSort = treeWorkSorts.SelectedNode.Text;
            }
            //_roadrepair.Status = StatusTypeHelper.GetByName(cB_RepairStatusType.SelectedItem.ToString());
            _roadrepair.Status = GetStatus();

            return _roadrepair;
        }

        /// <summary>
        /// Проверка выбора в элементе состава работ
        /// </summary>
        /// <returns>
        /// 0 - ничего не выбрано
        /// 1 - выбран класс и вид работ
        /// 2 - выбраны все поля
        /// </returns>
        private short CheckWorkSortTree()
        {
            if (treeWorkSorts.SelectedNode?.Parent != null)
            {
                if (treeWorkSorts.SelectedNode.Parent.Parent != null)
                {
                    return 2;
                }
                return 1;
            }
            return 0;
        }

        private RoadRepairStatus GetStatus()
        {
            if (rB_InProgress.Checked) return RoadRepairStatus.InProgress;
            if (rB_WillBeMade.Checked) return RoadRepairStatus.WillBeMade;
            if (rB_Made.Checked) return RoadRepairStatus.Made;
            return RoadRepairStatus.Stopped;
        }

        private void FillControlsWithData()
        {
            #region dates
            if (_roadrepair.RepairStart.HasValue)
            {
                checkRepairStart.Checked = true;
                dtPickerStart.Value = _roadrepair.RepairStart.Value;
            }
            else
            {
                checkRepairStart.Checked = false;
                dtPickerStart.Value = DateTime.Now;
                dtPickerStart.Enabled = false;
            }
            if (_roadrepair.RepairEnd.HasValue)
            {
                checkRepairEnd.Checked = true;
                dtPickerEnd.Value = _roadrepair.RepairEnd.Value;
            }
            else
            {
                checkRepairEnd.Checked = false;
                dtPickerEnd.Value = DateTime.Now;
                dtPickerEnd.Enabled = false;
            }
            if (_roadrepair.RepairStartFact.HasValue)
            {
                checkRepairStartFact.Checked = true;
                dtPickerStartFact.Value = _roadrepair.RepairStartFact.Value;
            }
            else
            {
                checkRepairStartFact.Checked = false;
                dtPickerStartFact.Value = DateTime.Now;
                dtPickerStartFact.Enabled = false;
            }
            if (_roadrepair.RepairEndFact.HasValue)
            {
                checkRepairEndFact.Checked = true;
                dtPickerEndFact.Value = _roadrepair.RepairEndFact.Value;
            }
            else
            {
                checkRepairEndFact.Checked = false;
                dtPickerEndFact.Value = DateTime.Now;
                dtPickerEndFact.Enabled = false;
            }


            #endregion

            //dtPickerStart.Value = _roadrepair.RepairStart ?? DateTime.Now;
            //dtPickerEnd.Value = _roadrepair.RepairEnd ?? DateTime.Now;
            //dtPickerStartFact.Value = _roadrepair.RepairStartFact ?? DateTime.Now;
            //dtPickerEndFact.Value = _roadrepair.RepairEndFact ?? DateTime.Now;

            //cB_RepairType.Text = RepairTypeHelper.GetName(_roadrepair.RepairType);
            //cB_WorkType.Text = WorkTypeHelper.GetName(_roadrepair.WorkType);
            //cB_WorkSort.DataSource = GetDescripts((int)_roadrepair.RepairType, (int)_roadrepair.WorkType);
            //cB_WorkSort.Text = _roadrepair.WorkSort;
            //cB_RepairStatusType.Text = StatusTypeHelper.GetName(_roadrepair.Status);

            switch (_roadrepair.Status)
            {
                case RoadRepairStatus.InProgress:
                    {
                        rB_InProgress.Checked = true;
                        break;
                    }
                case RoadRepairStatus.WillBeMade:
                    {
                        rB_WillBeMade.Checked = true;
                        break;
                    }
                case RoadRepairStatus.Made:
                    {
                        rB_Made.Checked = true;
                        break;
                    }
                case RoadRepairStatus.Stopped:
                    {
                        rB_Stopped.Checked = true;
                        break;
                    }
            }

            textBoxNote.Text = _roadrepair.Note;

            //if (!string.IsNullOrWhiteSpace(_roadrepair.WorkSort))
            //{
            //    treeWorkSorts.SelectedNode = treeWorkSorts.Nodes[_roadrepair.RepairType.ToString()]
            //        .Nodes[_roadrepair.WorkType.ToString()].Nodes[_roadrepair.WorkSort];
            //}
            //else
            //{
            //    treeWorkSorts.SelectedNode = treeWorkSorts.Nodes[_roadrepair.RepairType.ToString()]
            //        .Nodes[_roadrepair.WorkType.ToString()];
            //}

            #region orgs
            tbOwner.Text = _roadrepair.Owner != null
                ? _roadrepair.Owner.ToString()
                : STRING_OrgNotSet;
            if (_roadrepair.Owner != null)
            {
                linkClearOwner.Visible = true;
            }

            tbPerformer.Text = _roadrepair.Performer != null
                ? _roadrepair.Performer.ToString()
                : STRING_OrgNotSet;
            if (_roadrepair.Performer != null)
            {
                linkClearPerformer.Visible = true;
            }
            tbCustomer.Text = _roadrepair.Customer != null
                ? _roadrepair.Customer.ToString()
                : STRING_OrgNotSet;
            if (_roadrepair.Customer != null)
            {
                linkClearCustomer.Visible = true;
            }
            #endregion
        }
#endregion

        #region Binding

        //public List<string> ComboBoxWorkSortCurrent
        //{
        //    get
        //    {
        //        var retList = new List<string> { (string)WorkSortStringsBindingSource.Current };
        //        return retList;
        //    }
        //    set
        //    {
        //        WorkSortStringsBindingSource.DataSource = value;
        //        if (value.Count != 0)
        //        {
        //            WorkSortStringsBindingSource.Position =
        //                WorkSortStringsBindingSource.IndexOf(value.ElementAt(0));
        //        }
        //    }
        //}

        //public List<string> ComboBoxWorkSortCurrent
        //{
        //    set
        //    {
        //        cB_WorkSort.DataSource = value;
        //        if (value.Count != 0)
        //        {
        //            cB_WorkSort.SelectedItem =
        //                cB_WorkSort.Items.IndexOf(value.ElementAt(0));
        //        }
        //    }
        //}

        #endregion

        #region Events

        public event Action<long?, RoadRepair> AddRoadRepair;
        public event Action<long?, RoadRepair> EditRoadRepair;
       
        #endregion

        #region Handlers

        private void checkRepairStart_CheckedChanged(object sender, EventArgs e)
        {
            dtPickerStart.Enabled = checkRepairStart.Checked;
        }

        private void checkRepairEnd_CheckedChanged(object sender, EventArgs e)
        {
            dtPickerEnd.Enabled = checkRepairEnd.Checked;
        }

        private void checkRepairStartFact_CheckedChanged(object sender, EventArgs e)
        {
            dtPickerStartFact.Enabled = checkRepairStartFact.Checked;
        }

        private void checkRepairEndFact_CheckedChanged(object sender, EventArgs e)
        {
            dtPickerEndFact.Enabled = checkRepairEndFact.Checked;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            short selectFlag = CheckWorkSortTree();
            if (!_isEdit)
            {
                if (selectFlag != 0)
                {
                    AddRoadRepair?.Invoke(_address != null ? _address.ID : (long?) null, GetRoadRepair(selectFlag));
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(@"Пожалуйста, выберите класс, вид и состав работ!");
                }
            }
            else
            {
                EditRoadRepair?.Invoke(_address != null ? _address.ID : (long?) null, GetRoadRepair(selectFlag));
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseView();
        }

        private void cB_RepairType_SelectedValueChanged(object sender, EventArgs e)
        {
            ////Dictionary<string, string> descr = new Dictionary<string, string>();
            ////if ((cB_RepairType.Items.Count != 0) && (cB_WorkType.Items.Count != 0))
            ////{
            ////    descr.Add((string)cB_RepairType.SelectedItem, (string)cB_WorkType.SelectedItem);
            ////    if (DescriptionChange != null) DescriptionChange(descr);
            ////}
            //if ((cB_RepairType.Items.Count != 0) && (cB_WorkType.Items.Count != 0) && WorkSorts!=null)
            //{
            //    int repairType = (int) RepairTypeHelper.GetByName(cB_RepairType.SelectedItem.ToString());
            //    int workType = (int) WorkTypeHelper.GetByName(cB_WorkType.SelectedItem.ToString());
            //    //DescriptionChange?.Invoke(repairType, workType);
            //    ComboBoxWorkSortCurrent = GetDescripts(repairType, workType);
            //}
        }

        private void RoadRepairEditView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(this, e);
            }
        }

        private void dtPickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtPickerEnd.Value < dtPickerStart.Value)
            {
                if ((sender as DateTimePicker)?.Name == "dtPickerStart")
                {
                    dtPickerStart.Focus();
                    dtPickerStart.Value = dtPickerEnd.Value;
                }
                dtPickerEnd.Focus();
                dtPickerEnd.Value = dtPickerStart.Value;
                MessageBox.Show(@"Дата окончания работ должна быть позже даты начала!");
            }
        }

        private void linkAddOwner_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (RoadRepairConstants.OrganizationView == null)
            {
                getOrganizationView();
            }
            if (RoadRepairConstants.OrganizationView != null && RoadRepairConstants.OrganizationView.ShowForm() == DialogResult.OK)
            {
                //RoadRepair.Owner = RoadRepairConstants.OrganizationView.SelectedOrganization;
                //tbOwner.Text = RoadRepair.Owner != null
                //    ? RoadRepair.Owner.ToString()
                //    : STRING_OrgNotSet;
                _roadrepair.Owner = RoadRepairConstants.OrganizationView.SelectedOrganization;
                tbOwner.Text = _roadrepair.Owner != null
                    ? _roadrepair.Owner.ToString()
                    : STRING_OrgNotSet;
                linkClearOwner.Visible = true;
            }
        }

        private void linkClearOwner_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show(@"Очистить организацию контракта?", @"Организация контракта", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _roadrepair.Owner = null;
                tbOwner.Text = STRING_OrgNotSet;
                linkClearOwner.Visible = false;
            }
        }

        private void linkAddCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (RoadRepairConstants.OrganizationView == null)
            {
                getOrganizationView();
            }
            if (RoadRepairConstants.OrganizationView != null && RoadRepairConstants.OrganizationView.ShowForm() == DialogResult.OK)
            {
                //RoadRepair.Customer = RoadRepairConstants.OrganizationView.SelectedOrganization;
                //tbCustomer.Text = RoadRepair.Customer != null
                //    ? RoadRepair.Customer.ToString()
                //    : STRING_OrgNotSet;
                _roadrepair.Customer = RoadRepairConstants.OrganizationView.SelectedOrganization;
                tbCustomer.Text = _roadrepair.Customer != null
                    ? _roadrepair.Customer.ToString()
                    : STRING_OrgNotSet;
                linkClearCustomer.Visible = true;
               
            }
        }

        private void linkClearCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show(@"Очистить организацию контракта?", @"Организация контракта", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _roadrepair.Customer = null;
                tbCustomer.Text = STRING_OrgNotSet;
                linkClearCustomer.Visible = false;
                
            }
        }

        private void linkAddPerformer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (RoadRepairConstants.OrganizationView == null)
            {
                getOrganizationView();
            }
            if (RoadRepairConstants.OrganizationView != null && RoadRepairConstants.OrganizationView.ShowForm() == DialogResult.OK)
            {
                //RoadRepair.Performer = RoadRepairConstants.OrganizationView.SelectedOrganization;
                //tbPerformer.Text = RoadRepair.Performer != null
                //    ? RoadRepair.Performer.ToString()
                //    : STRING_OrgNotSet;
                _roadrepair.Performer = RoadRepairConstants.OrganizationView.SelectedOrganization;
                tbPerformer.Text = _roadrepair.Performer != null
                    ? _roadrepair.Performer.ToString()
                    : STRING_OrgNotSet;
                linkClearPerformer.Visible = true;
            }
        }

        private void linkClearPerformer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show(@"Очистить организацию контракта?", @"Организация контракта", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _roadrepair.Performer = null;
                tbPerformer.Text = STRING_OrgNotSet;
                linkClearPerformer.Visible = false;
            }
        }

        #endregion
    }
}