using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ITS.Core.RoadRepairing.Domain;
using ITS.Core.RoadRepairing.Domain.Enums;
using ITS.Core.RoadRepairing.ManagerInterfaces;
using ITS.MapObjects.RoadRepairingMapObject.IViews;

namespace ITS.MapObjects.RoadRepairingMapObject.Views
{
    public partial class WorkSortCatalogView : Form, IWorkSortCatalogView
    {
        private const string IdColumn = "IDColumn";
        private const string RepairTypeColumn = "repairTypeDataGridViewTextBoxColumn";
        private const string WorkTypeColumn = "workTypeDataGridViewTextBoxColumn";
        private const string WorkSortColumn = "descriptionDataGridViewTextBoxColumn";
        private List<WorkSort> _workSorts;

        private string _beforeEdit;

        //private DataTable dt = new DataTable("WorkSorts");
        private List<WorkSort> WorkSorts
        {
            get
            {
                if (_workSorts == null)
                {
                    if (_workSortManager == null)
                        return null;
                    _workSorts = _workSortManager.GetAll().ToList();
                }

                _workSorts = _workSorts.OrderBy(x => x.RepairType).ThenBy(x => x.WorkType).ToList();
                return _workSorts;
            }
        }

        private IWorkSortManager _workSortManager;


        public WorkSortCatalogView(IWorkSortManager workSortManager)
        {
            InitializeComponent();
            _workSortManager = workSortManager;
            //FillDataTable();
            bindingSourceWorkSort.DataSource = WorkSorts;
            bindingSourceWorkSort.ResetBindings(false);



            dGVCatalog.DataSource = bindingSourceWorkSort;
            dGVCatalog.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dGVCatalog.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dGVCatalog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dGVCatalog.ReadOnly = false;
            dGVCatalog.Columns[0].ReadOnly = true;
            dGVCatalog.Columns[1].ReadOnly = true;


            //dGVCatalog.Columns[0].HeaderText = "Тип ремонта";
            //dGVCatalog.Columns[1].HeaderText = "Вид работ";
            //dGVCatalog.Columns[2].HeaderText = "Описание работ";
            //dGVCatalog.Columns[3].Visible = false;
        }

        public void ShowView()
        {
            ShowDialog();
        }

        public void CloseView()
        {
            base.Close();
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var addWorkSortView = new AddWorkSortView(_workSortManager);
            if (addWorkSortView.ShowDialog() == DialogResult.OK)
            {
                var addedWs = addWorkSortView.AddedWorkSorts;
                if (addedWs != null)
                {
                    foreach (var ws in addedWs)
                    {
                        _workSorts.Add(ws);
                    }

                    bindingSourceWorkSort.DataSource = WorkSorts;
                    bindingSourceWorkSort.ResetBindings(false);
                }

            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (bindingSourceWorkSort.Current != null)
            {
                if (MessageBox.Show(@"Вы действительно хотите удалить данный вид работ?", @"Удаление",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var wsToDelete = bindingSourceWorkSort.Current as WorkSort;
                    if (_workSortManager.Delete(wsToDelete))
                    {
                        if (_workSorts != null)
                        {
                            _workSorts.Remove(wsToDelete);
                            bindingSourceWorkSort.ResetBindings(false);
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Не удалось удалить выбранный вид работ из базы данных.", @"Ошибка удаления",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void dGVCatalog_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (dGVCatalog.Columns[e.ColumnIndex].Name)
            {
                case RepairTypeColumn:
                {
                    var rt = (WorkSort) dGVCatalog.Rows[e.RowIndex].DataBoundItem;
                    e.Value = RepairTypeHelper.GetName(rt.RepairType);
                    e.FormattingApplied = true;
                    break;
                }
                case WorkTypeColumn:
                {
                    var wt = (WorkSort) dGVCatalog.Rows[e.RowIndex].DataBoundItem;
                    e.Value = WorkTypeHelper.GetName(wt.WorkType);
                    e.FormattingApplied = true;
                    break;
                }
            }
        }

        private void dGVCatalog_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var ws = (WorkSort) dGVCatalog.Rows[e.RowIndex].DataBoundItem;
            _beforeEdit = ws.Description;
        }

        private void dGVCatalog_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var workSortToEdit = (WorkSort) dGVCatalog.Rows[e.RowIndex].DataBoundItem;
            //var editedText = (String)dGVCatalog[WorkSortColumn,e.RowIndex].Value;
            if (!string.IsNullOrWhiteSpace(workSortToEdit.Description) && workSortToEdit.Description != _beforeEdit)
            {
                _workSortManager.Edit(workSortToEdit);
            }
            else if (string.IsNullOrWhiteSpace(workSortToEdit.Description))
            {
                dGVCatalog[WorkSortColumn, e.RowIndex].Value = _beforeEdit;
            }
        }
    }
}
