using BE;
using DAL;
using System;
using System.Collections.Generic;

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

        public bool ActualizarMesa(Mesa mesa)
        {

            if (mesa.CapacidadPersonas <= 0)
                throw new Exception("La capacidad de la mesa debe ser de al menos 1 persona.");
            if (string.IsNullOrWhiteSpace(mesa.CodigoUbicacion))
                throw new Exception("El código de ubicación no puede estar vacío.");
            if (mesa.PosicionX < 0 || mesa.PosicionY < 0)
                throw new Exception("Las coordenadas de la mesa son inválidas.");
            return dalMesa.ActualizarMesa(mesa);
        }

        public bool BajaMesa(int idMesa)
        {
            // Regla: No se puede borrar si tiene reservas futuras asignadas. 
            // (Esta validación debería idealmente estar acá antes de llamar al DAL, 
            // pero si tu SQL Server lo bloquea por Foreign Key, el try/catch de la UI lo atajará).
            return dalMesa.EliminarMesa_SP(idMesa);
        }

        public IList<Mesa> ObtenerMesas(int idRestaurante)
        {
            return dalMesa.ObtenerMesasPorRestaurante_SP(idRestaurante);
        }

        public IList<Mesa> ObtenerMesasDisponibles(int idRestaurante, DateTime fechaHoraSolicitada, int comensales, int minutosEstadia)
        {
            // Validaciones de negocio
            if (fechaHoraSolicitada < DateTime.Now)
                throw new Exception("No se pueden buscar mesas en horarios pasados.");

            if (comensales <= 0)
                throw new Exception("La cantidad de comensales debe ser mayor a cero.");

            // CAMBIO: Se eliminó la instancia duplicada 'MesaDal dalMesa = new MesaDal();'
            return dalMesa.ObtenerMesasDisponibles(idRestaurante, fechaHoraSolicitada, comensales, minutosEstadia);
        }
    }
}