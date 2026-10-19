using BE;
using DAL;
using System;

namespace BLL
{
    public class TransaccionBLL
    {
        private TransaccionDal dalTransaccion = new TransaccionDal();

        // CAMBIO: Elevamos el número mágico a una constante de negocio a nivel de clase
        private const decimal COSTO_SEGURO_POR_PERSONA = 5000.00m;

        public Transaccion ProcesarPreAutorizacion(int idReserva, int cantidadComensales, string tokenPago)
        {
            // Regla de Negocio calculada limpiamente
            decimal montoTotal = COSTO_SEGURO_POR_PERSONA * cantidadComensales;
            bool validacionPasarelaExcitosa = SimularPasarela(tokenPago, montoTotal);

            if (!validacionPasarelaExcitosa)
                throw new Exception("Error al procesar el seguro financiero. Verifique su medio de pago.");

            Transaccion t = new Transaccion
            {
                ID_Reserva = idReserva,
                Monto = montoTotal,
                Pago = Transaccion.EstadoPago.PreAutorizado,
                FechaTransaccion = DateTime.Now,
                TokenTarjeta = tokenPago
            };

            dalTransaccion.InsertarTransaccion_SP(t);
            return t;
        }

        public void LiberarFondos(int idTransaccion)
        {
            Transaccion t = dalTransaccion.ObtenerTransaccion_SP(idTransaccion);
            if (t != null && t.Pago == Transaccion.EstadoPago.PreAutorizado)
            {
                t.LiberarFondos();
                dalTransaccion.ActualizarEstadoTransaccion_SP(t);
            }
        }

        public void CapturarPenalidad(int idTransaccion)
        {
            Transaccion t = dalTransaccion.ObtenerTransaccion_SP(idTransaccion);
            if (t != null && t.Pago == Transaccion.EstadoPago.PreAutorizado)
            {
                t.CapturarPenalidad();
                dalTransaccion.ActualizarEstadoTransaccion_SP(t);
            }
        }

        private bool SimularPasarela(string token, decimal monto)
        {
            return !string.IsNullOrWhiteSpace(token); // Prueba
        }
    }
}