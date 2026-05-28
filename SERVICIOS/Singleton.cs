using BE;
using ABS;
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
        private static readonly Singleton _sesion = new Singleton();
        private List<IObserver> observadores = new List<IObserver>();

        private Singleton()
        {
        }
        //Observer
        public void Suscribir(IObserver obs)
        {
            if (!observadores.Contains(obs))
                observadores.Add(obs);
        }
        public void Desuscribir(IObserver obs)
        {
            observadores.Remove(obs);
        }
        private void Notificar()
        {
            // Le avisamos a todos los formularios suscritos que algo cambió
            foreach (var obs in observadores)
            {
                obs.ActualizarEstadoSesion();
            }
        }
        //Sesion
        public static Singleton GetInstance()
        {
            return _sesion;
        }
        public void IniciarSesion(Usuario usuario)
        {
            if (this.Usuario != null)
                throw new Exception("Ya existe una sesión activa. Debe cerrar sesión primero.");

            this.Usuario = usuario;
            Notificar();
        }
        public void CerrarSesion()
        {
            this.Usuario = null;
            Notificar();
        }
        public string GetUsuario()
        {
            //return Usuario.Nombre_Usuario;
            return Usuario != null ? Usuario.Nombre_Usuario : null;
        }
        public long GetIdUsuario()
        {
            if (Usuario != null)
            {
                return Usuario.ID_Usuario;
            }
            else
            {
                return 0;
            }
            //return Usuario != null ? Usuario.ID_Usuario : 0;
        }
    }
}