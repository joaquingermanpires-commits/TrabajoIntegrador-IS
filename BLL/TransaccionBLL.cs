using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TransaccionBLL
    {
        private TransaccionDaL dalTransaccion = new TransaccionDal();

        public Transaccion ProcesarPreAutorizacion(int idReserva, int cantidadComensales, string tokenPago)
        {
            // Regla de Negocio: Monto a retener por persona
            decimal costoPorPersona = 5000.00m;
            decimal montoTotal = costoPorPersona * cantidadComensales;

            // Simulación de conexión a pasarela (Ej: MercadoPago)
            bool validacionPasarelaExcitosa = SimularPasarela(tokenPago, montoTotal);

            if (!validacionPasarelaExcitosa)
                throw new Exception("Error al procesar el seguro financiero. Verifique su medio de pago.");

            Transaccion t = new Transaccion
            {
                ID_Reserva = idReserva,
                Monto = montoTotal,
                EstadoPago = "PreAutorizado",
                FechaTransaccion = DateTime.Now,
                TokenTarjeta = tokenPago
            };

            dalTransaccion.InsertarTransaccion_SP(t);
            return t;
        }

        public void LiberarFondos(int idTransaccion)
        {
            Transaccion t = dalTransaccion.ObtenerTransaccion_SP(idTransaccion);
            if (t != null && t.EstadoPago == "PreAutorizado")
            {
                t.LiberarFondos();
                dalTransaccion.ActualizarEstadoTransaccion_SP(t);
            }
        }

        public void CapturarPenalidad(int idTransaccion)
        {
            Transaccion t = dalTransaccion.ObtenerTransaccion_SP(idTransaccion);
            if (t != null && t.EstadoPago == "PreAutorizado")
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
