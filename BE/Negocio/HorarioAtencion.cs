using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Negocio
{
    public class HorarioAtencion
    {
        public int ID_Horario { get; set; }
        public int ID_Restaurante { get; set; }
        public int DiaSemana { get; set; } //0=domingo, 1=lunes, etc.
        public bool Habilitado { get; set; }
        public TimeSpan HoraApertura { get; set; }
        public TimeSpan HoraCierre { get; set; }
        public DateTime ValidoDesde { get; set; }
        public DateTime? ValidoHasta { get; set; }
    }
}
