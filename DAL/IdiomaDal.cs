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

        // 1. Traer todos los idiomas usando el Stored Procedure
        public List<Idioma> ObtenerIdiomasDisponibles()
        {
            List<Idioma> lista = new List<Idioma>();
            string ConnectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (var connection = new SqlConnection(ConnectionString))
            {
                // Usamos el nombre del SP en lugar del SELECT
                using (SqlCommand cmd = new SqlCommand("SP_ObtenerIdiomasDisponibles", connection))
                {
                    // ¡Clave! Le decimos explícitamente que es un Stored Procedure
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

        // 2. Traer el diccionario usando el Stored Procedure
        public Dictionary<string, string> ObtenerTraducciones(int idIdioma)
        {
            Dictionary<string, string> traducciones = new Dictionary<string, string>();
            string ConnectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ObtenerTraducciones", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Pasamos el parámetro que pide el SP
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
    }
}
