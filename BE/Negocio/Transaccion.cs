using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BE.Reserva;

namespace BE
{
    public class Transaccion
    {
        public int ID_Transaccion { get; set; }
        public int ID_Reserva { get; set; }
        public decimal Monto { get; set; }
        public enum EstadoPago { PreAutorizado, Liberado, Capturado }
        public EstadoPago Pago { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string TokenTarjeta { get; set; }
        public void LiberarFondos()
        {
            this.Pago = EstadoPago.Liberado;
        }

        public void CapturarPenalidad()
        {
            this.Pago = EstadoPago.Capturado;
        }
    }
}
