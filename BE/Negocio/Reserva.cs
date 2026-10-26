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
        public string CodigoAcceso { get; set; }
        public DateTime FechaHoraSolicitada { get; set; }
        public int CantidadComensales { get; set; }
        public int DuracionMinutos { get; set; }
        public EstadoReserva Estado { get;  set; }
        public enum EstadoReserva { Pendiente, Confirmada, Cancelada, CheckIn, NoShow }
        public DateTime? FechaHoraCheckIn { get; set; }
        public Transaccion SeguroFinanciero { get; set; }
        public string RestauranteNombre { get; set; }
        public Reserva()
        {
            this.Estado = EstadoReserva.Pendiente;
        }
        public void ConfirmarReserva()
        {
            this.Estado = EstadoReserva.Confirmada;
        }
        public void MarcarComoNoShow()
        {
            this.Estado = EstadoReserva.NoShow;
        }
        public void CancelarReserva()
        {
            this.Estado = EstadoReserva.Cancelada;
        }
        public void RegistrarCheckInReal(DateTime horaLlegada, int idMesaAsignada)
        {
            this.Estado = EstadoReserva.CheckIn;
            this.FechaHoraCheckIn = horaLlegada;
            this.ID_Mesa = idMesaAsignada;
        }
    }
}
