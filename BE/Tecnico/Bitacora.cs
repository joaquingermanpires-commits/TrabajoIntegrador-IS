using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Bitacora
    {
        public int ID_Bitacora { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
        public string Criticidad { get; set; }
        public string Modulo { get; set; }
        public string Mensaje { get; set; }
    }
}
