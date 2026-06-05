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

            // 1. Verificación Horizontal (DVH)
            foreach (Usuario user in usuariosBD)
            {
                // Le pedimos a nuestro motor que recalcule el código con los datos actuales
                long dvhReal = SERVICIOS.GestorDV.CalcularDVHUsuario(user);

                // Si el código matemático no coincide con el que está guardado, alguien modificó el registro por atrás
                if (dvhReal != user.DVH)
                {
                    return $"ERROR DE INTEGRIDAD (DVH): El registro del usuario '{user.Nombre_Usuario}' (ID: {user.ID_Usuario}) ha sido modificado externamente o está corrupto.";
                }

                // Vamos sumando para el vertical
                dvvCalculadoAlVuelo += dvhReal;
            }

            // 2. Verificación Vertical (DVV)
            long dvvGuardado = usuarioDal.ObtenerDVV("Usuario");

            // Si los DVH estaban bien, pero la suma total no coincide, alguien insertó o borró un usuario por atrás (Ej: DROP ROW)
            if (dvvCalculadoAlVuelo != dvvGuardado)
            {
                return $"ERROR DE INTEGRIDAD (DVV): La cantidad de registros en la tabla 'Usuario' no coincide con el control de seguridad. Se detectaron inserciones o eliminaciones externas.";
            }

            return ""; // Sin errores
        }
        public void RecalcularTodosLosDigitos()
        {
            // 1. Traemos todos los usuarios de la base
            List<Usuario> usuariosBD = usuarioDal.ObtenerUsuariosParaValidacion();

            // 2. Recalculamos matemáticamente y actualizamos uno por uno
            foreach (Usuario user in usuariosBD)
            {
                long nuevoDVH = SERVICIOS.GestorDV.CalcularDVHUsuario(user);
                usuarioDal.ForzarRecalculoDVH(user.ID_Usuario, nuevoDVH);
            }

            // 3. Finalmente, actualizamos el Digito Verificador Vertical
            usuarioDal.ActualizarDVVGlobal();
        }
    }
}