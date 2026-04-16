using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DAL
{
    public class UsuarioDal
    {
        public Usuario Login(string Usuario_Nombre, string Contraseña_Hash) {
            string ConnectionString = ConfigurationManager.ConnectionString["IS"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Usar Stored Procedure según exigencia de la cátedra
                    using (var command = new SqlCommand("Usuario_Login", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@Username", SqlDbType.VarChar).Value = Usuario_Nombre;
                        command.Parameters.Add("@Password", SqlDbType.VarChar).Value = Contraseña_Hash;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Aquí leerías el Perfil (Admin, Cliente, Vendedor) y crearías el objeto BE correspondiente
                                // Por simplicidad, un ejemplo base:
                                Usuario userLogueado = new Usuario(); // O Admin, o Vendedor dependiendo de un campo "Rol" en tu tabla
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
}
