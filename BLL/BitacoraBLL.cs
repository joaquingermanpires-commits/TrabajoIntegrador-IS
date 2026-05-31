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
        public List<Bitacora> ConsultarBitacoraFiltrada(DateTime? fechaDesde, DateTime? fechaHasta, string criticidad, string usuario)
        {
            // Acá podés agregar validaciones a futuro (ej: que FechaDesde no sea mayor a FechaHasta)
            if (fechaDesde.HasValue && fechaHasta.HasValue && fechaDesde > fechaHasta)
            {
                throw new Exception("La fecha de inicio no puede ser mayor a la fecha de fin.");
            }

            return bitacoraDal.ConsultarConFiltros(fechaDesde, fechaHasta, criticidad, usuario);
        }
    }
}