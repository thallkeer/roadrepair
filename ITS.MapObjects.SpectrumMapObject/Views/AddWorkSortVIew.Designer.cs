namespace ITS.MapObjects.RoadRepairingMapObject.Views
{
    partial class AddWorkSortView
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
            this.toolTipWorkType = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tbWorkSort = new System.Windows.Forms.TextBox();
            this.cB_WorkType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cB_RepairType = new System.Windows.Forms.ComboBox();
            this.btnLoadFromFile = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // tbWorkSort
            // 
            this.tbWorkSort.Location = new System.Drawing.Point(98, 92);
            this.tbWorkSort.Multiline = true;
            this.tbWorkSort.Name = "tbWorkSort";
            this.tbWorkSort.Size = new System.Drawing.Size(292, 95);
            this.tbWorkSort.TabIndex = 77;
            // 
            // cB_WorkType
            // 
            this.cB_WorkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_WorkType.FormattingEnabled = true;
            this.cB_WorkType.Location = new System.Drawing.Point(98, 54);
            this.cB_WorkType.Name = "cB_WorkType";
            this.cB_WorkType.Size = new System.Drawing.Size(292, 21);
            this.cB_WorkType.TabIndex = 73;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 74;
            this.label1.Text = "Состав работ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 57);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 13);
            this.label17.TabIndex = 75;
            this.label17.Text = "Вид работ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 13);
            this.label16.TabIndex = 76;
            this.label16.Text = "Тип ремонта";
            // 
            // cB_RepairType
            // 
            this.cB_RepairType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_RepairType.DropDownWidth = 283;
            this.cB_RepairType.FormattingEnabled = true;
            this.cB_RepairType.Location = new System.Drawing.Point(98, 17);
            this.cB_RepairType.Name = "cB_RepairType";
            this.cB_RepairType.Size = new System.Drawing.Size(292, 21);
            this.cB_RepairType.TabIndex = 72;
            // 
            // btnLoadFromFile
            // 
            this.btnLoadFromFile.Location = new System.Drawing.Point(273, 193);
            this.btnLoadFromFile.Name = "btnLoadFromFile";
            this.btnLoadFromFile.Size = new System.Drawing.Size(117, 23);
            this.btnLoadFromFile.TabIndex = 70;
            this.btnLoadFromFile.Text = "Загрузить из файла";
            this.btnLoadFromFile.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(192, 193);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 71;
            this.btnOK.Text = "Добавить";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // AddWorkSortView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 222);
            this.Controls.Add(this.tbWorkSort);
            this.Controls.Add(this.cB_WorkType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cB_RepairType);
            this.Controls.Add(this.btnLoadFromFile);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddWorkSortView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление категории работ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTipWorkType;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox tbWorkSort;
        private System.Windows.Forms.ComboBox cB_WorkType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cB_RepairType;
        private System.Windows.Forms.Button btnLoadFromFile;
        private System.Windows.Forms.Button btnOK;
    }
}