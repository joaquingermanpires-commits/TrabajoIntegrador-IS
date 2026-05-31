using System;
using System.Collections.Generic;

namespace ABS
{
    public abstract class Permiso
    {
        public int ID_Permiso { get; set; }
        public string Nombre { get; set; }
        public string Permiso_Sistema { get; set; }
        public abstract void AgregarHijo(Permiso p);
        public abstract void RemoverHijo(Permiso p);
        public abstract IList<Permiso> ObtenerHijos();
        public override string ToString()
        {
            return Nombre;
        }
    }
}