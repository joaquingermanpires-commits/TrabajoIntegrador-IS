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
        public void AgregarIdioma(string nombre)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IS"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_AgregarIdioma", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void AgregarEtiquetaConTraduccion(string nombreControl, int idIdioma, string texto)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_AgregarEtiquetaConTraduccion", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreControl", nombreControl);
                    cmd.Parameters.AddWithValue("@IdIdioma", idIdioma);
                    cmd.Parameters.AddWithValue("@Texto", texto);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void GuardarTraduccion(int idIdioma, string nombreControl, string texto)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IS"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GuardarTraduccion", con))
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
    }
}
