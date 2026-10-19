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
    public class PreferenciaDal
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["IS"].ConnectionString;

        public IList<PreferenciaDietetica> ObtenerPreferenciasPorRestaurante(int idRestaurante)
        {
            IList<PreferenciaDietetica> lista = new List<PreferenciaDietetica>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerPreferenciasPorRestaurante_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Restaurante", idRestaurante);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PreferenciaDietetica
                            {
                                ID_Preferencia = Convert.ToInt32(reader["ID_Preferencia"]),
                                Descripcion = reader["Descripcion"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }
        public IList<PreferenciaDietetica> ObtenerTodas()
        {
            IList<PreferenciaDietetica> lista = new List<PreferenciaDietetica>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerTodasPreferencias_SP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PreferenciaDietetica
                            {
                                ID_Preferencia = Convert.ToInt32(reader["ID_Preferencia"]),
                                Descripcion = reader["Descripcion"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public bool ActualizarPreferenciasRestaurante(int idRestaurante, List<int> idsSeleccionados)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlTransaction trans = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmdDel = new SqlCommand("EliminarPreferenciasRestaurante_SP", con, trans))
                        {
                            cmdDel.CommandType = CommandType.StoredProcedure;
                            cmdDel.Parameters.AddWithValue("@ID_Restaurante", idRestaurante);
                            cmdDel.ExecuteNonQuery();
                        }
                        foreach (int idPref in idsSeleccionados)
                        {
                            using (SqlCommand cmdIns = new SqlCommand("AsignarPreferenciaRestaurante_SP", con, trans))
                            {
                                cmdIns.CommandType = CommandType.StoredProcedure;
                                cmdIns.Parameters.AddWithValue("@ID_Restaurante", idRestaurante);
                                cmdIns.Parameters.AddWithValue("@ID_Preferencia", idPref);
                                cmdIns.ExecuteNonQuery();
                            }
                        }
                        trans.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw new Exception("Error al guardar las preferencias. Se han restaurado los datos originales.");
                    }
                }
            }
        }
    }
}