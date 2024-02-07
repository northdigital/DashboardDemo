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

    private void AddCRMDataSource()
    {
      DashboardSqlDataSource sqlDataSource = new DashboardSqlDataSource("CRM Data Source");
      dashboardDesigner.Dashboard.DataSources.Add(sqlDataSource);
    }

    public DashboardDesignerForm()
    {
      InitializeComponent();

      AddCRMDataSource();
    }

    private void DashboardDesigner_DashboardCreating(object sender, DashboardCreatingEventArgs e)
    {
      //AddCRMDataSource();            
    }

    private void dashboardDesigner_ConfigureDataConnection(object sender, DashboardConfigureDataConnectionEventArgs e)
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

    private void BbbiMySave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      if (saveDashboardFileDialog.ShowDialog() == DialogResult.OK)
      {
        dashboardDesigner.Dashboard.SaveToXml(saveDashboardFileDialog.FileName);
      }
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
