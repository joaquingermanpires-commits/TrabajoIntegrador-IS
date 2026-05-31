using ABS;
using System;
using System.Collections.Generic;

namespace BE
{
    public class Familia : Permiso
    {
        private List<Permiso> _hijos;
        public Familia()
        {
            _hijos = new List<Permiso>();
        }
        public override void AgregarHijo(Permiso p)
        {
            if (!_hijos.Contains(p)) _hijos.Add(p);
        }
        public override void RemoverHijo(Permiso p)
        {
            if (_hijos.Contains(p)) _hijos.Remove(p);
        }
        public override IList<Permiso> ObtenerHijos()
        {
            return _hijos;
        }
    }
}