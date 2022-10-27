using System.Data.SqlClient;
namespace WebApplication3.Repository
{
    public class General
    {
        public static string ConnectionString()
        {

            SqlConnectionStringBuilder connectionbuilder = new();
            connectionbuilder.DataSource = "DESKTOP-TA5P0R7";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var connectionString = connectionbuilder.ConnectionString;
            return connectionString;
        }
    }
}
