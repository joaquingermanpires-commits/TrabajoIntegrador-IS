using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MesaDal
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
        public bool InsertarMesa_SP(Mesa mesa)
        {
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
                    cmd.Parameters.AddWithValue("@EsVertical", mesa.EsVertical);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool ActualizarMesa(Mesa mesa)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarMesa_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_Mesa", mesa.ID_Mesa);
                    cmd.Parameters.AddWithValue("@CodigoUbicacion", mesa.CodigoUbicacion);
                    cmd.Parameters.AddWithValue("@CapacidadPersonas", mesa.CapacidadPersonas);
                    cmd.Parameters.AddWithValue("@PosicionX", mesa.PosicionX);
                    cmd.Parameters.AddWithValue("@PosicionY", mesa.PosicionY);
                    cmd.Parameters.AddWithValue("@Habilitada", mesa.Habilitada);
                    cmd.Parameters.AddWithValue("@EsVertical", mesa.EsVertical);

                    con.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
        public bool EliminarMesa_SP(int idMesa)
        {
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
        public IList<Mesa> ObtenerMesasPorRestaurante_SP(int idRestaurante)
        {
            IList<Mesa> lista = new List<Mesa>();
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
                            lista.Add(MapearLector(reader));
                        }
                    }
                }
            }
            return lista;
        }
        public IList<Mesa> ObtenerMesasDisponibles(int idRestaurante, DateTime fechaHoraSolicitada, int comensales, int minutosEstadia)
        {
            IList<Mesa> lista = new List<Mesa>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
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
                            lista.Add(MapearLector(reader));
                        }
                    }
                }
            }
            return lista;
        }
        private Mesa MapearLector(SqlDataReader reader)
        {
            return new Mesa
            {
                ID_Mesa = Convert.ToInt32(reader["ID_Mesa"]),
                ID_Restaurante = Convert.ToInt32(reader["ID_Restaurante"]),
                CapacidadPersonas = Convert.ToInt32(reader["CapacidadPersonas"]),
                CodigoUbicacion = reader["CodigoUbicacion"].ToString(),
                Habilitada = Convert.ToBoolean(reader["Habilitada"]),
                PosicionX = Convert.ToInt32(reader["PosicionX"]),
                PosicionY = Convert.ToInt32(reader["PosicionY"]),
                EsVertical = Convert.ToBoolean(reader["EsVertical"])
            };
        }
        public int ContarReservasPendientes(int idMesa)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("VerificarReservasPendientes_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Mesa", idMesa);
                    con.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}