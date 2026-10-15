using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Evento
    {
        public int ID_Evento { get; set; }
        public int ID_Restaurante { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public decimal PorcentajeDescuento { get; set; }

        public bool EsVigente(DateTime fechaActual)
        {
            return fechaActual >= FechaHoraInicio && fechaActual <= FechaHoraFin;
        }
    }
}
