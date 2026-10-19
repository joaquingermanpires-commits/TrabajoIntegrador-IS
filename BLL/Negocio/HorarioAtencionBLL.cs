using BE.Negocio;
using DAL;
using DAL.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Negocio
{
    public class HorarioAtencionBLL
    {
        public List<HorarioAtencion> ObtenerHorarios(int idRestaurante)
        {
            HorarioAtencionDal dal = new HorarioAtencionDal();
            return dal.ObtenerHorarios(idRestaurante);
        }
        public string ConfigurarHorario(HorarioAtencion nuevoHorario)
        {
            if (nuevoHorario.Habilitado && nuevoHorario.HoraApertura >= nuevoHorario.HoraCierre)
            {
                throw new Exception("La hora de apertura no puede ser igual o posterior a la hora de cierre.");
            }
            ReservaDal reservaDal = new ReservaDal();
            DateTime fechaVigencia = reservaDal.ObtenerFechaUltimaReservaPorDia(nuevoHorario.ID_Restaurante, nuevoHorario.DiaSemana);

            // REGLA DE NEGOCIO ESTRICTA: Deshabilitar días
            if (!nuevoHorario.Habilitado && fechaVigencia > DateTime.Today)
            {
                DateTime diaUltimaReserva = fechaVigencia.AddDays(-1);
                throw new Exception($"No se puede deshabilitar este día porque existen reservas a futuro. La última reserva está programada para el {diaUltimaReserva.ToShortDateString()}.");
            }
            nuevoHorario.ValidoDesde = fechaVigencia;
            HorarioAtencionDal horarioDal = new HorarioAtencionDal();
            if (horarioDal.InsertarHorario(nuevoHorario))
            {
                // Si la fecha de vigencia es mayor a hoy, le avisamos al gerente
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
