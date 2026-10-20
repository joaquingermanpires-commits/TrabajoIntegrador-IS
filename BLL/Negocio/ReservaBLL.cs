using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ReservaBLL
    {
        private ReservaDal dalReserva = new ReservaDal();
        private TransaccionBLL bllTransaccion = new TransaccionBLL();

        public bool GenerarReserva(Reserva reserva, string tokenTarjeta)
        {
            if (reserva.FechaHoraSolicitada < DateTime.Now)
                throw new Exception("La fecha y hora de la reserva no puede ser en el pasado.");
            if (reserva.CantidadComensales <= 0)
                throw new Exception("La cantidad de comensales debe ser mayor a cero.");
            if (!ValidarDisponibilidad(reserva.ID_Restaurante, reserva.FechaHoraSolicitada, reserva.CantidadComensales))   // valida el Cupo del Salón
                throw new Exception("No hay disponibilidad en el salón para la fecha y cantidad de comensales solicitada.");

            int idReservaGenerada = dalReserva.InsertarReserva_SP(reserva);
            reserva.ID_Reserva = idReservaGenerada;

            try
            {
                Transaccion seguro = bllTransaccion.ProcesarPreAutorizacion(idReservaGenerada, reserva.CantidadComensales, tokenTarjeta);
                reserva.SeguroFinanciero = seguro;
                reserva.ConfirmarReserva();
                dalReserva.ActualizarEstado_SP(reserva);
                return true;
            }
            catch (Exception ex)
            {
                reserva.CancelarReserva();
                dalReserva.ActualizarEstado_SP(reserva);
                throw new Exception(ex.Message);
            }
        }

        public bool RegistrarCheckIn(int idReserva, string codigoQR, int idMesaAsignada)
        {
            Reserva reserva = dalReserva.ObtenerReservaPorId_SP(idReserva);

            if (reserva == null || reserva.Estado != Reserva.EstadoReserva.Confirmada)
                throw new Exception("Código QR inválido o reserva no vigente.");

            reserva.RegistrarCheckInReal(DateTime.Now, idMesaAsignada);
            dalReserva.ActualizarEstado_SP(reserva);
            Transaccion t = dalReserva.ObtenerTransaccionAsociada_SP(idReserva);
            if (t != null)
            {
                bllTransaccion.LiberarFondos(t.ID_Transaccion);
            }

            return true;
        }

        public void ProcesarNoShowManual(int idReserva)
        {
            Reserva reserva = dalReserva.ObtenerReservaPorId_SP(idReserva);

            if (reserva != null && reserva.Estado == Reserva.EstadoReserva.Confirmada)
            {
                reserva.MarcarComoNoShow();
                dalReserva.ActualizarEstado_SP(reserva);
                Transaccion t = dalReserva.ObtenerTransaccionAsociada_SP(idReserva);
                if (t != null)
                {
                    bllTransaccion.CapturarPenalidad(t.ID_Transaccion);
                }
            }
            else
            {
                throw new Exception("Acción denegada. La reserva ya registra ingreso físico en el local u otro estado definitivo.");
            }
        }

        public void AuditarNoShowsAutomatico()
        {
            IList<Reserva> reservasExpiradas = dalReserva.ObtenerReservasExpiradas_SP();
            foreach (var reserva in reservasExpiradas)
            {
                reserva.MarcarComoNoShow();
                dalReserva.ActualizarEstado_SP(reserva);
                Transaccion t = dalReserva.ObtenerTransaccionAsociada_SP(reserva.ID_Reserva);
                if (t != null)
                {
                    bllTransaccion.CapturarPenalidad(t.ID_Transaccion);
                }
            }
        }

        private bool ValidarDisponibilidad(int idRestaurante, DateTime fecha, int comensales)
        {
            return dalReserva.VerificarCupo_SP(idRestaurante, fecha, comensales);
        }
    }
}