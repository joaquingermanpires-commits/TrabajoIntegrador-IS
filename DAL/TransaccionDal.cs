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
    public class TransaccionDal
    {

        public bool InsertarTransaccion_SP(Transaccion t)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarTransaccion_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Reserva", t.ID_Reserva);
                    cmd.Parameters.AddWithValue("@Monto", t.Monto);
                    cmd.Parameters.AddWithValue("@EstadoPago", t.EstadoPago);
                    cmd.Parameters.AddWithValue("@FechaTransaccion", t.FechaTransaccion);
                    cmd.Parameters.AddWithValue("@TokenTarjeta", t.TokenTarjeta);

                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ActualizarEstadoTransaccion_SP(Transaccion t)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarEstadoTransaccion_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Transaccion", t.ID_Transaccion);
                    cmd.Parameters.AddWithValue("@EstadoPago", t.EstadoPago);

                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public Transaccion ObtenerTransaccion_SP(int idTransaccion)
        {
            Transaccion t = null;
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerTransaccion_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Transaccion", idTransaccion);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            t = MapearLector(reader);
                        }
                    }
                }
            }
            return t;
        }

        private Transaccion MapearLector(SqlDataReader reader)
        {
            return new Transaccion
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
