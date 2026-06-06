using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class IdiomaDal
    {
        //Lectura y Carga(Read)
        public List<Idioma> ObtenerIdiomasDisponibles()
        {
            List<Idioma> lista = new List<Idioma>();
            string ConnectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ObtenerIdiomasDisponibles", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Idioma objIdioma = new Idioma();
                        objIdioma.ID_Idioma = Convert.ToInt32(reader["ID_Idioma"]);
                        objIdioma.Nombre = reader["Nombre"].ToString();
                        objIdioma.PorDefecto = Convert.ToBoolean(reader["PorDefecto"]);
                        lista.Add(objIdioma);
                    }
                }
            }
            return lista;
        }
        public Dictionary<string, string> ObtenerTraducciones(int idIdioma)
        {
            Dictionary<string, string> traducciones = new Dictionary<string, string>();
            string ConnectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ObtenerTraducciones", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdIdioma", idIdioma);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string control = reader["Nombre_Control"].ToString();
                        string texto = reader["Texto"].ToString();
                        traducciones.Add(control, texto);
                    }
                }
            }
            return traducciones;
        }
        public DataTable ObtenerDiccionarioCompleto(int idIdioma)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IS"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ObtenerDiccionarioCompleto", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdIdioma", idIdioma);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        //Gestión de Idiomas (Write)
        public void AgregarIdiomaCopiaDefault(string nombreIdioma)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_AgregarIdiomaCopiaDefault", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreIdioma", nombreIdioma);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void EliminarIdioma(int idIdioma)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SP_EliminarIdioma", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdIdioma", idIdioma);
                    command.ExecuteNonQuery();
                }
            }
        }
        //Gestión de Etiquetas (Write)
        public void AgregarEtiqueta(string nombreControl)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_AgregarEtiqueta", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre_Control", nombreControl);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void ModificarEtiqueta(string nombreViejo, string nombreNuevo)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IS"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ModificarEtiqueta", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreViejo", nombreViejo);
                    cmd.Parameters.AddWithValue("@NombreNuevo", nombreNuevo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void EliminarEtiqueta(string nombreControl)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_EliminarEtiqueta", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreControl", nombreControl);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //Gestión de Traducciones (Write)
        public void GuardarTraduccion(int idIdioma, string nombreControl, string texto)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IS"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ActualizarTraduccion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdIdioma", idIdioma);
                    cmd.Parameters.AddWithValue("@NombreControl", nombreControl);
                    cmd.Parameters.AddWithValue("@Texto", texto);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
