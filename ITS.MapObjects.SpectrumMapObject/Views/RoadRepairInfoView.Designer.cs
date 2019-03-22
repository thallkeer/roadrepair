namespace ITS.MapObjects.RoadRepairingMapObject.Views
{
    partial class RoadRepairInfoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoadRepairInfoView));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.labelStart = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelEndFact = new System.Windows.Forms.Label();
            this.labelStartFact = new System.Windows.Forms.Label();
            this.labelRepairType = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbPerformer = new System.Windows.Forms.TextBox();
            this.tbCustomer = new System.Windows.Forms.TextBox();
            this.tbOwner = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbWorkSort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelEnd);
            this.groupBox1.Controls.Add(this.labelStart);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.groupBox1.Location = new System.Drawing.Point(217, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 79);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Даты работ планируемые";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "Дата окончания";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Дата начала ";
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.BackColor = System.Drawing.SystemColors.Control;
            this.labelEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.labelEnd.Location = new System.Drawing.Point(139, 52);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(77, 16);
            this.labelEnd.TabIndex = 67;
            this.labelEnd.Text = "Не задана";
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.BackColor = System.Drawing.SystemColors.Control;
            this.labelStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.labelStart.Location = new System.Drawing.Point(139, 25);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(77, 16);
            this.labelStart.TabIndex = 67;
            this.labelStart.Text = "Не задана";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.labelEndFact);
            this.groupBox2.Controls.Add(this.labelStartFact);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.groupBox2.Location = new System.Drawing.Point(456, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 79);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Даты работ фактические";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(6, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "Дата окончания";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 30;
            this.label4.Text = "Дата начала ";
            // 
            // labelEndFact
            // 
            this.labelEndFact.AutoSize = true;
            this.labelEndFact.BackColor = System.Drawing.SystemColors.Control;
            this.labelEndFact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.labelEndFact.Location = new System.Drawing.Point(138, 52);
            this.labelEndFact.Name = "labelEndFact";
            this.labelEndFact.Size = new System.Drawing.Size(77, 16);
            this.labelEndFact.TabIndex = 67;
            this.labelEndFact.Text = "Не задана";
            this.labelEndFact.Click += new System.EventHandler(this.label15_Click);
            // 
            // labelStartFact
            // 
            this.labelStartFact.AutoSize = true;
            this.labelStartFact.BackColor = System.Drawing.SystemColors.Control;
            this.labelStartFact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.labelStartFact.Location = new System.Drawing.Point(138, 25);
            this.labelStartFact.Name = "labelStartFact";
            this.labelStartFact.Size = new System.Drawing.Size(77, 16);
            this.labelStartFact.TabIndex = 67;
            this.labelStartFact.Text = "Не задана";
            // 
            // labelRepairType
            // 
            this.labelRepairType.AutoSize = true;
            this.labelRepairType.BackColor = System.Drawing.SystemColors.Control;
            this.labelRepairType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.labelRepairType.Location = new System.Drawing.Point(114, 94);
            this.labelRepairType.Name = "labelRepairType";
            this.labelRepairType.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.labelRepairType.Size = new System.Drawing.Size(88, 19);
            this.labelRepairType.TabIndex = 30;
            this.labelRepairType.Text = "Класс работ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label7.Location = new System.Drawing.Point(11, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 16);
            this.label7.TabIndex = 30;
            this.label7.Text = "Работы";
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.tbPerformer);
            this.groupBox3.Controls.Add(this.tbCustomer);
            this.groupBox3.Controls.Add(this.tbOwner);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.groupBox3.Location = new System.Drawing.Point(329, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(360, 175);
            this.groupBox3.TabIndex = 79;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Организации";
            // 
            // tbPerformer
            // 
            this.tbPerformer.BackColor = System.Drawing.SystemColors.Control;
            this.tbPerformer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPerformer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tbPerformer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbPerformer.Location = new System.Drawing.Point(9, 134);
            this.tbPerformer.Name = "tbPerformer";
            this.tbPerformer.ReadOnly = true;
            this.tbPerformer.Size = new System.Drawing.Size(345, 15);
            this.tbPerformer.TabIndex = 68;
            this.tbPerformer.Text = "Не задан";
            // 
            // tbCustomer
            // 
            this.tbCustomer.BackColor = System.Drawing.SystemColors.Control;
            this.tbCustomer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tbCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbCustomer.Location = new System.Drawing.Point(9, 85);
            this.tbCustomer.Name = "tbCustomer";
            this.tbCustomer.ReadOnly = true;
            this.tbCustomer.Size = new System.Drawing.Size(345, 15);
            this.tbCustomer.TabIndex = 68;
            this.tbCustomer.Text = "Не задан";
            // 
            // tbOwner
            // 
            this.tbOwner.BackColor = System.Drawing.SystemColors.Control;
            this.tbOwner.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tbOwner.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbOwner.Location = new System.Drawing.Point(9, 38);
            this.tbOwner.Name = "tbOwner";
            this.tbOwner.ReadOnly = true;
            this.tbOwner.Size = new System.Drawing.Size(345, 15);
            this.tbOwner.TabIndex = 68;
            this.tbOwner.Text = "Не задан";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label8.Location = new System.Drawing.Point(6, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 16);
            this.label8.TabIndex = 64;
            this.label8.Text = "Исполнитель работ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label9.Location = new System.Drawing.Point(6, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 16);
            this.label9.TabIndex = 64;
            this.label9.Text = "Заказчик работ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label10.Location = new System.Drawing.Point(6, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Владелец дороги";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.BackColor = System.Drawing.SystemColors.Control;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.labelStatus.Location = new System.Drawing.Point(66, 249);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.labelStatus.Size = new System.Drawing.Size(57, 16);
            this.labelStatus.TabIndex = 30;
            this.labelStatus.Text = "Статус";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbAddress);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.groupBox4.Location = new System.Drawing.Point(11, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 79);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Адрес";
            // 
            // tbAddress
            // 
            this.tbAddress.BackColor = System.Drawing.SystemColors.Control;
            this.tbAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tbAddress.Location = new System.Drawing.Point(3, 17);
            this.tbAddress.Multiline = true;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.ReadOnly = true;
            this.tbAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAddress.Size = new System.Drawing.Size(194, 59);
            this.tbAddress.TabIndex = 29;
            // 
            // groupBox5
            // 
            this.groupBox5.AutoSize = true;
            this.groupBox5.Controls.Add(this.tbWorkSort);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.groupBox5.Location = new System.Drawing.Point(12, 117);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(311, 129);
            this.groupBox5.TabIndex = 30;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Полное описание";
            // 
            // tbWorkSort
            // 
            this.tbWorkSort.BackColor = System.Drawing.SystemColors.Control;
            this.tbWorkSort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbWorkSort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbWorkSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tbWorkSort.Location = new System.Drawing.Point(3, 17);
            this.tbWorkSort.Multiline = true;
            this.tbWorkSort.Name = "tbWorkSort";
            this.tbWorkSort.ReadOnly = true;
            this.tbWorkSort.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbWorkSort.Size = new System.Drawing.Size(305, 109);
            this.tbWorkSort.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label5.Location = new System.Drawing.Point(20, 94);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label5.Size = new System.Drawing.Size(88, 19);
            this.label5.TabIndex = 30;
            this.label5.Text = "Класс работ";
            // 
            // RoadRepairInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(700, 274);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelRepairType);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoadRepairInfoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация о дорожной работе";
            this.TransparencyKey = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelRepairType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbWorkSort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label labelEndFact;
        private System.Windows.Forms.Label labelStartFact;
        private System.Windows.Forms.TextBox tbPerformer;
        private System.Windows.Forms.TextBox tbCustomer;
        private System.Windows.Forms.TextBox tbOwner;
    }
}