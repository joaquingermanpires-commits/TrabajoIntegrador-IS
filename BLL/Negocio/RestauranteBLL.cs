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
        public void ActualizarReglasGlobales(Restaurante restaurante)
        {
            ValidarReglasConfiguracion(restaurante);
            RestauranteDal dal = new RestauranteDal();
            if (!dal.ActualizarReglasRestaurante(restaurante))
            {
                throw new Exception("No se pudieron actualizar las reglas en la base de datos.");
            }
        }
        private void ValidarReglasConfiguracion(Restaurante r)
        {
            if (r.TiempoMinimoPermitido < 15)
                throw new Exception("El tiempo mínimo de estadía no puede ser menor a 15 minutos.");

            if (r.TiempoMaximoPermitido <= r.TiempoMinimoPermitido)
                throw new Exception("El tiempo máximo de reserva debe ser superior al tiempo mínimo permitido.");

            if (r.PorcentajeMaximoOcupacion < 1 || r.PorcentajeMaximoOcupacion > 100)
                throw new Exception("El porcentaje de ocupación debe estar entre el 1% y el 100%.");
        }
    }
}