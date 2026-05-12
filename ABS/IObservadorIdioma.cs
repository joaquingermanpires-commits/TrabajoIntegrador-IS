using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABS
{
    public interface IObservadorIdioma
    {
        // Este método será llamado por el Gestor cuando el usuario cambie el idioma
        void ActualizarIdioma(IIdioma idioma);
    }
}
