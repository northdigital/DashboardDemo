using DevExpress.DashboardCommon;
using DevExpress.DashboardWin;
using DevExpress.DataAccess;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DashboardDesigner
{
  public partial class DashboardDesignerForm : Form
  {
    private void AddObjDataSource()
    {
      DashboardDesigner.DataSourceOptions.ObjectDataSourceLoadingBehavior = DocumentLoadingBehavior.LoadAsIs;

      DashboardObjectDataSource dataSource1 = new DashboardObjectDataSource("Obj Data Source1");
      DashboardDesigner.DataLoading += (s, ev) =>
      {
        if (ev.DataSourceName == "Obj Data Source1")
          ev.Data = Data.Get1();
      };
      DashboardDesigner.Dashboard.DataSources.Add(dataSource1);

      DashboardObjectDataSource dataSource2 = new DashboardObjectDataSource("Obj Data Source2");
      DashboardDesigner.DataLoading += (s, ev) =>
      {
        if (ev.DataSourceName == "Obj Data Source2")
          ev.Data = Data.Get2();
      };
      DashboardDesigner.Dashboard.DataSources.Add(dataSource2);
    }

    private void AddCRMDataSource()
    {
      DashboardSqlDataSource sqlDataSource = new DashboardSqlDataSource("CRM Data Source");
      DashboardDesigner.Dashboard.DataSources.Add(sqlDataSource);
    }

    private void ConfigureRibbon()
    {
      List<BarItem> itemsToRemove = new List<BarItem>();
      foreach (BarItem item in ribbonControl.Items.Cast<BarItem>())
      {
        if (item is DevExpress.DashboardWin.Bars.FileNewBarItem) itemsToRemove.Add(item);
        if (item is DevExpress.DashboardWin.Bars.FileOpenBarItem) itemsToRemove.Add(item);
        if (item is DevExpress.DashboardWin.Bars.FileSaveBarItem) itemsToRemove.Add(item);
        if (item is DevExpress.DashboardWin.Bars.FileSaveAsBarItem) itemsToRemove.Add(item);
      }
      foreach (BarItem item in itemsToRemove)
        ribbonControl.Items.Remove(item);
    }

    public DashboardDesignerForm()
    {
      InitializeComponent();

      ConfigureRibbon();

      AddCRMDataSource();
    }

    private void DashboardDesigner_ConfigureDataConnection(object sender, DashboardConfigureDataConnectionEventArgs e)
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

    private void BbiOpenDashboard_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (openDashboardDialog.ShowDialog() == DialogResult.OK)
      {
        DashboardDesigner.Dashboard.LoadFromXml(openDashboardDialog.FileName);
      }     
    }

    private void BbiSaveDashboard_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (saveDashboardDialog.ShowDialog() == DialogResult.OK)
      {
        DashboardDesigner.Dashboard.SaveToXml(saveDashboardDialog.FileName);
      }      
    }

    private void DashboardDesigner_CustomizeDashboardTitle(object sender, CustomizeDashboardTitleEventArgs e)
    {
      DashboardToolbarItem titleButton = new DashboardToolbarItem("Load Data",
        new Action<DashboardToolbarItemClickEventArgs>(args =>
        {
          DashboardDesigner.ReloadData();
        }))
      {
        Caption = "Reload Data"
      };
      e.Items.Add(titleButton);
    }    
  }
}
