using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EventoBLL
    {
        private EventoDal dalEvento = new EventoDal();

        public bool AltaEventoPromocional(Evento evento)
        {
            if (evento.FechaHoraFin <= evento.FechaHoraInicio)
                throw new Exception("La fecha de finalización debe ser posterior a la fecha de inicio del evento.");

            if (evento.PorcentajeDescuento < 0 || evento.PorcentajeDescuento > 100)
                throw new Exception("El porcentaje de descuento debe estar entre 0 y 100.");

            return dalEvento.InsertarEvento_SP(evento);
        }
        public IList<Evento> ObtenerEventosActivos(int idRestaurante, DateTime fechaHora)
        {
            return dalEvento.ObtenerEventosActivos(idRestaurante, fechaHora);
        }
        public IList<Evento> ObtenerEventosPorRestaurante(int idRestaurante)
        {
            return dalEvento.ObtenerEventosPorRestaurante(idRestaurante);
        }
    }
}
