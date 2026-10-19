using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class PreferenciaBLL
    {
        private PreferenciaDal dalPreferencia = new PreferenciaDal();

        public IList<PreferenciaDietetica> ObtenerPreferenciasPorRestaurante(int idRestaurante)
        {
            return dalPreferencia.ObtenerPreferenciasPorRestaurante(idRestaurante);
        }
        public IList<PreferenciaDietetica> ObtenerTodas()
        {
            return dalPreferencia.ObtenerTodas();
        }

        public bool ActualizarPreferenciasRestaurante(int idRestaurante, List<int> idsSeleccionados)
        {
            return dalPreferencia.ActualizarPreferenciasRestaurante(idRestaurante, idsSeleccionados);
        }
    }
}