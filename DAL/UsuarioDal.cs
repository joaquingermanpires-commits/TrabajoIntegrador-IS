using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class UsuarioDal
    {
        public Usuario Login(string Usuario_Nombre, string Contraseña_Hash)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    // Uso de Stored Procedure
                    using (var command = new SqlCommand("Usuario_Login", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@Username", SqlDbType.VarChar).Value = Usuario_Nombre;
                        command.Parameters.Add("@Password", SqlDbType.VarChar).Value = Contraseña_Hash;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Usuario userLogueado = new Usuario(); 
                                userLogueado.ID_Usuario = reader.GetInt64(0);
                                userLogueado.Nombre_Usuario = reader.GetString(1);

                                return userLogueado;
                            }
                        }
                    }
                    return null; // Si no encuentra el usuario
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error de base de datos.", ex);
                }
            }
        }
        public void Alta(Usuario usuario)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("Usuario_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Username", SqlDbType.VarChar).Value = usuario.Nombre_Usuario;
                    command.Parameters.Add("@Password", SqlDbType.VarChar).Value = usuario.Contraseña_Hash;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Modificar(Usuario usuario)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("Usuario_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id_Usuario", SqlDbType.BigInt).Value = usuario.ID_Usuario;
                    command.Parameters.Add("@Username", SqlDbType.VarChar).Value = usuario.Nombre_Usuario;
                    command.Parameters.Add("@Password", SqlDbType.VarChar).Value = usuario.Contraseña_Hash;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Baja(long idUsuario)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("Usuario_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id_Usuario", SqlDbType.BigInt).Value = idUsuario;
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Usuario> ListarTodos()
        {
            List<Usuario> lista = new List<Usuario>();
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("Usuario_GetAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario user = new Usuario();
                            user.ID_Usuario = reader.GetInt64(0);
                            user.Nombre_Usuario = reader.GetString(1);
                            lista.Add(user);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
