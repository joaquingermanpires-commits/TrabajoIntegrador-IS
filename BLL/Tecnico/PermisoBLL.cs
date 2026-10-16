using ABS;
using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class PermisoBLL
    {
        private static readonly PermisoBLL _instancia = new PermisoBLL();
        private PermisoDal permisoDal = new PermisoDal();
        private PermisoBLL() { }
        public static PermisoBLL GetInstance()
        {
            return _instancia;
        }
        //Lectura de Permisos
        public List<Patente> ObtenerTodasLasPatentes()
        {
            return permisoDal.ObtenerTodasLasPatentes();
        }
        public List<Familia> ObtenerFamiliasCompletas()
        {
            List<Familia> familias = permisoDal.ObtenerFamilias();
            foreach (Familia familia in familias)
            {
                permisoDal.LlenarFamiliaRecursivo(familia);
            }
            return familias;
        }
        public bool VerificarPermiso(Usuario usuario, string permisoSistema)
        {
            // Si el usuario no tiene permisos cargados en memoria, denegamos el acceso directamente
            if (usuario == null || usuario.Permisos == null || usuario.Permisos.Count == 0) return false;

            foreach (var permiso in usuario.Permisos)
            {
                if (BuscarPermisoRecursivo(permiso, permisoSistema))
                {
                    return true;
                }
            }
            return false;
        }
        private bool BuscarPermisoRecursivo(Permiso permisoPadre, string permisoSistema)
        {
            // Chequeo robusto: Evitamos NullReference si es Familia, limpiamos espacios y comparamos en mayúsculas
            if (!string.IsNullOrWhiteSpace(permisoPadre.Permiso_Sistema) &&
                permisoPadre.Permiso_Sistema.Trim().ToUpper() == permisoSistema.Trim().ToUpper())
            {
                return true;
            }

            // Iteramos los hijos recursivamente
            foreach (var hijo in permisoPadre.ObtenerHijos())
            {
                if (BuscarPermisoRecursivo(hijo, permisoSistema))
                {
                    return true;
                }
            }

            return false;
        }
        //Permisos de usuario
        public void CargarPermisosUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                usuario.Permisos = permisoDal.ObtenerPermisosDeUsuario(usuario.ID_Usuario);
            }
        }
        public void GuardarPermisosUsuario(Usuario usuario)
        {
            if (usuario == null || usuario.ID_Usuario <= 0)
            {
                throw new Exception("Debe seleccionar un usuario válido para asignarle permisos.");
            }
            if (usuario.ID_Usuario == 1 || usuario.Nombre_Usuario.ToLower() == "admin1")
            {
                throw new Exception("Acción denegada por reglas de seguridad: Los permisos del administrador principal del sistema son inmutables y no pueden ser modificados.");
            }

            permisoDal.GuardarPermisosUsuario(usuario);
        }
        //Creacion de permisos(Compuestos)
        public void GuardarNuevaFamilia(Familia familiaNueva)
        {
            // Reglas de negocio
            if (familiaNueva == null)
                throw new Exception("La familia no puede ser nula.");

            if (string.IsNullOrWhiteSpace(familiaNueva.Nombre))
                throw new Exception("Debe ingresar un nombre para la nueva familia.");

            if (familiaNueva.ObtenerHijos().Count == 0)
                throw new Exception("La familia debe tener al menos un permiso o patente asignada en el carrito.");

            // Mandamos a la DAL
            permisoDal.GuardarNuevaFamilia(familiaNueva);
        }
        public void EliminarFamilia(Familia familia)
        {
            if (familia == null) throw new Exception("Debe seleccionar una familia para eliminar.");

            // REGLA DE NEGOCIO CRÍTICA
            if (familia.Nombre.ToUpper() == "ADMINISTRADOR GENERAL")
            {
                throw new Exception("Acción denegada: No se puede eliminar la familia base del sistema.");
            }

            permisoDal.EliminarFamiliaSegura(familia.ID_Permiso);
        }
    }
}