using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EventoDal
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
        public bool InsertarEvento_SP(Evento evento)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarEvento_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Restaurante", evento.ID_Restaurante);
                    cmd.Parameters.AddWithValue("@Nombre", evento.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", evento.Descripcion);
                    cmd.Parameters.AddWithValue("@FechaInicio", evento.FechaHoraInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", evento.FechaHoraFin);
                    cmd.Parameters.AddWithValue("@Descuento", evento.PorcentajeDescuento);

                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public IList<Evento> ObtenerEventosActivos(int idRestaurante, DateTime fechaHora)
        {
            IList<Evento> lista = new List<Evento>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerEventosActivos_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Restaurante", idRestaurante);
                    cmd.Parameters.AddWithValue("@FechaHoraConsulta", fechaHora);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Evento
                            {
                                ID_Evento = Convert.ToInt32(reader["ID_Evento"]),
                                ID_Restaurante = Convert.ToInt32(reader["ID_Restaurante"]),
                                Nombre = reader["Nombre"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                FechaHoraInicio = Convert.ToDateTime(reader["FechaHoraInicio"]),
                                FechaHoraFin = Convert.ToDateTime(reader["FechaHoraFin"]),
                                PorcentajeDescuento = Convert.ToDecimal(reader["PorcentajeDescuento"])
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}
