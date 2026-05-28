using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class BitacoraBLL
    {
        // Implementación del patrón Singleton
        private static readonly BitacoraBLL _instancia = new BitacoraBLL();
        private BitacoraDal bitacoraDal = new BitacoraDal();
        private BitacoraBLL() { }
        public static BitacoraBLL GetInstance()
        {
            return _instancia;
        }
        public void RegistrarBitacora(string usuario, string criticidad, string modulo, string mensaje)
        {
            Bitacora b = new Bitacora
            {
                // Si por algún motivo no hay usuario logueado (ej: error al iniciar), ponemos SISTEMA
                Usuario = string.IsNullOrWhiteSpace(usuario) ? "SISTEMA" : usuario,
                Criticidad = criticidad,
                Modulo = modulo,
                Mensaje = mensaje
            };

            bitacoraDal.Registrar(b);
        }
        public List<Bitacora> ConsultarBitacora()
        {
            return bitacoraDal.Consultar();
        }
    }
}