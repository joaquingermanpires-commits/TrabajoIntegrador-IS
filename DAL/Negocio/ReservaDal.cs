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
    public class ReservaDal
    {
        public int InsertarReserva_SP(Reserva r)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarReserva_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Usuario", r.ID_Usuario);
                    cmd.Parameters.AddWithValue("@ID_Restaurante", r.ID_Restaurante);
                    cmd.Parameters.AddWithValue("@FechaHoraSolicitada", r.FechaHoraSolicitada);
                    cmd.Parameters.AddWithValue("@CantidadComensales", r.CantidadComensales);
                    cmd.Parameters.AddWithValue("@Estado", r.Estado);

                    // Parámetro de salida para recuperar el ID generado
                    SqlParameter outputId = new SqlParameter("@NuevoID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return Convert.ToInt32(outputId.Value);
                }
            }
        }
        public bool ActualizarEstado_SP(Reserva r)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarEstadoReserva_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Reserva", r.ID_Reserva);
                    cmd.Parameters.AddWithValue("@Estado", r.Estado);
                    cmd.Parameters.AddWithValue("@ID_Mesa", (object)r.ID_Mesa ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaHoraCheckIn", (object)r.FechaHoraCheckIn ?? DBNull.Value);

                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public Reserva ObtenerReservaPorId_SP(int idReserva)
        {
            Reserva r = null;
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerReserva_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Reserva", idReserva);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            r = MapearLector(reader);
                        }
                    }
                }
            }
            return r;
        }
        public List<Reserva> ObtenerReservasExpiradas_SP()
        {
            List<Reserva> lista = new List<Reserva>();
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerReservasExpiradas_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapearLector(reader));
                        }
                    }
                }
            }
            return lista;
        }
        public bool VerificarCupo_SP(int idRestaurante, DateTime fecha, int comensales)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("VerificarCupo_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Restaurante", idRestaurante);
                    cmd.Parameters.AddWithValue("@FechaHora", fecha);
                    cmd.Parameters.AddWithValue("@CantidadComensales", comensales);

                    SqlParameter outputCupo = new SqlParameter("@HayCupo", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputCupo);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    return Convert.ToBoolean(outputCupo.Value);
                }
            }
        }
        public Transaccion ObtenerTransaccionAsociada_SP(int idReserva)
        {
            TransaccionDal transaccionDal = new TransaccionDal();
            Transaccion t = null;
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerTransaccionPorReserva_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Reserva", idReserva);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            t = new Transaccion
                            {
                                ID_Transaccion = Convert.ToInt32(reader["ID_Transaccion"]),
                                ID_Reserva = Convert.ToInt32(reader["ID_Reserva"]),
                                Monto = Convert.ToDecimal(reader["Monto"]),
                                EstadoPago = reader["EstadoPago"].ToString(),
                                FechaTransaccion = Convert.ToDateTime(reader["FechaTransaccion"]),
                                TokenTarjeta = reader["TokenTarjeta"].ToString()
                            };
                        }
                    }
                }
            }
            return t;
        }
        private Reserva MapearLector(SqlDataReader reader)
        {
            return new Reserva
            {
                ID_Reserva = Convert.ToInt32(reader["ID_Reserva"]),
                ID_Usuario = Convert.ToInt64(reader["ID_Usuario"]),
                ID_Restaurante = Convert.ToInt32(reader["ID_Restaurante"]),
                ID_Mesa = reader["ID_Mesa"] != DBNull.Value ? (int?)Convert.ToInt32(reader["ID_Mesa"]) : null,
                FechaHoraSolicitada = Convert.ToDateTime(reader["FechaHoraSolicitada"]),
                CantidadComensales = Convert.ToInt32(reader["CantidadComensales"]),
                Estado = reader["Estado"].ToString(),
                FechaHoraCheckIn = reader["FechaHoraCheckIn"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["FechaHoraCheckIn"]) : null
            };
        }
        public DateTime ObtenerFechaUltimaReservaPorDia(int idRestaurante, int diaSemana)
        {
            DateTime ultimaFecha = DateTime.Today;
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerUltimaReservaPorDia_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Restaurante", idRestaurante);
                    cmd.Parameters.AddWithValue("@DiaSemana", diaSemana);

                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        ultimaFecha = Convert.ToDateTime(result).AddDays(1);
                    }
                }
            }
            return ultimaFecha;
        }
    }
}
