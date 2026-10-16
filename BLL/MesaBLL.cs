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

            // La validación de Código duplicado se delega a una restricción UNIQUE en la base de datos (DAL)
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
            // Esto lo verificaremos con un SP en la DAL que evalúe las dependencias.
            return dalMesa.EliminarMesa_SP(idMesa);
        }

        public List<Mesa> ObtenerMesas(int idRestaurante)
        {
            return dalMesa.ObtenerMesasPorRestaurante_SP(idRestaurante);
        }
    }
}
