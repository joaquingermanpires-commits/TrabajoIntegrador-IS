using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mesa
    {
        public int ID_Mesa { get; set; }
        public int ID_Restaurante { get; set; }
        public int CapacidadPersonas { get; set; }
        public string CodigoUbicacion { get; set; }
        public bool Habilitada { get; set; }

        public void OcuparMesa()
        {
            this.Habilitada = false;
        }
        public void LiberarMesa()
        {
            this.Habilitada = true;
        }
    }
}
