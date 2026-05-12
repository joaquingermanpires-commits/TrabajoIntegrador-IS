using ABS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Idioma : IIdioma
    {
        public int ID_Idioma { get; set; }
        public string Nombre { get; set; }
        public bool PorDefecto { get; set; }
    }
}
