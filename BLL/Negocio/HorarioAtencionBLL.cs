using BE;
using DAL;
using DAL.Negocio;
using System;
using System.Collections.Generic;

namespace BLL.Negocio
{
    public class HorarioAtencionBLL
    {
        // CAMBIO: Declaramos las dependencias (DALs) una sola vez a nivel de clase
        private HorarioAtencionDal dalHorario = new HorarioAtencionDal();
        private ReservaDal dalReserva = new ReservaDal();

        // CAMBIO: Devolvemos IList según nuestro nuevo estándar
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

            // Usamos la variable de clase dalReserva
            DateTime fechaVigencia = dalReserva.ObtenerFechaUltimaReservaPorDia(nuevoHorario.ID_Restaurante, (int)nuevoHorario.DiaSemana);

            // REGLA DE NEGOCIO ESTRICTA: Deshabilitar días
            if (!nuevoHorario.Habilitado && fechaVigencia > DateTime.Today)
            {
                DateTime diaUltimaReserva = fechaVigencia.AddDays(-1);
                throw new Exception($"No se puede deshabilitar este día porque existen reservas a futuro. La última reserva está programada para el {diaUltimaReserva.ToShortDateString()}.");
            }
            nuevoHorario.ValidoDesde = fechaVigencia;

            // Usamos la variable de clase dalHorario
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