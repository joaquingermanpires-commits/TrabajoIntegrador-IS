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
    }
}
