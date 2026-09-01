using ABS;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLL
{
    public class IdiomaBLL
    {
        private static readonly IdiomaBLL _instancia = new IdiomaBLL();
        public IIdioma IdiomaActivo { get; private set; }
        private IdiomaDal idiomaDal;
        private List<IObservadorIdioma> observadores = new List<IObservadorIdioma>();
        private IdiomaBLL()
        {
            idiomaDal = new IdiomaDal();
            var idiomas = idiomaDal.ObtenerIdiomasDisponibles();
            IdiomaActivo = idiomas.Find(i => i.PorDefecto) ?? (idiomas.Count > 0 ? idiomas[0] : null);
        }
        //Patrones Observer y Singleton:
        public static IdiomaBLL GetInstance()
        {
            return _instancia;
        }
        public void Suscribir(IObservadorIdioma obs)
        {
            if (!observadores.Contains(obs))
            {
                observadores.Add(obs);

                if (IdiomaActivo != null)
                {
                    obs.ActualizarIdioma();
                }
            }
        }
        public void Desuscribir(IObservadorIdioma obs)
        {
            observadores.Remove(obs);
        }
        public void Notificar()
        {
            foreach (var obs in observadores)
            {
                obs.ActualizarIdioma();
            }
        }
        //Estado de Sesión Visual:
        public void CambiarIdioma(IIdioma nuevoIdioma)
        {
            if (nuevoIdioma != null)
            {
                this.IdiomaActivo = nuevoIdioma;

                Notificar();
            }
        }
        //Consultas de Datos (Lectura con validación/pasarela):
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
        public DataTable ObtenerDiccionarioCompleto(int idIdioma)
        {
            return idiomaDal.ObtenerDiccionarioCompleto(idIdioma);
        }
        //Modificación de Datos (Escritura con validación de reglas de negocio):
        public void AgregarIdiomaCopiaDefault(string nombreIdioma)
        {
            if (string.IsNullOrWhiteSpace(nombreIdioma)) throw new Exception("El nombre del idioma no puede estar vacío.");
            idiomaDal.AgregarIdiomaCopiaDefault(nombreIdioma);
        }
        public void EliminarIdioma(BE.Idioma idioma)
        {
            if (idioma == null || idioma.ID_Idioma <= 0)
            {
                throw new Exception("Debe seleccionar un idioma válido para eliminar.");
            }

            // REGLA DE NEGOCIO: No se puede eliminar el idioma por defecto
            if (idioma.PorDefecto)
            {
                throw new Exception("Acción denegada: No se puede eliminar el idioma por defecto del sistema. Cambie el idioma por defecto antes de intentar eliminar este.");
            }
            idiomaDal.EliminarIdioma(idioma.ID_Idioma);
        }
        public void AgregarEtiqueta(string nombreControl)
        {
            if (string.IsNullOrWhiteSpace(nombreControl))
            {
                throw new Exception("El nombre del Tag / Etiqueta no puede estar vacío.");
            }
            idiomaDal.AgregarEtiqueta(nombreControl);
        }
        public void ModificarEtiqueta(string nombreViejo, string nombreNuevo)
        {
            if (string.IsNullOrWhiteSpace(nombreViejo) || string.IsNullOrWhiteSpace(nombreNuevo))
                throw new Exception("Debe seleccionar una etiqueta y escribir el nuevo nombre.");
            idiomaDal.ModificarEtiqueta(nombreViejo, nombreNuevo);
        }
        public void EliminarEtiqueta(string nombreControl)
        {
            if (string.IsNullOrWhiteSpace(nombreControl))
            {
                throw new Exception("Debe seleccionar una etiqueta de la grilla para eliminar.");
            }
            idiomaDal.EliminarEtiqueta(nombreControl);
        }
        public void GuardarTraduccionIndividual(int idIdioma, string nombreControl, string textoNuevo)
        {
            if (idIdioma <= 0)
            {
                throw new Exception("Debe seleccionar un idioma válido del menú desplegable.");
            }
            if (string.IsNullOrWhiteSpace(nombreControl))
            {
                throw new Exception("Debe seleccionar una etiqueta de la grilla para asignarle una traducción.");
            }
            if (string.IsNullOrWhiteSpace(textoNuevo))
            {
                throw new Exception("El texto de la traducción no puede estar vacío.");
            }
            DAL.IdiomaDal dal = new DAL.IdiomaDal();
            int idEtiqueta = dal.ObtenerIdEtiqueta(nombreControl);

            string usuarioActual = SERVICIOS.Singleton.GetInstance().GetUsuario();
            dal.GuardarTraduccion(idIdioma, idEtiqueta, textoNuevo, usuarioActual);
        }
        // 1. Guarda la traducción realizando la conversión de string a int

        // 2. Trae el historial para la UI
        public DataTable ObtenerHistorial()
        {
            DAL.IdiomaDal dal = new DAL.IdiomaDal();
            return dal.ObtenerHistorialTraducciones();
        }

        // 3. Trae un texto específico
        public string ObtenerTraduccionActual(int idIdioma, int idEtiqueta)
        {
            DAL.IdiomaDal dal = new DAL.IdiomaDal();
            return dal.ObtenerTextoTraduccion(idIdioma, idEtiqueta);
        }
        public void RestablecerTraduccion(int idIdioma, int idEtiqueta, string textoRestaurado)
        {
            // Reutilizamos la DAL que ya tiene la lógica del Stored Procedure con Transacción
            string usuarioActual = SERVICIOS.Singleton.GetInstance().GetUsuario();
            DAL.IdiomaDal dal = new DAL.IdiomaDal();
            dal.GuardarTraduccion(idIdioma, idEtiqueta, textoRestaurado, usuarioActual);
        }
    }
}