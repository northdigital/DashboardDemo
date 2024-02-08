using DevExpress.DashboardWeb;
using Microsoft.Extensions.FileProviders;
using DevExpress.DataAccess.ConnectionParameters;

namespace DXApplication
{
  public static class DashboardUtils {
        public static DashboardConfigurator CreateDashboardConfigurator(IConfiguration configuration, IFileProvider fileProvider) {
            DashboardConfigurator.PassCredentials = true;

            DashboardConfigurator configurator = new();
            DashboardFileStorage dashboardFileStorage = 
              new(fileProvider.GetFileInfo("Data/Dashboards").PhysicalPath);
            configurator.SetDashboardStorage(dashboardFileStorage);

            configurator.ConfigureDataConnection += (s, e) => {
              if (e.DataSourceName == "CRM Data Source")
              {
                OracleConnectionParameters oracleConnectionParameters = new()
                {
                  ProviderType = OracleProviderType.ODPManaged,
                  ServerName = "godfather/casinodev",
                  UserName = "casinocrm",
                  Password = "sporades",
                };

                e.ConnectionParameters = oracleConnectionParameters;
              }
            };

            return configurator;
        }
    }
}