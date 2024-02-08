using DevExpress.DashboardWeb;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace DXApplication
{
  public class DataBaseEditaleDashboardStorage : IEditableDashboardStorage
  {
    public string AddDashboard(XDocument document, string dashboardName)
    {
      //using SqlConnection connection = new(connectionString);
      //connection.Open();
      //MemoryStream stream = new();
      //document.Save(stream);
      //stream.Position = 0;

      //SqlCommand InsertCommand = new(
      //    "INSERT INTO Dashboards (Dashboard, Caption) " +
      //    "output INSERTED.ID " +
      //    "VALUES (@Dashboard, @Caption)");
      //InsertCommand.Parameters.Add("Caption", SqlDbType.NVarChar).Value = dashboardName;
      //InsertCommand.Parameters.Add("Dashboard", SqlDbType.VarBinary).Value = stream.ToArray();
      //InsertCommand.Connection = connection;
      //string ID = InsertCommand.ExecuteScalar().ToString()!;
      //connection.Close();

      return "dashboardid";
    }

    public XDocument LoadDashboard(string dashboardId)
    {
      //using SqlConnection connection = new(connectionString);
      //connection.Open();
      //SqlCommand GetCommand = new("SELECT  Dashboard FROM Dashboards WHERE ID=@ID");
      //GetCommand.Parameters.Add("ID", SqlDbType.Int).Value = Convert.ToInt32(dashboardID);
      //GetCommand.Connection = connection;
      //SqlDataReader reader = GetCommand.ExecuteReader();
      //reader.Read();
      //byte[] data = (reader.GetValue(0) as byte[])!;
      //MemoryStream stream = new(data);
      //connection.Close();

      return XDocument.Load($"./Data/Dashboards/{dashboardId}.xml");
    }

    public IEnumerable<DashboardInfo> GetAvailableDashboardsInfo()
    {
      List<DashboardInfo> list = [];

      //using (SqlConnection connection = new(connectionString))
      //{
      //  connection.Open();
      //  SqlCommand GetCommand = new("SELECT ID, Caption FROM Dashboards");
      //  GetCommand.Connection = connection;
      //  SqlDataReader reader = GetCommand.ExecuteReader();
      //  while (reader.Read())
      //  {
      //    string ID = reader.GetInt32(0).ToString();
      //    string Caption = reader.GetString(1);
      //    list.Add(new DashboardInfo() { ID = ID, Name = Caption });
      //  }
      //  connection.Close();
      //}

      list.Add(new DashboardInfo() { ID = "ds1", Name = "Dashboard 1" });
      list.Add(new DashboardInfo() { ID = "ds2", Name = "Dashboard 2" });

      return list;
    }

    public void SaveDashboard(string dashboardID, XDocument document)
    {
      //using SqlConnection connection = new(connectionString);
      //connection.Open();
      //MemoryStream stream = new();
      //document.Save(stream);
      //stream.Position = 0;

      //SqlCommand InsertCommand = new(
      //    "UPDATE Dashboards Set Dashboard = @Dashboard " +
      //    "WHERE ID = @ID");
      //InsertCommand.Parameters.Add("ID", SqlDbType.Int).Value = Convert.ToInt32(dashboardID);
      //InsertCommand.Parameters.Add("Dashboard", SqlDbType.VarBinary).Value = stream.ToArray();
      //InsertCommand.Connection = connection;
      //InsertCommand.ExecuteNonQuery();

      //connection.Close();
    }
  }
}
