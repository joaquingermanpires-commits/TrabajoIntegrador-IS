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
        public void CargarPermisosUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                usuario.Permisos = permisoDal.ObtenerPermisosDeUsuario(usuario.ID_Usuario);
            }
        }
        public bool VerificarPermiso(Usuario usuario, string permisoSistema)
        {
            if (usuario == null || usuario.Permisos == null) return false;

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
            if (permisoPadre.Permiso_Sistema == permisoSistema)
            {
                return true;
            }
            foreach (var hijo in permisoPadre.ObtenerHijos())
            {
                if (BuscarPermisoRecursivo(hijo, permisoSistema))
                {
                    return true;
                }
            }

            return false;
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
    }
}