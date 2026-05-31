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
        public List<Bitacora> ConsultarConFiltros(DateTime? fechaDesde, DateTime? fechaHasta, string criticidad, string usuario)
        {
            List<Bitacora> lista = new List<Bitacora>();
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ConsultarBitacoraFiltros", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaDesde", (object)fechaDesde ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaHasta", (object)fechaHasta ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Criticidad", string.IsNullOrEmpty(criticidad) ? DBNull.Value : (object)criticidad);
                    cmd.Parameters.AddWithValue("@Usuario", string.IsNullOrEmpty(usuario) ? DBNull.Value : (object)usuario);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Bitacora b = new Bitacora
                        {
                            ID_Bitacora = Convert.ToInt32(reader["ID_Bitacora"]),
                            Fecha = Convert.ToDateTime(reader["Fecha"]),
                            Usuario = reader["Usuario"].ToString(),
                            Criticidad = reader["Criticidad"].ToString(),
                            Modulo = reader["Modulo"].ToString(),
                            Mensaje = reader["Mensaje"].ToString()
                        };
                        lista.Add(b);
                    }
                }
            }
            return lista;
        }
    }
}