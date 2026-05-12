using ABS;
using BE;
using DAL;
using System.Collections.Generic;
using System.Linq;
// using DAL; // Lo descomentarás en el próximo paso cuando armemos el IdiomaDal

namespace BLL
{
    public class IdiomaBLL
    {
        // 1. PATRÓN SINGLETON (Para centralizar el estado del idioma)
        private static IdiomaBLL _instancia;

        public static IdiomaBLL GetInstance()
        {
            if (_instancia == null)
            {
                _instancia = new IdiomaBLL();
            }
            return _instancia;
        }

        // 2. ESTADO DEL SISTEMA
        // Usamos la abstracción IIdioma para evitar dependencias circulares
        public IIdioma IdiomaActivo { get; private set; }
        private IdiomaDal idiomaDal;
        // 3. LISTA DE OBSERVADORES (Formularios suscritos)
        private List<IObservadorIdioma> observadores = new List<IObservadorIdioma>();

        // Constructor privado
        private IdiomaBLL()
        {
            idiomaDal = new IdiomaDal();

            // La DAL devuelve List<Idioma> (Concreto de BE)
            var idiomas = idiomaDal.ObtenerIdiomasDisponibles();

            // C# asigna sin problemas un Idioma a una variable IIdioma
            IdiomaActivo = idiomas.Find(i => i.PorDefecto) ?? (idiomas.Count > 0 ? idiomas[0] : null);
        }

        // --- 4. IMPLEMENTACIÓN DEL PATRÓN OBSERVER ---

        public void Suscribir(IObservadorIdioma obs)
        {
            if (!observadores.Contains(obs))
            {
                observadores.Add(obs);

                // Un detalle Pro: Cuando un formulario se suscribe por primera vez, 
                // le mandamos el idioma activo inmediatamente para que se traduzca al abrirse.
                if (IdiomaActivo != null)
                {
                    obs.ActualizarIdioma(IdiomaActivo);
                }
            }
        }

        public void Desuscribir(IObservadorIdioma obs)
        {
            observadores.Remove(obs);
        }

        private void Notificar()
        {
            // Le avisamos a todos los formularios abiertos que se traduzcan
            foreach (var obs in observadores)
            {
                obs.ActualizarIdioma(IdiomaActivo);
            }
        }

        // --- 5. LÓGICA DE NEGOCIO ---

        public void CambiarIdioma(IIdioma nuevoIdioma)
        {
            if (nuevoIdioma != null)
            {
                this.IdiomaActivo = nuevoIdioma;
                Notificar(); // ¡Disparamos la cascada de actualizaciones visuales!
            }
        }
        public Dictionary<string, string> ObtenerTraducciones()
        {
            if (IdiomaActivo == null)
                return new Dictionary<string, string>();

            return idiomaDal.ObtenerTraducciones(IdiomaActivo.ID_Idioma);
        }

        public List<IIdioma> ObtenerIdiomasDisponibles()
        {
            return idiomaDal.ObtenerIdiomasDisponibles().Cast<IIdioma>().ToList();
        }
    }
}