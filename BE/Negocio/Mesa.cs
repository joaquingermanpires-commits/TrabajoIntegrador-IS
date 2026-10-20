using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mesa
    {
        public delegate void MesaModificadaEventHandler(Mesa mesa);
        public event MesaModificadaEventHandler OnMesaModificada;
        public int ID_Mesa { get; set; }
        public int ID_Restaurante { get; set; }
        public int CapacidadPersonas { get; set; }
        public int PosicionX { get; set; }
        public int PosicionY { get; set; }
        public bool EsVertical { get; set; } = false;        // true = Vertical (rotada 90°), false = Horizontal (normal)
        private string _codigoUbicacion;
        public string CodigoUbicacion
        {
            get { return _codigoUbicacion; }
            set
            {
                _codigoUbicacion = value;
                NotificarObservadores(); 
            }
        }

        private bool _habilitada;
        public bool Habilitada
        {
            get { return _habilitada; }
            set
            {
                _habilitada = value;
                NotificarObservadores(); 
            }
        }

        private void NotificarObservadores()
        {
            OnMesaModificada?.Invoke(this);
        }
        public void ModificarMesa(string codigo, int capacidad, bool habilitada)
        {
            this.CodigoUbicacion = codigo;
            this.CapacidadPersonas = capacidad;
            this.Habilitada = habilitada;
            OnMesaModificada?.Invoke(this);
        }
    }
}
