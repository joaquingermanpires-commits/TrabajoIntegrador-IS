using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class BitacoraDal
    {
        public void Registrar(Bitacora bitacora)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_RegistrarBitacora", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", bitacora.Usuario);
                    cmd.Parameters.AddWithValue("@Criticidad", bitacora.Criticidad);
                    cmd.Parameters.AddWithValue("@Modulo", bitacora.Modulo);
                    cmd.Parameters.AddWithValue("@Mensaje", bitacora.Mensaje);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<Bitacora> Consultar()
        {
            List<Bitacora> lista = new List<Bitacora>();
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ConsultarBitacora", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Bitacora b = new Bitacora();
                        b.ID_Bitacora = Convert.ToInt32(reader["ID_Bitacora"]);
                        b.Fecha = Convert.ToDateTime(reader["Fecha"]);
                        b.Usuario = reader["Usuario"].ToString();
                        b.Criticidad = reader["Criticidad"].ToString();
                        b.Modulo = reader["Modulo"].ToString();
                        b.Mensaje = reader["Mensaje"].ToString();
                        lista.Add(b);
                    }
                }
            }
            return lista;
        }
    }
}