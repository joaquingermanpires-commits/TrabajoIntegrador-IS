using BE;
using DAL;
using System;
using System.Collections.Generic;

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
            if (!dalRestaurante.ActualizarReglasRestaurante(restaurante))
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
        public IList<Restaurante> BuscarRestaurantesDisponibles(DateTime fechaHora, int comensales)
        {
            if (fechaHora < DateTime.Now)
                throw new Exception("No se pueden buscar reservas en el pasado.");
            if (comensales <= 0)
                throw new Exception("La cantidad de comensales debe ser de al menos 1 persona.");
            IList<Restaurante> lista = dalRestaurante.BuscarRestaurantesDisponibles(fechaHora, comensales);
            EventoBLL bllEvento = new EventoBLL();
            PreferenciaBLL bllPreferencia = new PreferenciaBLL();

            foreach (var r in lista)
            {
                r.Eventos = (List<Evento>)bllEvento.ObtenerEventosActivos(r.ID_Restaurante, fechaHora);
                r.Preferencias = (List<PreferenciaDietetica>)bllPreferencia.ObtenerPreferenciasPorRestaurante(r.ID_Restaurante);
            }

            return lista;
        }
        public IList<Restaurante> ObtenerTodos()
        {
            return dalRestaurante.ObtenerTodos();
        }

        public bool ActualizarRestaurante(Restaurante restaurante)
        {
            if (string.IsNullOrWhiteSpace(restaurante.Nombre)) throw new Exception("El nombre es obligatorio.");
            return dalRestaurante.ActualizarRestauranteCompleto_SP(restaurante);
        }

        public bool EliminarRestaurante(int idRestaurante)
        {
            return dalRestaurante.EliminarRestaurante_SP(idRestaurante);
        }
        public Restaurante ObtenerRestaurantePorUsuario(long idUsuario)
        {
            return dalRestaurante.ObtenerRestaurantePorUsuario(idUsuario);
        }
    }
}