using DevExpress.DashboardWeb;
using Microsoft.Extensions.FileProviders;
using DevExpress.DataAccess.ConnectionParameters;

namespace DXApplication
{
  public static class DashboardUtils {
        public static DashboardConfigurator CreateDashboardConfigurator(/*IFileProvider fileProvider*/) {
            DashboardConfigurator.PassCredentials = true;
            DashboardConfigurator configurator = new();

      //Define File Storage
      /*
      DashboardFileStorage dashboardFileStorage = 
        new(fileProvider.GetFileInfo("Data/Dashboards").PhysicalPath);
      configurator.SetDashboardStorage(dashboardFileStorage);
      //*/

      //Define Db Storage
      ///*
      var dataBaseDashboardStorage = new DataBaseEditaleDashboardStorage();

      configurator.SetDashboardStorage(dataBaseDashboardStorage);
      //*/

      configurator.ConfigureDataConnection += (s, e) => {
              if (e.DataSourceName == "CRM Data Source")
              {
                OracleConnectionParameters oracleConnectionParameters = new()
                {
                  ProviderType = OracleProviderType.ODPManaged,
                  ServerName = "godfather/casinodev",
                  UserName = "xxx",
                  Password = "yyy",
                };

                e.ConnectionParameters = oracleConnectionParameters;
              }
            };

            return configurator;
        }
    }
}