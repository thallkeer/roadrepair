using System;
using System.Windows.Forms;
using ITS.MapObjects.RoadRepairingMapObject.IViews;

namespace ITS.MapObjects.RoadRepairingMapObject.Views
{
    public class BaseView : Form, IBaseView
    {
        #region Implementation of IRoadRepairView

        public DialogResult ShowViewDialog()
        {
            if (ViewShowing != null) ViewShowing();
            IsViewVisible = true;
            return ShowDialog();
        }

        public void ShowView()
        {
            if (ViewShowing != null) ViewShowing();
            IsViewVisible = true;
            Show();
        }

        public void CloseView()
        {
            IsViewVisible = false;
            if (ViewClosing != null) ViewClosing();
            Close();
        }

        public event Action ViewShowing;
        public event Action ViewClosing;

        public bool IsViewVisible { get; private set; }

        #endregion

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseView));
            this.SuspendLayout();
            // 
            // BaseView
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }
    }
}