using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABS
{
    public interface IIdioma
    {
        int ID_Idioma { get; set; }
        string Nombre { get; set; }
        bool PorDefecto { get; set; }
    }
}
