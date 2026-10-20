using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class RestauranteDal
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;
        public bool InsertarRestaurante_SP(Restaurante restaurante)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarRestaurante_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Usuario", restaurante.ID_Usuario);
                    cmd.Parameters.AddWithValue("@Nombre", restaurante.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", restaurante.Direccion);
                    cmd.Parameters.AddWithValue("@TiempoMinimo", restaurante.TiempoMinimoPermitido);
                    cmd.Parameters.AddWithValue("@TiempoMaximo", restaurante.TiempoMaximoPermitido);
                    cmd.Parameters.AddWithValue("@OcupacionMax", restaurante.PorcentajeMaximoOcupacion);
                    cmd.Parameters.AddWithValue("@Telefono", (object)restaurante.Telefono ?? DBNull.Value);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ActualizarConfiguracion_SP(Restaurante restaurante)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarConfiguracionRestaurante_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Restaurante", restaurante.ID_Restaurante);
                    cmd.Parameters.AddWithValue("@TiempoMinimo", restaurante.TiempoMinimoPermitido);
                    cmd.Parameters.AddWithValue("@TiempoMaximo", restaurante.TiempoMaximoPermitido);
                    cmd.Parameters.AddWithValue("@OcupacionMax", restaurante.PorcentajeMaximoOcupacion);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public Restaurante ObtenerRestaurantePorId_SP(int idRestaurante)
        {
            Restaurante r = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerRestaurante_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Restaurante", idRestaurante);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            r = new Restaurante
                            {
                                ID_Restaurante = Convert.ToInt32(reader["ID_Restaurante"]),
                                ID_Usuario = Convert.ToInt64(reader["ID_Usuario"]),
                                Nombre = reader["Nombre"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                TiempoMinimoPermitido = Convert.ToInt32(reader["TiempoMinimoPermitido"]),
                                TiempoMaximoPermitido = Convert.ToInt32(reader["TiempoMaximoPermitido"]),
                                PorcentajeMaximoOcupacion = Convert.ToDecimal(reader["PorcentajeMaximoOcupacion"])
                            };
                        }
                    }
                }
            }
            return r;
        }

        public bool ActualizarReglasRestaurante(Restaurante restaurante)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarReglasRestaurante_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Restaurante", restaurante.ID_Restaurante);
                    cmd.Parameters.AddWithValue("@TiempoMinimoPermitido", restaurante.TiempoMinimoPermitido);
                    cmd.Parameters.AddWithValue("@TiempoMaximoPermitido", restaurante.TiempoMaximoPermitido);
                    cmd.Parameters.AddWithValue("@PorcentajeMaximoOcupacion", restaurante.PorcentajeMaximoOcupacion);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public IList<Restaurante> BuscarRestaurantesDisponibles(DateTime fechaHora, int comensales)
        {
            IList<Restaurante> lista = new List<Restaurante>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("BuscarRestaurantesDisponibles_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaHora", fechaHora);
                    cmd.Parameters.AddWithValue("@CantidadComensales", comensales);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Restaurante
                            {
                                ID_Restaurante = Convert.ToInt32(reader["ID_Restaurante"]),
                                ID_Usuario = Convert.ToInt64(reader["ID_Usuario"]),
                                Nombre = reader["Nombre"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                TiempoMinimoPermitido = Convert.ToInt32(reader["TiempoMinimoPermitido"]),
                                TiempoMaximoPermitido = Convert.ToInt32(reader["TiempoMaximoPermitido"]),
                                PorcentajeMaximoOcupacion = Convert.ToDecimal(reader["PorcentajeMaximoOcupacion"])
                            });
                        }
                    }
                }
            }
            return lista;
        }
        public IList<Restaurante> ObtenerTodos()
        {
            IList<Restaurante> lista = new List<Restaurante>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerTodosRestaurantes_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Restaurante
                            {
                                ID_Restaurante = Convert.ToInt32(reader["ID_Restaurante"]),
                                ID_Usuario = Convert.ToInt64(reader["ID_Usuario"]),
                                Nombre = reader["Nombre"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                Telefono = reader["Telefono"] != DBNull.Value ? reader["Telefono"].ToString() : "",
                                TiempoMinimoPermitido = Convert.ToInt32(reader["TiempoMinimoPermitido"]),
                                TiempoMaximoPermitido = Convert.ToInt32(reader["TiempoMaximoPermitido"]),
                                PorcentajeMaximoOcupacion = Convert.ToDecimal(reader["PorcentajeMaximoOcupacion"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public bool ActualizarRestauranteCompleto_SP(Restaurante restaurante)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarRestauranteCompleto_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Restaurante", restaurante.ID_Restaurante);
                    cmd.Parameters.AddWithValue("@ID_Usuario", restaurante.ID_Usuario);
                    cmd.Parameters.AddWithValue("@Nombre", restaurante.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", restaurante.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", (object)restaurante.Telefono ?? DBNull.Value);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool EliminarRestaurante_SP(int idRestaurante)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarRestaurante_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Restaurante", idRestaurante);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public Restaurante ObtenerRestaurantePorUsuario(long idUsuario)
        {
            Restaurante r = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerRestaurantePorUsuario_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Usuario", idUsuario);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            r = new Restaurante
                            {
                                ID_Restaurante = Convert.ToInt32(reader["ID_Restaurante"]),
                                ID_Usuario = Convert.ToInt64(reader["ID_Usuario"]),
                                Nombre = reader["Nombre"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                Telefono = reader["Telefono"] != DBNull.Value ? reader["Telefono"].ToString() : "",
                                TiempoMinimoPermitido = Convert.ToInt32(reader["TiempoMinimoPermitido"]),
                                TiempoMaximoPermitido = Convert.ToInt32(reader["TiempoMaximoPermitido"]),
                                PorcentajeMaximoOcupacion = Convert.ToDecimal(reader["PorcentajeMaximoOcupacion"])
                            };
                        }
                    }
                }
            }
            return r;
        }
    }
}