using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using SERVICIOS;



namespace BLL
{
    public class UsuarioBLL
    {
        private readonly UsuarioDal usuarioDal;

        public UsuarioBLL() 
        {
        usuarioDal = new UsuarioDal();
        }
        public Usuario Login(string Nombre_Usuario, string ContraseñaLimpia)
        {
            if (string.IsNullOrEmpty(Nombre_Usuario) || string.IsNullOrEmpty(ContraseñaLimpia))
                throw new Exception("Debe ingresar un usuario y una contraseña correcta.");

            // Hasheamos la clave pre-mandarla a la bd
            string ContraseñaHasheado =   Criptografia.HashearClave(ContraseñaLimpia);

            // Le mandamos a la DAL el hash, para que compare Hash contra Hash en la bd

            return usuarioDal.Login(Nombre_Usuario, ContraseñaHasheado);
        }
        public void RegistrarUsuario(Usuario nuevoUsuario, string ContraseñaLimpia)
        {
            // Hashea la clave antes de guardarla para que nunca esté en texto plano
            nuevoUsuario.Contraseña_Hash = Criptografia.HashearClave(ContraseñaLimpia);

            // usuarioDal.Registrar(nuevoUsuario);
        }
    }
}
