using ABS;
using BE;
using DAL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BLL
{
    public class UsuarioBLL
    {
        private static readonly UsuarioBLL _instancia = new UsuarioBLL();
        private readonly UsuarioDal usuarioDal;
        private UsuarioBLL()
        {
            usuarioDal = new UsuarioDal();
        }
        public static UsuarioBLL GetInstance()
        {
            return _instancia;
        }
        public Usuario Login(string Nombre_Usuario, string ContraseñaLimpia)
        {
            if (string.IsNullOrEmpty(Nombre_Usuario) || string.IsNullOrEmpty(ContraseñaLimpia))
                throw new Exception("Debe ingresar un usuario y una contraseña correcta.");
            string ContraseñaHasheado =   Criptografia.HashearClave(ContraseñaLimpia);
            return usuarioDal.Login(Nombre_Usuario, ContraseñaHasheado);
        }
        public List<Usuario> ObtenerUsuarios()
        {
            return usuarioDal.ListarTodos();
        }
        //ABM ususarios
        public void CrearUsuario(string nombre, string contraseñaLimpia)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(contraseñaLimpia))       
                throw new Exception("El nombre y la contraseña son obligatorios.");
            
            Usuario nuevoUsuario = new Usuario();
            nuevoUsuario.Nombre_Usuario = nombre;
            // Hashea la clave antes de guardarla para que nunca esté en texto plano
            nuevoUsuario.Contraseña_Hash = Criptografia.HashearClave(contraseñaLimpia);
            nuevoUsuario.DVH = GestorDV.CalcularDVHUsuario(nuevoUsuario);

            usuarioDal.Alta(nuevoUsuario);

        }
        public void ModificarUsuario(long id, string nuevoNombre, string nuevaContraseñaLimpia)
        {
            if (id <= 0) throw new Exception("ID de usuario inválido.");
            if (string.IsNullOrWhiteSpace(nuevoNombre)) throw new Exception("El nombre no puede estar vacío.");

            if (id == ConfiguracionGlobal.ID_ADMIN_PRINCIPAL)
            {
                long idUsuarioLogueado = Singleton.GetInstance().GetIdUsuario();
                if (idUsuarioLogueado != ConfiguracionGlobal.ID_ADMIN_PRINCIPAL)
                {
                    throw new Exception("Acción denegada: Solo el administrador principal puede modificar su propia cuenta.");
                }
                if (!nuevoNombre.Equals(ConfiguracionGlobal.NOMBRE_ADMIN_PRINCIPAL, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Acción denegada: El nombre de usuario de la cuenta principal debe mantenerse como 'admin1'.");
                }
            }
            Usuario userModificado = new Usuario();
            userModificado.ID_Usuario = id;
            userModificado.Nombre_Usuario = nuevoNombre;

            // Si la contraseña llega vacía se deberia buscar la anterior en la bd para no sobreescribirla en blanco,para simplificar se exigue que se escriba de nuevo
            if (string.IsNullOrWhiteSpace(nuevaContraseñaLimpia))
                throw new Exception("Debe ingresar la nueva contraseña (o repetir la actual) para confirmar la modificación.");

            userModificado.Contraseña_Hash = Criptografia.HashearClave(nuevaContraseñaLimpia);
            userModificado.DVH = GestorDV.CalcularDVHUsuario(userModificado);

            usuarioDal.Modificar(userModificado);
        }
        public void EliminarUsuario(long id)
        {
            if (id <= 0) throw new Exception("Seleccione un usuario válido para eliminar.");

            if (id == ConfiguracionGlobal.ID_ADMIN_PRINCIPAL)
            {
                throw new Exception("Acción denegada: El administrador principal (admin1) no puede ser eliminado del sistema bajo ninguna circunstancia.");
            }
            long idUsuarioLogueado = Singleton.GetInstance().GetIdUsuario();
            //se evita que el usuario logueado se borre a sí mismo
            if (id == idUsuarioLogueado)
            {
                throw new Exception("Acción denegada: No puedes eliminar tu propia cuenta mientras tienes la sesión iniciada.");
            }

            usuarioDal.Baja(id);
        }
        //Actualizacion de idioma
        public void ActualizarIdiomaPreferido(long idUsuario, IIdioma nuevoIdioma)
        {
            if (nuevoIdioma != null && idUsuario > 0)
            {
                usuarioDal.ActualizarIdiomaUsuario(idUsuario, nuevoIdioma.ID_Idioma);
            }
        }

    }
}
