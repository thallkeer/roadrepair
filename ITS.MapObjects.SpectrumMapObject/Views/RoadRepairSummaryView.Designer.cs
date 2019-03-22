using ITS.Core.RoadRepairing.Domain;

namespace ITS.MapObjects.RoadRepairingMapObject.Views
{
    partial class RoadRepairSummaryView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoadRepairSummaryView));
            this.tabControlFilter = new System.Windows.Forms.TabControl();
            this.tabPageRoadRepair = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBoxRoadRepairFilter = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.filterValueControlRoadrepair = new ITS.MapObjects.BaseMapObject.FilterControls.FilterValueControl();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnAddRoadRepairFilter = new System.Windows.Forms.Button();
            this.flowPanelAddedRoadRepairFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.dgRoadrepairs = new System.Windows.Forms.DataGridView();
            this.RRbindingsource = new System.Windows.Forms.BindingSource(this.components);
            this.ShowOnMapColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.EditRoadRepairColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabControlFilter.SuspendLayout();
            this.tabPageRoadRepair.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBoxRoadRepairFilter.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRoadrepairs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RRbindingsource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlFilter
            // 
            this.tabControlFilter.Controls.Add(this.tabPageRoadRepair);
            this.tabControlFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControlFilter.Location = new System.Drawing.Point(639, 0);
            this.tabControlFilter.Name = "tabControlFilter";
            this.tabControlFilter.SelectedIndex = 0;
            this.tabControlFilter.Size = new System.Drawing.Size(282, 561);
            this.tabControlFilter.TabIndex = 7;
            // 
            // tabPageRoadRepair
            // 
            this.tabPageRoadRepair.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageRoadRepair.Controls.Add(this.panel2);
            this.tabPageRoadRepair.Controls.Add(this.panel3);
            this.tabPageRoadRepair.Location = new System.Drawing.Point(4, 22);
            this.tabPageRoadRepair.Name = "tabPageRoadRepair";
            this.tabPageRoadRepair.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRoadRepair.Size = new System.Drawing.Size(274, 535);
            this.tabPageRoadRepair.TabIndex = 0;
            this.tabPageRoadRepair.Text = "Дорожные работы";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnApplyFilter);
            this.panel2.Controls.Add(this.btnClearFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 493);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 39);
            this.panel2.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSize = true;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(186, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ExportWord_ClickHandler);
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnApplyFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnApplyFilter.Location = new System.Drawing.Point(34, 8);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(70, 23);
            this.btnApplyFilter.TabIndex = 9;
            this.btnApplyFilter.Text = "Загрузить";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.ApplyFilter_ClickHandler);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClearFilter.Location = new System.Drawing.Point(110, 8);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(70, 23);
            this.btnClearFilter.TabIndex = 8;
            this.btnClearFilter.Text = "Сбросить";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.DropFilter_ClickHandler);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.groupBoxRoadRepairFilter);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(268, 485);
            this.panel3.TabIndex = 1;
            // 
            // groupBoxRoadRepairFilter
            // 
            this.groupBoxRoadRepairFilter.AutoSize = true;
            this.groupBoxRoadRepairFilter.Controls.Add(this.flowLayoutPanel2);
            this.groupBoxRoadRepairFilter.Location = new System.Drawing.Point(3, 0);
            this.groupBoxRoadRepairFilter.Name = "groupBoxRoadRepairFilter";
            this.groupBoxRoadRepairFilter.Size = new System.Drawing.Size(261, 106);
            this.groupBoxRoadRepairFilter.TabIndex = 5;
            this.groupBoxRoadRepairFilter.TabStop = false;
            this.groupBoxRoadRepairFilter.Text = "Параметры фильтра";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.filterValueControlRoadrepair);
            this.flowLayoutPanel2.Controls.Add(this.panel6);
            this.flowLayoutPanel2.Controls.Add(this.flowPanelAddedRoadRepairFilters);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(255, 87);
            this.flowLayoutPanel2.TabIndex = 156;
            // 
            // filterValueControlRoadrepair
            // 
            this.filterValueControlRoadrepair.AutoSize = true;
            this.filterValueControlRoadrepair.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterValueControlRoadrepair.Location = new System.Drawing.Point(3, 3);
            this.filterValueControlRoadrepair.MinimumSize = new System.Drawing.Size(247, 44);
            this.filterValueControlRoadrepair.Name = "filterValueControlRoadrepair";
            this.filterValueControlRoadrepair.Size = new System.Drawing.Size(247, 44);
            this.filterValueControlRoadrepair.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnAddRoadRepairFilter);
            this.panel6.Location = new System.Drawing.Point(3, 53);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(164, 31);
            this.panel6.TabIndex = 152;
            // 
            // btnAddRoadRepairFilter
            // 
            this.btnAddRoadRepairFilter.Location = new System.Drawing.Point(3, 3);
            this.btnAddRoadRepairFilter.Name = "btnAddRoadRepairFilter";
            this.btnAddRoadRepairFilter.Size = new System.Drawing.Size(75, 23);
            this.btnAddRoadRepairFilter.TabIndex = 150;
            this.btnAddRoadRepairFilter.Text = "Добавить";
            this.btnAddRoadRepairFilter.UseVisualStyleBackColor = true;
            this.btnAddRoadRepairFilter.Click += new System.EventHandler(this.btnAddRoadRepairFilter_Click);
            // 
            // flowPanelAddedRoadRepairFilters
            // 
            this.flowPanelAddedRoadRepairFilters.AutoSize = true;
            this.flowPanelAddedRoadRepairFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelAddedRoadRepairFilters.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelAddedRoadRepairFilters.Location = new System.Drawing.Point(0, 87);
            this.flowPanelAddedRoadRepairFilters.Margin = new System.Windows.Forms.Padding(0);
            this.flowPanelAddedRoadRepairFilters.Name = "flowPanelAddedRoadRepairFilters";
            this.flowPanelAddedRoadRepairFilters.Size = new System.Drawing.Size(253, 0);
            this.flowPanelAddedRoadRepairFilters.TabIndex = 154;
            // 
            // dgRoadrepairs
            // 
            this.dgRoadrepairs.AllowUserToAddRows = false;
            this.dgRoadrepairs.AllowUserToDeleteRows = false;
            this.dgRoadrepairs.AllowUserToOrderColumns = true;
            this.dgRoadrepairs.AllowUserToResizeColumns = false;
            this.dgRoadrepairs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgRoadrepairs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRoadrepairs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShowOnMapColumn,
            this.EditRoadRepairColumn});
            this.dgRoadrepairs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRoadrepairs.Location = new System.Drawing.Point(0, 0);
            this.dgRoadrepairs.Name = "dgRoadrepairs";
            this.dgRoadrepairs.ReadOnly = true;
            this.dgRoadrepairs.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgRoadrepairs.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgRoadrepairs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRoadrepairs.Size = new System.Drawing.Size(639, 561);
            this.dgRoadrepairs.TabIndex = 8;
            this.dgRoadrepairs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoadrepairsGrid_CellContentClickHandler);
            this.dgRoadrepairs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.RoadRepairGridCellFormatting);
            // 
            // RRbindingsource
            // 
            this.RRbindingsource.DataSource = typeof(ITS.Core.RoadRepairing.Domain.RoadRepairDTO);
            // 
            // ShowOnMapColumn
            // 
            this.ShowOnMapColumn.FillWeight = 1F;
            this.ShowOnMapColumn.HeaderText = "";
            this.ShowOnMapColumn.Image = ((System.Drawing.Image)(resources.GetObject("ShowOnMapColumn.Image")));
            this.ShowOnMapColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ShowOnMapColumn.MinimumWidth = 20;
            this.ShowOnMapColumn.Name = "ShowOnMapColumn";
            this.ShowOnMapColumn.ReadOnly = true;
            this.ShowOnMapColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ShowOnMapColumn.ToolTipText = "Показать объект на карте";
            this.ShowOnMapColumn.Width = 236;
            // 
            // EditRoadRepairColumn
            // 
            this.EditRoadRepairColumn.FillWeight = 1F;
            this.EditRoadRepairColumn.HeaderText = "";
            this.EditRoadRepairColumn.Image = ((System.Drawing.Image)(resources.GetObject("EditRoadRepairColumn.Image")));
            this.EditRoadRepairColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.EditRoadRepairColumn.MinimumWidth = 20;
            this.EditRoadRepairColumn.Name = "EditRoadRepairColumn";
            this.EditRoadRepairColumn.ReadOnly = true;
            this.EditRoadRepairColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EditRoadRepairColumn.ToolTipText = "Редактировать семантику";
            this.EditRoadRepairColumn.Width = 235;
            // 
            // RoadRepairSummaryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 561);
            this.Controls.Add(this.dgRoadrepairs);
            this.Controls.Add(this.tabControlFilter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(772, 600);
            this.Name = "RoadRepairSummaryView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сводная ведомость";
            this.tabControlFilter.ResumeLayout(false);
            this.tabPageRoadRepair.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBoxRoadRepairFilter.ResumeLayout(false);
            this.groupBoxRoadRepairFilter.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRoadrepairs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RRbindingsource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlFilter;
        private System.Windows.Forms.TabPage tabPageRoadRepair;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBoxRoadRepairFilter;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private BaseMapObject.FilterControls.FilterValueControl filterValueControlRoadrepair;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnAddRoadRepairFilter;
        private System.Windows.Forms.FlowLayoutPanel flowPanelAddedRoadRepairFilters;
        private System.Windows.Forms.DataGridView dgRoadrepairs;
        private System.Windows.Forms.BindingSource RRbindingsource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.DataGridViewImageColumn ShowOnMapColumn;
        private System.Windows.Forms.DataGridViewImageColumn EditRoadRepairColumn;
    }
}