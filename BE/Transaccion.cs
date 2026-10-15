using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Transaccion
    {
        public int ID_Transaccion { get; set; }
        public int ID_Reserva { get; set; }
        public decimal Monto { get; set; }
        public string EstadoPago { get; set; } // PreAutorizado, Liberado, Capturado
        public DateTime FechaTransaccion { get; set; }
        public string TokenTarjeta { get; set; }
        public void LiberarFondos()
        {
            this.EstadoPago = "Liberado";
        }

        public void CapturarPenalidad()
        {
            this.EstadoPago = "Capturado";
        }
    }
}
