using static WebApplication3.Controllers.UsuarioController;
using System.Reflection;
using System.Data.SqlClient;
using WebApplication3.Models;
using WebApplication3.Repository;
using System.Data;

namespace WebApplication3.Repository
{
    public class ADO_Usuario
    {
        public static List<Usuario> DevolverUsuarios()
        {
            var listaUsuarios = new List<Usuario>();
            using (SqlConnection connection = new SqlConnection(General.ConnectionString()))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "SELECT * FROM usuario";
                var reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    var usuario = new Usuario();
                    usuario.Id = Convert.ToInt32(reader2.GetValue(0));
                    usuario.Nombre = reader2.GetValue(1).ToString();
                    usuario.Apellido = reader2.GetValue(2).ToString();
                    usuario.NombreUsuario = reader2.GetValue(3).ToString();
                    usuario.Contraseña = reader2.GetValue(4).ToString();
                    usuario.Mail = reader2.GetValue(5).ToString();
                    listaUsuarios.Add(usuario);
                }
                reader2.Close();
                connection.Close();
            }
            return listaUsuarios;
        }

        public static void EliminarUsuario(int id)
        {
            using(SqlConnection connection = new SqlConnection(General.ConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM usuario WHERE id = @idusu";

                var param = new SqlParameter();
                param.ParameterName = "idusu";
                param.SqlDbType = SqlDbType.BigInt;
                param.Value = id;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void AgregarUsuario(Usuario us)
        {
            using (SqlConnection connection = new SqlConnection(General.ConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO usuario (Id,Nombre,Apellido,NombreUsuario,Contraseña,Mail)"+"values(@idusu,@nusu,@ausu,@nombusu,@cont,@mail)";

                var param = new SqlParameter();
                param.ParameterName = "idusu";
                param.SqlDbType = SqlDbType.BigInt;
                param.Value = us.Id;

                var paramn = new SqlParameter();
                paramn.ParameterName = "nusu";
                paramn.SqlDbType = SqlDbType.VarChar;
                paramn.Value = us.Nombre;

                var parama = new SqlParameter();
                parama.ParameterName = "ausu";
                parama.SqlDbType = SqlDbType.VarChar;
                parama.Value = us.Apellido;

                var paramnom = new SqlParameter();
                paramnom.ParameterName = "nombusu";
                paramnom.SqlDbType = SqlDbType.VarChar;
                paramnom.Value = us.NombreUsuario;

                var paramc = new SqlParameter();
                paramc.ParameterName = "cont";
                paramc.SqlDbType = SqlDbType.VarChar;
                paramc.Value = us.Contraseña;

                var paramm = new SqlParameter();
                paramm.ParameterName = "mail";
                paramm.SqlDbType = SqlDbType.VarChar;
                paramm.Value = us.Mail;

                cmd.Parameters.Add(param);
                cmd.Parameters.Add(paramn);
                cmd.Parameters.Add(parama);
                cmd.Parameters.Add(paramnom);
                cmd.Parameters.Add(paramc);
                cmd.Parameters.Add(paramm);

                cmd.ExecuteReader();
                connection.Close();
            }
        }

        public static void ModificarUsuario(Usuario us)
        {
            using (SqlConnection connection = new SqlConnection(General.ConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "update Usuario set Nombre= @nomb, Apellido=@app,NombreUsuario=@nu,Contraseña=@cont,Mail=@mail where Id=@idingreso";

                var param = new SqlParameter();
                param.ParameterName = "idingreso";
                param.SqlDbType = SqlDbType.BigInt;
                param.Value = us.Id;


                var paramn = new SqlParameter();
                paramn.ParameterName = "nomb";
                paramn.SqlDbType = SqlDbType.VarChar;
                paramn.Value = us.Nombre;

                var parama = new SqlParameter();
                parama.ParameterName = "app";
                parama.SqlDbType = SqlDbType.VarChar;
                parama.Value = us.Apellido;

                var paramnom = new SqlParameter();
                paramnom.ParameterName = "nu";
                paramnom.SqlDbType = SqlDbType.VarChar;
                paramnom.Value = us.NombreUsuario;

                var paramc = new SqlParameter();
                paramc.ParameterName = "cont";
                paramc.SqlDbType = SqlDbType.VarChar;
                paramc.Value = us.Contraseña;

                var paramm = new SqlParameter();
                paramm.ParameterName = "mail";
                paramm.SqlDbType = SqlDbType.VarChar;
                paramm.Value = us.Mail;


                cmd.Parameters.Add(param);
                cmd.Parameters.Add(paramn);
                cmd.Parameters.Add(parama);
                cmd.Parameters.Add(paramnom);
                cmd.Parameters.Add(paramc);
                cmd.Parameters.Add(paramm);

                cmd.ExecuteReader();
                connection.Close();

            }
        }
    }
}

