using ABS;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
// using DAL; // Lo descomentarás en el próximo paso cuando armemos el IdiomaDal

namespace BLL
{
    public class IdiomaBLL
    {
        // 1. PATRÓN SINGLETON (Para centralizar el estado del idioma)
        private static readonly IdiomaBLL _instancia = new IdiomaBLL();

        public static IdiomaBLL GetInstance()
        {
            return _instancia;
        }
        public IIdioma IdiomaActivo { get; private set; }
        private IdiomaDal idiomaDal;
        private List<IObservadorIdioma> observadores = new List<IObservadorIdioma>();
        private IdiomaBLL()
        {
            idiomaDal = new IdiomaDal();
            var idiomas = idiomaDal.ObtenerIdiomasDisponibles();
            IdiomaActivo = idiomas.Find(i => i.PorDefecto) ?? (idiomas.Count > 0 ? idiomas[0] : null);
        }
        public void Suscribir(IObservadorIdioma obs)
        {
            if (!observadores.Contains(obs))
            {
                observadores.Add(obs);

                if (IdiomaActivo != null)
                {
                    // Quitamos el parámetro IdiomaActivo
                    obs.ActualizarIdioma();
                }
            }
        }
        public void Desuscribir(IObservadorIdioma obs)
        {
            observadores.Remove(obs);
        }
        private void Notificar()
        {
            foreach (var obs in observadores)
            {
                // Quitamos el parámetro IdiomaActivo
                obs.ActualizarIdioma();
            }
        }
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
        public void AgregarIdioma(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre del idioma no puede estar vacío.");
            idiomaDal.AgregarIdioma(nombre);
        }
        public void AgregarEtiquetaConTraduccion(string nombreControl, int idIdioma, string texto)
        {
            if (string.IsNullOrWhiteSpace(nombreControl))
                throw new Exception("El nombre del Tag / Etiqueta no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(texto))
                throw new Exception("Debe ingresar una traducción para la nueva etiqueta.");
            if (idIdioma <= 0)
                throw new Exception("Seleccione un idioma válido.");

            idiomaDal.AgregarEtiquetaConTraduccion(nombreControl, idIdioma, texto);
        }
        public void GuardarTraducciones(int idIdioma, Dictionary<string, string> nuevasTraducciones)
        {
            if (idIdioma <= 0) throw new Exception("Debe seleccionar un idioma válido.");

            foreach (var item in nuevasTraducciones)
            {
                // Solo guardamos si el usuario escribió algo en la grilla
                if (!string.IsNullOrWhiteSpace(item.Value))
                {
                    idiomaDal.GuardarTraduccion(idIdioma, item.Key, item.Value);
                }
            }
        }
        public DataTable ObtenerDiccionarioCompleto(int idIdioma)
        {
            return idiomaDal.ObtenerDiccionarioCompleto(idIdioma);
        }
    }
}