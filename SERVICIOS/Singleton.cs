using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class Singleton
    {
        private Usuario Usuario { get; set; }
        private static Singleton sesion;

        private Singleton()
        {

        }

        public static Singleton GetInstance()
        {
            if (sesion == null)
            {
                sesion = new Singleton();
            }
            return sesion;
        }

        public void IniciarSesion(Usuario usuario)
        {
            if (this.Usuario != null)
                throw new Exception("Ya existe una sesión activa. Debe cerrar sesión primero.");

            this.Usuario = usuario;
        }

        public void CerrarSesion()
        {
            Usuario = null;
        }

        public string GetUsuario()
        {
            return Usuario.Nombre_Usuario;
        }
        public long GetIdUsuario()
        {
            if (Usuario != null)
            {
                return Usuario.ID_Usuario;
            }
            else { 
            return 0;
            }
        }
    }
}