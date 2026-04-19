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

        public void CrearUsuario(string nombre, string contraseñaLimpia)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(contraseñaLimpia))
                throw new Exception("El nombre y la contraseña son obligatorios.");

            Usuario nuevoUsuario = new Usuario();
            nuevoUsuario.Nombre_Usuario = nombre;
            // Hashea la clave antes de guardarla para que nunca esté en texto plano
            nuevoUsuario.Contraseña_Hash = Criptografia.HashearClave(contraseñaLimpia);

            usuarioDal.Alta(nuevoUsuario);
        }

        public void ModificarUsuario(long id, string nuevoNombre, string nuevaContraseñaLimpia)
        {
            if (id <= 0) throw new Exception("ID de usuario inválido.");
            if (string.IsNullOrWhiteSpace(nuevoNombre)) throw new Exception("El nombre no puede estar vacío.");

            Usuario userModificado = new Usuario();
            userModificado.ID_Usuario = id;
            userModificado.Nombre_Usuario = nuevoNombre;

            // Si la contraseña llega vacía se deberia buscar la anterior en la bd para no sobreescribirla en blanco,para simplificar se exigue que se escriba de nuevo
            if (string.IsNullOrWhiteSpace(nuevaContraseñaLimpia))
                throw new Exception("Debe ingresar la nueva contraseña (o repetir la actual) para confirmar la modificación.");

            userModificado.Contraseña_Hash = Criptografia.HashearClave(nuevaContraseñaLimpia);

            usuarioDal.Modificar(userModificado);
        }

        public void EliminarUsuario(long id)
        {
            if (id <= 0) throw new Exception("Seleccione un usuario válido para eliminar.");

            long idUsuarioLogueado = SERVICIOS.Singleton.GetInstance().GetIdUsuario();
            //se evita que el usuario logueado se borre a sí mismo
            if (id == idUsuarioLogueado)
            {
                throw new Exception("Acción denegada: No puedes eliminar tu propia cuenta mientras tienes la sesión iniciada.");
            }

            usuarioDal.Baja(id);
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return usuarioDal.ListarTodos();
        }
    }
}
