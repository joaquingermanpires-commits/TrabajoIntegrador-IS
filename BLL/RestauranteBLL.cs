using BE;
using System;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RestauranteBLL
    {
        private RestauranteDal dalRestaurante = new RestauranteDal();

        public bool RegistrarRestaurante(Restaurante restaurante)
        {
            ValidarReglasConfiguracion(restaurante);
            return dalRestaurante.InsertarRestaurante_SP(restaurante);
        }

        public bool ActualizarConfiguracion(Restaurante restaurante)
        {
            ValidarReglasConfiguracion(restaurante);
            return dalRestaurante.ActualizarConfiguracion_SP(restaurante);
        }

        public Restaurante ObtenerPerfilRestaurante(int idRestaurante)
        {
            return dalRestaurante.ObtenerRestaurantePorId_SP(idRestaurante);
        }

        // Responsabilidad de Hacer: Validaciones fuertes de negocio
        private void ValidarReglasConfiguracion(Restaurante r)
        {
            if (r.TiempoMaximoPermitido <= r.TiempoMinimoPermitido)
                throw new Exception("El tiempo máximo de reserva debe ser superior al tiempo mínimo permitido.");

            if (r.PorcentajeMaximoOcupacion < 1 || r.PorcentajeMaximoOcupacion > 100)
                throw new Exception("El porcentaje de ocupación debe estar entre el 1% y el 100%.");
        }
    }
}
