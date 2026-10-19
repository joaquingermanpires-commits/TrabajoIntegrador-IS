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
    public class MesaDal
    {

        public bool InsertarMesa_SP(Mesa mesa)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarMesa_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Restaurante", mesa.ID_Restaurante);
                    cmd.Parameters.AddWithValue("@Capacidad", mesa.CapacidadPersonas);
                    cmd.Parameters.AddWithValue("@Codigo", mesa.CodigoUbicacion);
                    cmd.Parameters.AddWithValue("@Habilitada", mesa.Habilitada);
                    cmd.Parameters.AddWithValue("@PosicionX", mesa.PosicionX);
                    cmd.Parameters.AddWithValue("@PosicionY", mesa.PosicionY);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ActualizarMesa_SP(Mesa mesa)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarMesa_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Mesa", mesa.ID_Mesa);
                    cmd.Parameters.AddWithValue("@Capacidad", mesa.CapacidadPersonas);
                    cmd.Parameters.AddWithValue("@Codigo", mesa.CodigoUbicacion);
                    cmd.Parameters.AddWithValue("@Habilitada", mesa.Habilitada);
                    cmd.Parameters.AddWithValue("@PosicionX", mesa.PosicionX);
                    cmd.Parameters.AddWithValue("@PosicionY", mesa.PosicionY);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool EliminarMesa_SP(int idMesa)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarMesa_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Mesa", idMesa);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Mesa> ObtenerMesasPorRestaurante_SP(int idRestaurante)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            List<Mesa> lista = new List<Mesa>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerMesas_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Restaurante", idRestaurante);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Mesa
                            {
                                ID_Mesa = Convert.ToInt32(reader["ID_Mesa"]),
                                ID_Restaurante = Convert.ToInt32(reader["ID_Restaurante"]),
                                CapacidadPersonas = Convert.ToInt32(reader["CapacidadPersonas"]),
                                CodigoUbicacion = reader["CodigoUbicacion"].ToString(),
                                Habilitada = Convert.ToBoolean(reader["Habilitada"]),
                                PosicionX = Convert.ToInt32(reader["PosicionX"]),
                                PosicionY = Convert.ToInt32(reader["PosicionY"])
                            });
                        }
                    }
                }
            }
            return lista;
        }
        public List<Mesa> ObtenerMesasDisponibles(int idRestaurante, DateTime fechaHoraSolicitada, int comensales, int minutosEstadia)
        {
            List<Mesa> lista = new List<Mesa>();
            string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Este es el Stored Procedure que haremos juntos más adelante
                using (SqlCommand cmd = new SqlCommand("ObtenerMesasDisponibles_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Restaurante", idRestaurante);
                    cmd.Parameters.AddWithValue("@FechaHoraSolicitada", fechaHoraSolicitada);
                    cmd.Parameters.AddWithValue("@CantidadComensales", comensales);
                    cmd.Parameters.AddWithValue("@MinutosEstadia", minutosEstadia);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Mesa
                            {
                                ID_Mesa = Convert.ToInt32(reader["ID_Mesa"]),
                                ID_Restaurante = Convert.ToInt32(reader["ID_Restaurante"]),
                                CapacidadPersonas = Convert.ToInt32(reader["CapacidadPersonas"]),
                                CodigoUbicacion = reader["CodigoUbicacion"].ToString(),

                                // Este booleano vendrá pre-calculado desde el SP de SQL
                                Habilitada = Convert.ToBoolean(reader["Habilitada"]),

                                PosicionX = Convert.ToInt32(reader["PosicionX"]),
                                PosicionY = Convert.ToInt32(reader["PosicionY"])
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}
