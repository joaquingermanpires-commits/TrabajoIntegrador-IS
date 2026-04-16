using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABS
{
    public interface IServicio
    {
        long ID_Servicio { get; set; }
        string Nombre_Servicio { get; set; }
        decimal Precio {  get; set; }
        string Categoria { get; set; }
        string Desc { get; set; }
    
    }
}
