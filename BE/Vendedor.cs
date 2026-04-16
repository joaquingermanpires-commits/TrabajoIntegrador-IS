using ABS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    internal class Vendedor : Usuario
    {
        public string Nombre_Local {  get; set; }
        public string Ubicacion { get; set; }
    }
}
