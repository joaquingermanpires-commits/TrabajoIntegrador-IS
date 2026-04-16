using ABS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario : IUsuario
    {
        public long ID_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Contraseña_Hash { get; set; }
    }
}
