using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Reserva
    {
        public int ID_Reserva { get; set; }
        public long ID_Usuario { get; set; } // El Comensal
        public int ID_Restaurante { get; set; }
        public int? ID_Mesa { get; set; }

        public DateTime FechaHoraSolicitada { get; set; }
        public int CantidadComensales { get; set; }
        public string Estado { get; set; } // Pendiente, Confirmada, Cancelada, CheckIn, NoShow
        public DateTime? FechaHoraCheckIn { get; set; }

        public Transaccion SeguroFinanciero { get; set; }

        public Reserva()
        {
            this.Estado = "Pendiente";
        }
        public void ConfirmarReserva()
        {
            this.Estado = "Confirmada";
        }
        public void RegistrarCheckInReal(DateTime horaLlegada, int idMesaAsignada)
        {
            this.Estado = "CheckIn";
            this.FechaHoraCheckIn = horaLlegada;
            this.ID_Mesa = idMesaAsignada;
        }
        public void MarcarComoNoShow()
        {
            this.Estado = "NoShow";
        }
        public void CancelarReserva()
        {
            this.Estado = "Cancelada";
        }
    }
}
