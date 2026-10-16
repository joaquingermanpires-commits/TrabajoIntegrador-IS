using ABS;
using System;
using System.Collections.Generic;

namespace BE
{
    public class Patente : Permiso
    {
        public override void AgregarHijo(Permiso p)
        {
            throw new Exception("No se le pueden agregar permisos hijos a una Patente individual.");
        }
        public override void RemoverHijo(Permiso p)
        {
            throw new Exception("No se le pueden quitar permisos hijos a una Patente individual.");
        }
        public override IList<Permiso> ObtenerHijos()
        {
            return new List<Permiso>();
        }
    }
}