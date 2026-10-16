using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReservaBLL
    {
        private ReservaDal dalReserva = new ReservaDal();
        private TransaccionBLL bllTransaccion = new TransaccionBLL();

        public bool GenerarReserva(Reserva reserva, string tokenTarjeta)
        {
            // 1. Validar Cupo del Salón
            if (!ValidarDisponibilidad(reserva.ID_Restaurante, reserva.FechaHoraSolicitada, reserva.CantidadComensales))
                throw new Exception("No hay disponibilidad en el salón para la fecha y cantidad de comensales solicitada.");

            // 2. Persistir la reserva inicialmente en estado "Pendiente" para obtener su ID
            int idReservaGenerada = dalReserva.InsertarReserva_SP(reserva);
            reserva.ID_Reserva = idReservaGenerada;

            try
            {
                // 3. Procesar Seguro Financiero (Delega a BLL_Transaccion)
                Transaccion seguro = bllTransaccion.ProcesarPreAutorizacion(idReservaGenerada, reserva.CantidadComensales, tokenTarjeta);
                reserva.SeguroFinanciero = seguro;

                // 4. Si el pago pasa, se confirma la reserva
                reserva.ConfirmarReserva();
                dalReserva.ActualizarEstado_SP(reserva);
                return true;
            }
            catch (Exception ex)
            {
                // Si la tarjeta rebota, la reserva se cancela inmediatamente liberando el cupo
                reserva.CancelarReserva();
                dalReserva.ActualizarEstado_SP(reserva);
                throw new Exception(ex.Message);
            }
        }

        public bool RegistrarCheckIn(int idReserva, string codigoQR, int idMesaAsignada)
        {
            Reserva reserva = dalReserva.ObtenerReservaPorId_SP(idReserva);

            if (reserva == null || reserva.Estado != "Confirmada")
                throw new Exception("Código QR inválido o reserva no vigente.");

            // 1. Registrar llegada operativa
            reserva.RegistrarCheckInReal(DateTime.Now, idMesaAsignada);
            dalReserva.ActualizarEstado_SP(reserva);

            // 2. Obtener transacción asociada y devolver el dinero al cliente
            Transaccion t = dalReserva.ObtenerTransaccionAsociada_SP(idReserva);
            bllTransaccion.LiberarFondos(t.ID_Transaccion);

            return true;
        }

        public void ProcesarNoShowManual(int idReserva)
        {
            Reserva reserva = dalReserva.ObtenerReservaPorId_SP(idReserva);
            if (reserva != null && reserva.Estado == "Confirmada")
            {
                reserva.MarcarComoNoShow();
                dalReserva.ActualizarEstado_SP(reserva);

                Transaccion t = dalReserva.ObtenerTransaccionAsociada_SP(idReserva);
                bllTransaccion.CapturarPenalidad(t.ID_Transaccion);
            }
            else
            {
                throw new Exception("Acción denegada. La reserva ya registra ingreso físico en el local u otro estado definitivo.");
            }
        }

        public void AuditarNoShowsAutomatico()
        {
            // Busca reservas Confirmadas cuya hora solicitada + margen ya expiró
            List<Reserva> reservasExpiradas = dalReserva.ObtenerReservasExpiradas_SP();

            foreach (var reserva in reservasExpiradas)
            {
                reserva.MarcarComoNoShow();
                dalReserva.ActualizarEstado_SP(reserva);

                Transaccion t = dalReserva.ObtenerTransaccionAsociada_SP(reserva.ID_Reserva);
                bllTransaccion.CapturarPenalidad(t.ID_Transaccion);
            }
        }

        private bool ValidarDisponibilidad(int idRestaurante, DateTime fecha, int comensales)
        {
            // Ejecuta lógica en SQL que suma (Comensales Confirmados + Comensales Solicitados) vs Capacidad del Restaurante
            return dalReserva.VerificarCupo_SP(idRestaurante, fecha, comensales);
        }
    }
}
