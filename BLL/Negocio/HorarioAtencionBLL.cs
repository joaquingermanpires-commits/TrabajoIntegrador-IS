using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class HorarioAtencionBLL
    {
        private HorarioAtencionDal dalHorario = new HorarioAtencionDal();
        private ReservaDal dalReserva = new ReservaDal();
        public IList<HorarioAtencion> ObtenerHorarios(int idRestaurante)
        {
            return dalHorario.ObtenerHorarios(idRestaurante);
        }

        public string ConfigurarHorario(HorarioAtencion nuevoHorario)
        {
            if (nuevoHorario.Habilitado && nuevoHorario.HoraApertura >= nuevoHorario.HoraCierre)
            {
                throw new Exception("La hora de apertura no puede ser igual o posterior a la hora de cierre.");
            }
            DateTime fechaVigencia = dalReserva.ObtenerFechaUltimaReservaPorDia(nuevoHorario.ID_Restaurante, (int)nuevoHorario.DiaSemana);
            if (!nuevoHorario.Habilitado && fechaVigencia > DateTime.Today)            // regla de negocio Deshabilitar días
            {
                DateTime diaUltimaReserva = fechaVigencia.AddDays(-1);
                throw new Exception($"No se puede deshabilitar este día porque existen reservas a futuro. La última reserva está programada para el {diaUltimaReserva.ToShortDateString()}.");
            }
            nuevoHorario.ValidoDesde = fechaVigencia;
            if (dalHorario.InsertarHorario(nuevoHorario))
            {
                if (fechaVigencia > DateTime.Today)
                {
                    return $"Cambio guardado exitosamente.\n\nNota: Debido a que existen reservas previas, este nuevo horario recién entrará en vigencia a partir del {fechaVigencia.ToShortDateString()}.";
                }
                else
                {
                    return "El horario se actualizó y entró en vigencia inmediatamente.";
                }
            }
            else
            {
                throw new Exception("Ocurrió un error inesperado al intentar guardar el horario.");
            }
        }
    }
}