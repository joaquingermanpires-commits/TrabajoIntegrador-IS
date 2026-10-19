using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Negocio
{
    public class HorarioAtencionDal
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
        public List<HorarioAtencion> ObtenerHorarios(int idRestaurante)
        {
            List<HorarioAtencion> lista = new List<HorarioAtencion>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerHorarios_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Restaurante", idRestaurante);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new HorarioAtencion
                            {
                                ID_Horario = Convert.ToInt32(reader["ID_Horario"]),
                                ID_Restaurante = Convert.ToInt32(reader["ID_Restaurante"]),
                                DiaSemana = (DayOfWeek)Convert.ToInt32(reader["DiaSemana"]),
                                Habilitado = Convert.ToBoolean(reader["Habilitado"]),
                                HoraApertura = (TimeSpan)reader["HoraApertura"],
                                HoraCierre = (TimeSpan)reader["HoraCierre"],
                                ValidoDesde = Convert.ToDateTime(reader["ValidoDesde"]),
                                ValidoHasta = reader["ValidoHasta"] != DBNull.Value ? Convert.ToDateTime(reader["ValidoHasta"]) : (DateTime?)null
                            });
                        }
                    }
                }
            }
            return lista;
        }
        public bool InsertarHorario(HorarioAtencion nuevoHorario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarHorarioAtencion_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Restaurante", nuevoHorario.ID_Restaurante);
                    cmd.Parameters.AddWithValue("@DiaSemana", nuevoHorario.DiaSemana);
                    cmd.Parameters.AddWithValue("@Habilitado", nuevoHorario.Habilitado);
                    cmd.Parameters.AddWithValue("@HoraApertura", nuevoHorario.HoraApertura);
                    cmd.Parameters.AddWithValue("@HoraCierre", nuevoHorario.HoraCierre);
                    cmd.Parameters.AddWithValue("@ValidoDesde", nuevoHorario.ValidoDesde);

                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
