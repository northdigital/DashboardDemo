using DevExpress.DashboardCommon;
using DevExpress.DashboardWin;
using DevExpress.DataAccess;
using DevExpress.DataAccess.ConnectionParameters;
using System;
using System.Windows.Forms;

namespace DashboardDesigner
{
  public partial class DashboardDesignerForm : Form
  {
    private void LoadObjectData()
    {
      dashboardDesigner.DataSourceOptions.ObjectDataSourceLoadingBehavior = DocumentLoadingBehavior.LoadAsIs;

      DashboardObjectDataSource dataSource1 = new DashboardObjectDataSource("Obj Data Source1");
      dashboardDesigner.DataLoading += (s, ev) =>
      {
        if (ev.DataSourceName == "Obj Data Source1")
          ev.Data = Data.Get1();
      };
      dashboardDesigner.Dashboard.DataSources.Add(dataSource1);

      DashboardObjectDataSource dataSource2 = new DashboardObjectDataSource("Obj Data Source2");
      dashboardDesigner.DataLoading += (s, ev) =>
      {
        if (ev.DataSourceName == "Obj Data Source2")
          ev.Data = Data.Get2();
      };
      dashboardDesigner.Dashboard.DataSources.Add(dataSource2);
    }

    private void LoadSQLData()
    {
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

    public DashboardDesignerForm()
    {
      InitializeComponent();

      LoadSQLData();
    }

    private void DashboardDesigner_DashboardCreating(object sender, DashboardCreatingEventArgs e)
    {
      LoadSQLData();      
      //LoadObjectData();
      //dashboardDesigner.CustomDBSchemaProviderEx = new LimitDBSchemaProvider();
    }

    private void BbbiMySave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      dashboardDesigner.Dashboard.SaveToXml(@"Data\test.xml");      
    }

    private void DashboardDesigner_CustomizeDashboardTitle(object sender, CustomizeDashboardTitleEventArgs e)
    {
      DashboardToolbarItem titleButton = new DashboardToolbarItem("Load Data",
        new Action<DashboardToolbarItemClickEventArgs>(args =>
        {
          dashboardDesigner.ReloadData();
        }))
      {
        Caption = "Reload Data"
      };
      e.Items.Add(titleButton);
    }
  }
}
