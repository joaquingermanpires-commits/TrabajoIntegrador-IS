using ABS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Turno : ITurno
    {
        public long Id_Turno { get; set; }
        public DateTime fecha { get; set; }
        public String Estado { get; set; }
        public int ID_Cliente { get; set; }
        public int ID_Servicio { get; set; }

    }
}
