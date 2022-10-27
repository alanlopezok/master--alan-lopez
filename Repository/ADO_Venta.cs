using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Tracing;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public class ADO_Venta
    {
        public static void CargarVenta(VentaProducto vtaProductos)
        {
            long idVenta;

            using (SqlConnection connection = new SqlConnection(General.ConnectionString()))
            {
                
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Venta] (Comentarios, IdUsuario) VALUES (@Comentarios, @IdUsuario); Select scope_identity();", connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.NVarChar)).Value = vtaProductos.Comentarios;
                cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt)).Value = vtaProductos.IdUsuario;
                idVenta = Convert.ToInt64(cmd.ExecuteScalar());

                
                foreach (ProductoVendido producto in vtaProductos.Productos)
                {
                    
                    cmd = new SqlCommand("INSERT INTO ProductoVendido (Stock,IdProducto,IdVenta)  VALUES   (@Stock,@IdProducto,@IdVenta) ", connection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int)).Value = producto.Stock;
                    cmd.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt)).Value = producto.IdProducto;
                    cmd.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.BigInt)).Value = idVenta;
                    cmd.ExecuteNonQuery();
                    
                    cmd = new SqlCommand("UPDATE Producto SET Stock = Stock - @Stock WHERE idProducto = @IdProducto", connection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int)).Value = producto.Stock;
                    cmd.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt)).Value = producto.IdProducto;
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }

        }
        public static List<Venta> DevolverVenta()
        {
            var ventas = new List<Venta>();

            using (SqlConnection connection = new SqlConnection(General.ConnectionString()))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "SELECT Id,Comentarios,IdUsuario FROM Venta";
                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var venta = new Venta();
                    venta.Id = Convert.ToInt32(reader2.GetValue(0));
                    venta.Comentarios = reader2.GetValue(1).ToString();
                    venta.IdUsuario = Convert.ToInt32(reader2.GetValue(2));

                    ventas.Add(venta);

                }
                reader2.Close();
                connection.Close();

            }
            return ventas;
        }
    }
}
