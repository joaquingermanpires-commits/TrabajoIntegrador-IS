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
            reserva.CodigoAcceso = GenerarCodigoAcceso();
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

        public Reserva ProcesarCheckInAlfanumerico(string codigoAcceso, int idRestaurante)
        {
            Reserva reservaConfirmada = dalReserva.ValidarCheckInPorCodigo(codigoAcceso, idRestaurante);

            if (reservaConfirmada != null)
            {
                Transaccion t = dalReserva.ObtenerTransaccionAsociada_SP(reservaConfirmada.ID_Reserva);
                if (t != null)
                {
                    bllTransaccion.LiberarFondos(t.ID_Transaccion);
                }
            }
            return reservaConfirmada;
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
        public int AuditarNoShowsAutomatico(int toleranciaMinutos = 15)
        {
            return dalReserva.AuditarNoShowsAutomatico(toleranciaMinutos);
        }
        public string GenerarCodigoAcceso()
        {
            const string caracteres = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            Random random = new Random();
            char[] codigo = new char[6];
            for (int i = 0; i < 6; i++)
            {
                codigo[i] = caracteres[random.Next(caracteres.Length)];
            }
            return new string(codigo);
        }
        public IList<Reserva> ObtenerReservasPorUsuario(long idUsuario)
        {
            return dalReserva.ObtenerReservasPorUsuario(idUsuario);
        }
    }
}