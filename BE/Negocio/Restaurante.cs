using BE;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Restaurante
    {
        public int ID_Restaurante { get; set; }
        public long ID_Usuario { get; set; } // El dueño
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int TiempoMinimoPermitido { get; set; }
        public int TiempoMaximoPermitido { get; set; }
        public decimal PorcentajeMaximoOcupacion { get; set; }

        public List<Mesa> Mesas { get; set; }
        public List<Evento> Eventos { get; set; }
        public List<PreferenciaDietetica> Preferencias { get; set; }
        public List<HorarioAtencion> HorariosAtencion { get; set; }
        public Restaurante()
        {
            Mesas = new List<Mesa>();
            Eventos = new List<Evento>();
            Preferencias = new List<PreferenciaDietetica>();
            HorariosAtencion = new List<HorarioAtencion>();
        }
    }
}
