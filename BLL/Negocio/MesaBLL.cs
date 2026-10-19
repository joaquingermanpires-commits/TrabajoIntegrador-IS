using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MesaBLL
    {
        private MesaDal dalMesa = new MesaDal();

        public bool AltaMesa(Mesa mesa)
        {
            if (mesa.CapacidadPersonas <= 0)
                throw new Exception("La capacidad de la mesa debe ser de al menos 1 persona.");

            if (string.IsNullOrWhiteSpace(mesa.CodigoUbicacion))
                throw new Exception("El código de ubicación es obligatorio.");

            return dalMesa.InsertarMesa_SP(mesa);
        }

        public bool ModificarMesa(Mesa mesa)
        {
            if (mesa.CapacidadPersonas <= 0)
                throw new Exception("La capacidad de la mesa debe ser de al menos 1 persona.");

            return dalMesa.ActualizarMesa_SP(mesa);
        }

        public bool BajaMesa(int idMesa)
        {
            // Regla: No se puede borrar si tiene reservas futuras asignadas. 
            return dalMesa.EliminarMesa_SP(idMesa);
        }

        public List<Mesa> ObtenerMesas(int idRestaurante)
        {
            return dalMesa.ObtenerMesasPorRestaurante_SP(idRestaurante);
        }
        public List<Mesa> ObtenerMesasDisponibles(int idRestaurante, DateTime fecha, TimeSpan hora, int comensales, int minutosEstadia)
        {
            if (fecha.Date < DateTime.Today)
                throw new Exception("No se pueden buscar mesas en fechas pasadas.");

            MesaDal dalMesa = new MesaDal();
            return dalMesa.ObtenerMesasDisponibles(idRestaurante, fecha, hora, comensales, minutosEstadia);
        }
    }
}
