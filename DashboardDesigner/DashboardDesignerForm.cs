using DevExpress.DashboardCommon;
using DevExpress.DashboardWin;
using DevExpress.DataAccess;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DashboardDesigner
{
  public partial class DashboardDesignerForm : Form
  {
    private bool isDashboadModified = false;

    private void AddCRMDataSource()
    {
      DashboardSqlDataSource sqlDataSource = new DashboardSqlDataSource("CRM Data Source")
      {
        ConnectionParameters = new OracleConnectionParameters
        {
          ProviderType = OracleProviderType.ODPManaged,
          ServerName = "godfather/casinodev",
          UserName = "casinocrm",
          Password = "sporades"
        }
      };
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

    private void DashboardDesigner_DashboardClosing(object sender, DashboardClosingEventArgs e)
    {
      e.IsDashboardModified = isDashboadModified;
    }

    private void DashboardDesigner_DashboardChanged(object sender, EventArgs e)
    {
      DashboardDesigner.Dashboard.OptionsChanged += (_sender, _e) =>
      {
        isDashboadModified = undoBarItem1.Enabled || redoBarItem1.Enabled;
      };
    }

    private void BbiNewDashboard_ItemClick(object sender, ItemClickEventArgs e)
    {
      if(isDashboadModified)
      {
        var result = MessageBox.Show("Dashboard is modified. Save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);

        if (result == DialogResult.Cancel) 
          return;

        if (result == DialogResult.Yes)
        {
          if (saveDashboardDialog.ShowDialog() == DialogResult.OK)
          {
            DashboardDesigner.Dashboard.SaveToXml(saveDashboardDialog.FileName);
            isDashboadModified = false;
          }
          else
          {
            return;
          }
        }
      }

      Dashboard dashboard = new Dashboard();

      DashboardSqlDataSource sqlDataSource = new DashboardSqlDataSource("CRM Data Source")
      {
        ConnectionParameters = new OracleConnectionParameters
        {
          ProviderType = OracleProviderType.ODPManaged,
          ServerName = "godfather/casinodev",
          UserName = "casinocrm",
          Password = "sporades"
        }
      };
      dashboard.DataSources.Add(sqlDataSource);

      DashboardDesigner.Dashboard = dashboard;      
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
        isDashboadModified = false;
      }
    }
  }
}
