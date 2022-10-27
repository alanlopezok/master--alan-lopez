using System.Data;
using System.Data.SqlClient;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public class ADO_Producto
    {
        public static List<Producto> DevolverProductos()
        {
            var listaProductos = new List<Producto>();
            using (SqlConnection connection = new SqlConnection(General.ConnectionString()))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "SELECT * FROM producto";
                var reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    var pro = new Producto();
                    pro.Idp = Convert.ToInt32(reader2.GetValue(0));
                    pro.Descripciones= reader2.GetValue(1).ToString();
                    pro.Costo = Convert.ToDouble(reader2.GetValue(2));
                   pro.PrecioVenta = Convert.ToDouble(reader2.GetValue(3));
                    pro.Stock =Convert.ToInt32(reader2.GetValue(4));
                    pro.IdUsuario =Convert.ToInt32(reader2.GetValue(5));
                    listaProductos.Add(pro);
                }
                reader2.Close();
                connection.Close();
            }
            return listaProductos;
        }

        public static void CrearProducto(Producto pro)
        {
            using (SqlConnection connection = new SqlConnection(General.ConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Producto (Idp,Descripciones,Costo,PrecioVenta,Stock,IdUsuario)" + "values(@idp,@desc,@cost,@precio,@stock,@idus)";

                var param = new SqlParameter();
                param.ParameterName = "idp";
                param.SqlDbType = SqlDbType.BigInt;
                param.Value = pro.Idp;

                var paramd = new SqlParameter();
                paramd.ParameterName = "desc";
                paramd.SqlDbType = SqlDbType.VarChar;
                paramd.Value = pro.Descripciones;

                var paramc = new SqlParameter();
                paramc.ParameterName = "cost";
                paramc.SqlDbType = SqlDbType.Float;
                paramc.Value = pro.Costo;

                var paramp = new SqlParameter();
                paramp.ParameterName = "precio";
                paramp.SqlDbType = SqlDbType.Float;
                paramp.Value = pro.PrecioVenta;

                var paramst = new SqlParameter();
                paramst.ParameterName = "stock";
                paramst.SqlDbType = SqlDbType.BigInt;
                paramst.Value = pro.Stock;

                var paramidu = new SqlParameter();
                paramidu.ParameterName = "idus";
                paramidu.SqlDbType = SqlDbType.BigInt;
                paramidu.Value = pro.IdUsuario;


                cmd.Parameters.Add(param);
                cmd.Parameters.Add(paramd);
                cmd.Parameters.Add(paramc);
                cmd.Parameters.Add(paramp);
                cmd.Parameters.Add(paramst);
                cmd.Parameters.Add(paramidu);

                cmd.ExecuteReader();
                connection.Close();
            }
        }

        public static void ModificarProducto(Producto pro)
        {
            using (SqlConnection connection = new SqlConnection(General.ConnectionString()))
            {

                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "update producto set Descripciones= @des, Costo=@cost,PrecioVenta=@pre,Stock=@s,IdUsuario=@idu where Id =@iding";


                var param = new SqlParameter();
                param.ParameterName = "iding";
                param.SqlDbType = SqlDbType.BigInt;
                param.Value = pro.Idp;

                var paramd = new SqlParameter();
                paramd.ParameterName = "des";
                paramd.SqlDbType = SqlDbType.VarChar;
                paramd.Value = pro.Descripciones;

                var paramc = new SqlParameter();
                paramc.ParameterName = "cost";
                paramc.SqlDbType = SqlDbType.Float;
                paramc.Value = pro.Costo;


                var paramp = new SqlParameter();
                paramp.ParameterName = "pre";
                paramp.SqlDbType = SqlDbType.Float;
                paramp.Value = pro.PrecioVenta;


                var paramss= new SqlParameter();
                paramss.ParameterName = "s";
                paramss.SqlDbType = SqlDbType.BigInt;
                paramss.Value = pro.Stock;


                var parami = new SqlParameter();
                parami.ParameterName = "idu";
                parami.SqlDbType = SqlDbType.BigInt;
                parami.Value = pro.IdUsuario;

                cmd.Parameters.Add(param);
                cmd.Parameters.Add(paramd);
                cmd.Parameters.Add(paramc);
                cmd.Parameters.Add(paramp);
                cmd.Parameters.Add(paramss);
                cmd.Parameters.Add(parami);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void EliminarProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(General.ConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM Producto WHERE id = @id";

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
