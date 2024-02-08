using DevExpress.DashboardCommon;
using DevExpress.DataAccess.ConnectionParameters;
using System.Windows.Forms;

namespace DashboardViewer
{
  public partial class DashboardViewerForm : Form
  {
    public DashboardViewerForm()
    {
      InitializeComponent();
    }

    private void DashboardViewer_ConfigureDataConnection(object sender, DashboardConfigureDataConnectionEventArgs e)
    {
      if (e.DataSourceName == "CRM Data Source")
      {
        e.ConnectionParameters = new OracleConnectionParameters
        {
          ProviderType = OracleProviderType.ODPManaged,
          ServerName = "godfather/casinodev",
          UserName = "casinocrm",
          Password = "sporades"
        };
      }
    }

    private void BtnOpenDashboard_Click(object sender, System.EventArgs e)
    {
      if (openDashboardDialog.ShowDialog() == DialogResult.OK)
      {
        dashboardViewer.Dashboard = new Dashboard();        
        dashboardViewer.Dashboard.LoadFromXml(openDashboardDialog.FileName);
      }
    }

    private void BtnReloadData_Click(object sender, System.EventArgs e)
    {
      if (dashboardViewer.Dashboard != null)
        dashboardViewer.ReloadData();
    }
  }
}
