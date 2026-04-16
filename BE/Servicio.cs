using ABS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Servicio : IServicio
    {
        public long ID_Servicio { get; set; }
        public string Nombre_Servicio { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
        public string Desc { get; set; }
    }
}
