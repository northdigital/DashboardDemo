using DevExpress.DashboardCommon;
using DevExpress.DashboardWin;
using DevExpress.DataAccess.ConnectionParameters;
using System.Windows.Forms;

namespace DashboardDesigner
{
  public partial class DashboardDesignerForm : Form
  {
    public DashboardDesignerForm()
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

      dashboardDesigner.Dashboard.DataSources.Add(sqlDataSource);
    }

    private void dashboardDesigner_DashboardCreating(object sender, DashboardCreatingEventArgs e)
    {
      DataConnectionParametersBase connParameters = new OracleConnectionParameters
      {
        ProviderType = OracleProviderType.ODPManaged,
        ServerName = "godfather/casinodev",
        UserName = "casinocrm",
        Password = "sporades"
      };

      DashboardSqlDataSource sqlDataSource = new DashboardSqlDataSource("CRM Data Source", connParameters);

      e.Dashboard.DataSources.Add(sqlDataSource);
    }

    private void bbiMySave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      dashboardDesigner.Dashboard.SaveToXml("test1.xml");      
    }
  }
}
