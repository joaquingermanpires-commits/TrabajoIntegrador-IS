using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABS
{
    public interface IUsuario
    {
        long ID_Usuario { get;set; } 
        string Nombre_Usuario { get;set;}
        string Contraseña_Hash { get; set; }

    }
}
