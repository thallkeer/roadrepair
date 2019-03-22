using System.Windows.Forms;

namespace ITS.MapObjects.RoadRepairingMapObject.Views
{
    partial class RoadRepairEditView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoadRepairEditView));
            this.RepairTypeStringsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StatusStringsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.WorkTypeStringsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTipDescribe = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.rB_Stopped = new System.Windows.Forms.RadioButton();
            this.rB_WillBeMade = new System.Windows.Forms.RadioButton();
            this.rB_Made = new System.Windows.Forms.RadioButton();
            this.rB_InProgress = new System.Windows.Forms.RadioButton();
            this.treeWorkSorts = new System.Windows.Forms.TreeView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbPerformer = new System.Windows.Forms.TextBox();
            this.tbCustomer = new System.Windows.Forms.TextBox();
            this.tbOwner = new System.Windows.Forms.TextBox();
            this.linkAddPerformer = new System.Windows.Forms.LinkLabel();
            this.linkAddCustomer = new System.Windows.Forms.LinkLabel();
            this.linkAddOwner = new System.Windows.Forms.LinkLabel();
            this.linkClearPerformer = new System.Windows.Forms.LinkLabel();
            this.linkClearCustomer = new System.Windows.Forms.LinkLabel();
            this.linkClearOwner = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkRepairEndFact = new System.Windows.Forms.CheckBox();
            this.checkRepairStartFact = new System.Windows.Forms.CheckBox();
            this.dtPickerEndFact = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtPickerStartFact = new System.Windows.Forms.DateTimePicker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkRepairEnd = new System.Windows.Forms.CheckBox();
            this.checkRepairStart = new System.Windows.Forms.CheckBox();
            this.dtPickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtPickerStart = new System.Windows.Forms.DateTimePicker();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RepairTypeStringsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusStringsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkTypeStringsBindingSource)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // RepairTypeStringsBindingSource
            // 
            this.RepairTypeStringsBindingSource.DataSource = typeof(ITS.Core.RoadRepairing.Domain.Enums.RepairTypeHelper);
            // 
            // StatusStringsBindingSource
            // 
            this.StatusStringsBindingSource.DataSource = typeof(ITS.Core.RoadRepairing.Domain.Enums.StatusTypeHelper);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // WorkTypeStringsBindingSource
            // 
            this.WorkTypeStringsBindingSource.DataSource = typeof(ITS.Core.RoadRepairing.Domain.Enums.WorkTypeHelper);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(862, 370);
            this.tabControl.TabIndex = 68;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxStatus);
            this.tabPage1.Controls.Add(this.treeWorkSorts);
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.btnOK);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.textBoxNote);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(854, 344);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Основная информация";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.rB_Stopped);
            this.groupBoxStatus.Controls.Add(this.rB_WillBeMade);
            this.groupBoxStatus.Controls.Add(this.rB_Made);
            this.groupBoxStatus.Controls.Add(this.rB_InProgress);
            this.groupBoxStatus.Location = new System.Drawing.Point(6, 158);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(130, 116);
            this.groupBoxStatus.TabIndex = 84;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "Статус работ";
            // 
            // rB_Stopped
            // 
            this.rB_Stopped.AutoSize = true;
            this.rB_Stopped.Location = new System.Drawing.Point(7, 87);
            this.rB_Stopped.Name = "rB_Stopped";
            this.rB_Stopped.Size = new System.Drawing.Size(112, 17);
            this.rB_Stopped.TabIndex = 0;
            this.rB_Stopped.Text = "Приостановлены";
            this.rB_Stopped.UseVisualStyleBackColor = true;
            // 
            // rB_WillBeMade
            // 
            this.rB_WillBeMade.AutoSize = true;
            this.rB_WillBeMade.Location = new System.Drawing.Point(7, 66);
            this.rB_WillBeMade.Name = "rB_WillBeMade";
            this.rB_WillBeMade.Size = new System.Drawing.Size(106, 17);
            this.rB_WillBeMade.TabIndex = 0;
            this.rB_WillBeMade.Text = "Запланированы";
            this.rB_WillBeMade.UseVisualStyleBackColor = true;
            // 
            // rB_Made
            // 
            this.rB_Made.AutoSize = true;
            this.rB_Made.Location = new System.Drawing.Point(7, 43);
            this.rB_Made.Name = "rB_Made";
            this.rB_Made.Size = new System.Drawing.Size(84, 17);
            this.rB_Made.TabIndex = 0;
            this.rB_Made.Text = "Выполнены";
            this.rB_Made.UseVisualStyleBackColor = true;
            // 
            // rB_InProgress
            // 
            this.rB_InProgress.AutoSize = true;
            this.rB_InProgress.Checked = true;
            this.rB_InProgress.Location = new System.Drawing.Point(7, 20);
            this.rB_InProgress.Name = "rB_InProgress";
            this.rB_InProgress.Size = new System.Drawing.Size(95, 17);
            this.rB_InProgress.TabIndex = 0;
            this.rB_InProgress.TabStop = true;
            this.rB_InProgress.Text = "Выполняются";
            this.rB_InProgress.UseVisualStyleBackColor = true;
            // 
            // treeWorkSorts
            // 
            this.treeWorkSorts.HideSelection = false;
            this.treeWorkSorts.ItemHeight = 20;
            this.treeWorkSorts.Location = new System.Drawing.Point(547, 21);
            this.treeWorkSorts.Name = "treeWorkSorts";
            this.treeWorkSorts.ShowNodeToolTips = true;
            this.treeWorkSorts.Size = new System.Drawing.Size(300, 288);
            this.treeWorkSorts.TabIndex = 83;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(772, 315);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 81;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(691, 315);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 82;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbPerformer);
            this.groupBox2.Controls.Add(this.tbCustomer);
            this.groupBox2.Controls.Add(this.tbOwner);
            this.groupBox2.Controls.Add(this.linkAddPerformer);
            this.groupBox2.Controls.Add(this.linkAddCustomer);
            this.groupBox2.Controls.Add(this.linkAddOwner);
            this.groupBox2.Controls.Add(this.linkClearPerformer);
            this.groupBox2.Controls.Add(this.linkClearCustomer);
            this.groupBox2.Controls.Add(this.linkClearOwner);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(142, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 157);
            this.groupBox2.TabIndex = 78;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Организации";
            // 
            // tbPerformer
            // 
            this.tbPerformer.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbPerformer.Location = new System.Drawing.Point(9, 131);
            this.tbPerformer.Name = "tbPerformer";
            this.tbPerformer.ReadOnly = true;
            this.tbPerformer.Size = new System.Drawing.Size(384, 20);
            this.tbPerformer.TabIndex = 69;
            this.tbPerformer.Text = "<Не задан>";
            // 
            // tbCustomer
            // 
            this.tbCustomer.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbCustomer.Location = new System.Drawing.Point(9, 82);
            this.tbCustomer.Name = "tbCustomer";
            this.tbCustomer.ReadOnly = true;
            this.tbCustomer.Size = new System.Drawing.Size(384, 20);
            this.tbCustomer.TabIndex = 69;
            this.tbCustomer.Text = "<Не задан>";
            // 
            // tbOwner
            // 
            this.tbOwner.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbOwner.Location = new System.Drawing.Point(9, 35);
            this.tbOwner.Name = "tbOwner";
            this.tbOwner.ReadOnly = true;
            this.tbOwner.Size = new System.Drawing.Size(384, 20);
            this.tbOwner.TabIndex = 69;
            this.tbOwner.Text = "<Не задан>";
            // 
            // linkAddPerformer
            // 
            this.linkAddPerformer.AutoSize = true;
            this.linkAddPerformer.Location = new System.Drawing.Point(118, 115);
            this.linkAddPerformer.Name = "linkAddPerformer";
            this.linkAddPerformer.Size = new System.Drawing.Size(57, 13);
            this.linkAddPerformer.TabIndex = 68;
            this.linkAddPerformer.TabStop = true;
            this.linkAddPerformer.Text = "Добавить";
            this.linkAddPerformer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAddPerformer_LinkClicked);
            // 
            // linkAddCustomer
            // 
            this.linkAddCustomer.AutoSize = true;
            this.linkAddCustomer.Location = new System.Drawing.Point(118, 66);
            this.linkAddCustomer.Name = "linkAddCustomer";
            this.linkAddCustomer.Size = new System.Drawing.Size(57, 13);
            this.linkAddCustomer.TabIndex = 68;
            this.linkAddCustomer.TabStop = true;
            this.linkAddCustomer.Text = "Добавить";
            this.linkAddCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAddCustomer_LinkClicked);
            // 
            // linkAddOwner
            // 
            this.linkAddOwner.AutoSize = true;
            this.linkAddOwner.Location = new System.Drawing.Point(118, 19);
            this.linkAddOwner.Name = "linkAddOwner";
            this.linkAddOwner.Size = new System.Drawing.Size(57, 13);
            this.linkAddOwner.TabIndex = 68;
            this.linkAddOwner.TabStop = true;
            this.linkAddOwner.Text = "Добавить";
            this.linkAddOwner.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAddOwner_LinkClicked);
            // 
            // linkClearPerformer
            // 
            this.linkClearPerformer.AutoSize = true;
            this.linkClearPerformer.Location = new System.Drawing.Point(339, 115);
            this.linkClearPerformer.Name = "linkClearPerformer";
            this.linkClearPerformer.Size = new System.Drawing.Size(54, 13);
            this.linkClearPerformer.TabIndex = 68;
            this.linkClearPerformer.TabStop = true;
            this.linkClearPerformer.Text = "Очистить";
            this.linkClearPerformer.Visible = false;
            this.linkClearPerformer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClearPerformer_LinkClicked);
            // 
            // linkClearCustomer
            // 
            this.linkClearCustomer.AutoSize = true;
            this.linkClearCustomer.Location = new System.Drawing.Point(339, 66);
            this.linkClearCustomer.Name = "linkClearCustomer";
            this.linkClearCustomer.Size = new System.Drawing.Size(54, 13);
            this.linkClearCustomer.TabIndex = 68;
            this.linkClearCustomer.TabStop = true;
            this.linkClearCustomer.Text = "Очистить";
            this.linkClearCustomer.Visible = false;
            this.linkClearCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClearCustomer_LinkClicked);
            // 
            // linkClearOwner
            // 
            this.linkClearOwner.AutoSize = true;
            this.linkClearOwner.Location = new System.Drawing.Point(339, 19);
            this.linkClearOwner.Name = "linkClearOwner";
            this.linkClearOwner.Size = new System.Drawing.Size(54, 13);
            this.linkClearOwner.TabIndex = 68;
            this.linkClearOwner.TabStop = true;
            this.linkClearOwner.Text = "Очистить";
            this.linkClearOwner.Visible = false;
            this.linkClearOwner.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClearOwner_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 64;
            this.label3.Text = "Исполнитель работ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Заказчик работ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Владелец дороги";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkRepairEndFact);
            this.groupBox1.Controls.Add(this.checkRepairStartFact);
            this.groupBox1.Controls.Add(this.dtPickerEndFact);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtPickerStartFact);
            this.groupBox1.Location = new System.Drawing.Point(6, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 70);
            this.groupBox1.TabIndex = 79;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дата работ фактическая";
            // 
            // checkRepairEndFact
            // 
            this.checkRepairEndFact.AutoSize = true;
            this.checkRepairEndFact.Location = new System.Drawing.Point(109, 47);
            this.checkRepairEndFact.Name = "checkRepairEndFact";
            this.checkRepairEndFact.Size = new System.Drawing.Size(15, 14);
            this.checkRepairEndFact.TabIndex = 65;
            this.checkRepairEndFact.UseVisualStyleBackColor = true;
            this.checkRepairEndFact.CheckedChanged += new System.EventHandler(this.checkRepairEndFact_CheckedChanged);
            // 
            // checkRepairStartFact
            // 
            this.checkRepairStartFact.AutoSize = true;
            this.checkRepairStartFact.Location = new System.Drawing.Point(109, 19);
            this.checkRepairStartFact.Name = "checkRepairStartFact";
            this.checkRepairStartFact.Size = new System.Drawing.Size(15, 14);
            this.checkRepairStartFact.TabIndex = 65;
            this.checkRepairStartFact.UseVisualStyleBackColor = true;
            this.checkRepairStartFact.CheckedChanged += new System.EventHandler(this.checkRepairStartFact_CheckedChanged);
            // 
            // dtPickerEndFact
            // 
            this.dtPickerEndFact.Enabled = false;
            this.dtPickerEndFact.Location = new System.Drawing.Point(130, 41);
            this.dtPickerEndFact.MinDate = new System.DateTime(2008, 1, 1, 0, 0, 0, 0);
            this.dtPickerEndFact.Name = "dtPickerEndFact";
            this.dtPickerEndFact.Size = new System.Drawing.Size(158, 20);
            this.dtPickerEndFact.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "Конец работы";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Начало работы";
            // 
            // dtPickerStartFact
            // 
            this.dtPickerStartFact.Enabled = false;
            this.dtPickerStartFact.Location = new System.Drawing.Point(130, 15);
            this.dtPickerStartFact.MinDate = new System.DateTime(2008, 1, 1, 0, 0, 0, 0);
            this.dtPickerStartFact.Name = "dtPickerStartFact";
            this.dtPickerStartFact.Size = new System.Drawing.Size(158, 20);
            this.dtPickerStartFact.TabIndex = 7;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkRepairEnd);
            this.groupBox5.Controls.Add(this.checkRepairStart);
            this.groupBox5.Controls.Add(this.dtPickerEnd);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.dtPickerStart);
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(306, 70);
            this.groupBox5.TabIndex = 80;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Дата работ планируемая";
            // 
            // checkRepairEnd
            // 
            this.checkRepairEnd.AutoSize = true;
            this.checkRepairEnd.Location = new System.Drawing.Point(109, 47);
            this.checkRepairEnd.Name = "checkRepairEnd";
            this.checkRepairEnd.Size = new System.Drawing.Size(15, 14);
            this.checkRepairEnd.TabIndex = 65;
            this.checkRepairEnd.UseVisualStyleBackColor = true;
            this.checkRepairEnd.CheckedChanged += new System.EventHandler(this.checkRepairEnd_CheckedChanged);
            // 
            // checkRepairStart
            // 
            this.checkRepairStart.AutoSize = true;
            this.checkRepairStart.Location = new System.Drawing.Point(109, 19);
            this.checkRepairStart.Name = "checkRepairStart";
            this.checkRepairStart.Size = new System.Drawing.Size(15, 14);
            this.checkRepairStart.TabIndex = 65;
            this.checkRepairStart.UseVisualStyleBackColor = true;
            this.checkRepairStart.CheckedChanged += new System.EventHandler(this.checkRepairStart_CheckedChanged);
            // 
            // dtPickerEnd
            // 
            this.dtPickerEnd.Enabled = false;
            this.dtPickerEnd.Location = new System.Drawing.Point(130, 41);
            this.dtPickerEnd.MinDate = new System.DateTime(2008, 1, 1, 0, 0, 0, 0);
            this.dtPickerEnd.Name = "dtPickerEnd";
            this.dtPickerEnd.Size = new System.Drawing.Size(158, 20);
            this.dtPickerEnd.TabIndex = 9;
            this.dtPickerEnd.ValueChanged += new System.EventHandler(this.dtPickerEnd_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 64;
            this.label11.Text = "Конец работы";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Начало работы";
            // 
            // dtPickerStart
            // 
            this.dtPickerStart.Enabled = false;
            this.dtPickerStart.Location = new System.Drawing.Point(130, 15);
            this.dtPickerStart.MinDate = new System.DateTime(2008, 1, 1, 0, 0, 0, 0);
            this.dtPickerStart.Name = "dtPickerStart";
            this.dtPickerStart.Size = new System.Drawing.Size(158, 20);
            this.dtPickerStart.TabIndex = 7;
            this.dtPickerStart.ValueChanged += new System.EventHandler(this.dtPickerEnd_ValueChanged);
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(318, 21);
            this.textBoxNote.MaxLength = 511;
            this.textBoxNote.Multiline = true;
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(223, 131);
            this.textBoxNote.TabIndex = 72;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(315, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 13);
            this.label15.TabIndex = 73;
            this.label15.Text = "Примечания";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(854, 344);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Фотографии";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(544, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 13);
            this.label6.TabIndex = 73;
            this.label6.Text = "Класс, вид и состав работ";
            // 
            // RoadRepairEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 370);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoadRepairEditView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Дорожные работы";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RoadRepairEditView_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.RepairTypeStringsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusStringsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkTypeStringsBindingSource)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBoxStatus.ResumeLayout(false);
            this.groupBoxStatus.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.BindingSource RepairTypeStringsBindingSource;
        private System.Windows.Forms.BindingSource StatusStringsBindingSource;
        private System.Windows.Forms.BindingSource WorkTypeStringsBindingSource;
        private System.Windows.Forms.ToolTip toolTipDescribe;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel linkAddPerformer;
        private System.Windows.Forms.LinkLabel linkAddCustomer;
        private System.Windows.Forms.LinkLabel linkAddOwner;
        private System.Windows.Forms.LinkLabel linkClearPerformer;
        private System.Windows.Forms.LinkLabel linkClearCustomer;
        private System.Windows.Forms.LinkLabel linkClearOwner;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkRepairEndFact;
        private System.Windows.Forms.CheckBox checkRepairStartFact;
        private System.Windows.Forms.DateTimePicker dtPickerEndFact;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtPickerStartFact;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkRepairEnd;
        private System.Windows.Forms.CheckBox checkRepairStart;
        private System.Windows.Forms.DateTimePicker dtPickerEnd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtPickerStart;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabPage2;
        private TreeView treeWorkSorts;
        private GroupBox groupBoxStatus;
        private RadioButton rB_Stopped;
        private RadioButton rB_WillBeMade;
        private RadioButton rB_Made;
        private RadioButton rB_InProgress;
        private TextBox tbPerformer;
        private TextBox tbCustomer;
        private TextBox tbOwner;
        private Label label6;
    }
}