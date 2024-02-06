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

      DataConnectionParametersBase connParameters = new OracleConnectionParameters
      {
        ProviderType = OracleProviderType.ODPManaged,
        ServerName = "godfather/casinodev",
        UserName = "casinocrm",
        Password = "sporades"
      };

      DashboardSqlDataSource sqlDataSource = new DashboardSqlDataSource("CRM Data Source", connParameters);

      dashboardViewer.Dashboard.DataSources.Add(sqlDataSource);
      dashboardViewer.Dashboard.LoadFromXml("");
      
    }
  }
}
