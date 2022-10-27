using System.Data.SqlClient;
using System.Data;

namespace WebApplication3.Repository
{
    public class ADO_ProductosVendidos
    {
        public static void EliminarProductoVendido(int id)
        {
            using (SqlConnection connection = new SqlConnection(General.ConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM ProductoVendido WHERE id = @id";

                var param = new SqlParameter();
                param.ParameterName = "id";
                param.SqlDbType = SqlDbType.BigInt;
                param.Value = id;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
