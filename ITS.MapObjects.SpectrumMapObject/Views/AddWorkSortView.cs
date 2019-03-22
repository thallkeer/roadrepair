using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ITS.Core.Enums;
using ITS.Core.RoadRepairing.Domain;
using ITS.Core.RoadRepairing.Domain.Enums;
using ITS.Core.RoadRepairing.ManagerInterfaces;
using ITS.MapObjects.RoadRepairingMapObject.IViews;
using ITS.ProjectBase.Utils.AsyncWorking;

namespace ITS.MapObjects.RoadRepairingMapObject.Views
{
    public partial class AddWorkSortView : Form
    {
        private readonly IWorkSortManager _workSortManager;
        public List<WorkSort> AddedWorkSorts = new List<WorkSort>();

        public AddWorkSortView(IWorkSortManager workSortManager)
        {
            InitializeComponent();
            cB_RepairType.DataSource = Enum.GetValues(typeof(RepairType)).Cast<RepairType>()
                .Select(t => t.GetDescription()).ToList();
            cB_WorkType.DataSource = Enum.GetValues(typeof(WorkType)).Cast<WorkType>().Select(t => t.GetDescription())
                .ToList();
            _workSortManager = workSortManager;

            // Set up the delays for the ToolTip.
            toolTipWorkType.AutoPopDelay = 5000;
            toolTipWorkType.InitialDelay = 1000;
            toolTipWorkType.ReshowDelay = 500;
            // the ToolTip text to be displayed whether or not the form is active.
            toolTipWorkType.ShowAlways = true;

        }

        private void SetToolTipDescription()
        {
            string type_one = cB_WorkType.SelectedItem.ToString();
            toolTipWorkType.SetToolTip(cB_WorkType, type_one);

        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbWorkSort.Text))
            {
                WorkSort newWorkSort = new WorkSort
                {
                    Description = tbWorkSort.Text,
                    RepairType = RepairTypeHelper.GetByName(cB_RepairType.SelectedItem.ToString()),
                    WorkType = WorkTypeHelper.GetByName(cB_WorkType.SelectedItem.ToString())
                };
                AddedWorkSorts.Add(_workSortManager.AddNew(newWorkSort));
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Заполните текстовое поле!");
            }
        }

        private void cB_WorkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetToolTipDescription();
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            var rtValues = RepairTypeHelper.GetNames().Values;
            var wtValues = WorkTypeHelper.GetNames().Values;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    AsyncLoaderForm.ShowMarquee((s, ee) =>
                    {
                        RepairType rt = RepairType.Overhaul;
                        WorkType wt = WorkType.CanvasDrainage;
                        var filename = openFileDialog.FileName;
                        if (filename != null)
                        {
                            StreamReader file = new StreamReader(filename, Encoding.GetEncoding(1251));
                            string line;
                            while ((line = file.ReadLine()) != null)
                            {
                                if (line == "") continue;
                                char[] charsToTrim = {';', '.', ':'};
                                line = line.Trim(charsToTrim);
                                line = line.Substring(0, 1).ToUpper() + line.Remove(0, 1);
                                if (rtValues.Contains(line))
                                {
                                    rt = RepairTypeHelper.GetByName(line);
                                }
                                else if (wtValues.Contains(line))
                                {
                                    wt = WorkTypeHelper.GetByName(line);
                                }
                                else
                                {
                                    WorkSort newWorkSort = new WorkSort
                                    {
                                        Description = line,
                                        RepairType = rt,
                                        WorkType = wt
                                    };
                                    AddedWorkSorts.Add(_workSortManager.AddNew(newWorkSort));
                                }
                            }
                            file.Close();
                        }
                    }, "Добавление категорий в базу данных");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $@"Ошибка добавления категорий{Environment.NewLine}{ex.Message}",
                        @"Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}

