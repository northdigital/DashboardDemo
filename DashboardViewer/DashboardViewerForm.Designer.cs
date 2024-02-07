
namespace DashboardViewer
{
  partial class DashboardViewerForm
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
      this.dashboardViewer = new DevExpress.DashboardWin.DashboardViewer(this.components);
      this.openDashboardDialog = new System.Windows.Forms.OpenFileDialog();
      this.panelControl = new DevExpress.XtraEditors.PanelControl();
      this.btnOpenDashboard = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.dashboardViewer)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl)).BeginInit();
      this.panelControl.SuspendLayout();
      this.SuspendLayout();
      // 
      // dashboardViewer
      // 
      this.dashboardViewer.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
      this.dashboardViewer.Appearance.Options.UseBackColor = true;
      this.dashboardViewer.AsyncMode = true;
      this.dashboardViewer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dashboardViewer.Location = new System.Drawing.Point(0, 0);
      this.dashboardViewer.Name = "dashboardViewer";
      this.dashboardViewer.Size = new System.Drawing.Size(800, 450);
      this.dashboardViewer.TabIndex = 0;
      this.dashboardViewer.ConfigureDataConnection += new DevExpress.DashboardCommon.DashboardConfigureDataConnectionEventHandler(this.DashboardViewer_ConfigureDataConnection);
      // 
      // openDashboardDialog
      // 
      this.openDashboardDialog.DefaultExt = "xml";
      this.openDashboardDialog.Filter = "Dashboard|*.xml";
      // 
      // panelControl
      // 
      this.panelControl.Controls.Add(this.btnOpenDashboard);
      this.panelControl.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelControl.Location = new System.Drawing.Point(0, 0);
      this.panelControl.Name = "panelControl";
      this.panelControl.Size = new System.Drawing.Size(800, 43);
      this.panelControl.TabIndex = 1;
      // 
      // btnOpenDashboard
      // 
      this.btnOpenDashboard.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
      this.btnOpenDashboard.Appearance.Options.UseFont = true;
      this.btnOpenDashboard.Location = new System.Drawing.Point(12, 6);
      this.btnOpenDashboard.Name = "btnOpenDashboard";
      this.btnOpenDashboard.Size = new System.Drawing.Size(130, 30);
      this.btnOpenDashboard.TabIndex = 0;
      this.btnOpenDashboard.Text = "Open Dashboard";
      this.btnOpenDashboard.Click += new System.EventHandler(this.BtnOpenDashboard_Click);
      // 
      // DashboardViewerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.panelControl);
      this.Controls.Add(this.dashboardViewer);
      this.Name = "DashboardViewerForm";
      this.Text = "Dashboard Viewer";
      ((System.ComponentModel.ISupportInitialize)(this.dashboardViewer)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl)).EndInit();
      this.panelControl.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.DashboardWin.DashboardViewer dashboardViewer;
    private System.Windows.Forms.OpenFileDialog openDashboardDialog;
    private DevExpress.XtraEditors.PanelControl panelControl;
    private DevExpress.XtraEditors.SimpleButton btnOpenDashboard;
  }
}

