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
        public Idioma IdiomaPreferido { get; set; }
        public List<Permiso> Permisos { get; set; }
        public long DVH { get; set; }
        public Usuario()
        {
            Permisos = new List<Permiso>();
        }

    }
}
