using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class IntegridadBLL
    {
        private static readonly IntegridadBLL _instancia = new IntegridadBLL();
        private UsuarioDal usuarioDal = new UsuarioDal();

        private IntegridadBLL() { }

        public static IntegridadBLL GetInstance()
        {
            return _instancia;
        }

        /// <summary>
        /// Verifica la integridad de la base de datos.
        /// Retorna un string vacío si todo está bien, o un mensaje detallado si hay error.
        /// </summary>
        public string VerificarIntegridad()
        {
            List<Usuario> usuariosBD = usuarioDal.ObtenerUsuariosParaValidacion();
            long dvvCalculadoAlVuelo = 0;
            foreach (Usuario user in usuariosBD)
            {
                long dvhReal = SERVICIOS.GestorDV.CalcularDVHUsuario(user);
                if (dvhReal != user.DVH)
                {
                    return $"ERROR DE INTEGRIDAD (DVH): El registro del usuario '{user.Nombre_Usuario}' (ID: {user.ID_Usuario}) ha sido modificado externamente o está corrupto.";
                }
                dvvCalculadoAlVuelo += dvhReal;
            }
            long dvvGuardado = usuarioDal.ObtenerDVV("Usuario");
            if (dvvCalculadoAlVuelo != dvvGuardado)
            {
                return $"ERROR DE INTEGRIDAD (DVV): La cantidad de registros en la tabla 'Usuario' no coincide con el control de seguridad. Se detectaron inserciones o eliminaciones externas.";
            }

            return ""; // Sin errores
        }
        public void RecalcularTodosLosDigitos()
        {
            List<Usuario> usuariosBD = usuarioDal.ObtenerUsuariosParaValidacion();
            foreach (Usuario user in usuariosBD)
            {
                long nuevoDVH = SERVICIOS.GestorDV.CalcularDVHUsuario(user);
                usuarioDal.ForzarRecalculoDVH(user.ID_Usuario, nuevoDVH);
            }
            usuarioDal.ActualizarDVVGlobal();
        }
    }
}