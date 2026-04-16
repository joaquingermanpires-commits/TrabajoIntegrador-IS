using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace BLL
{
    public class UsuarioBLL
    {
        private readonly UsuarioDal usuarioDal;

        public UsuarioBLL() 
        {
        usuarioDal = new UsuarioDal();
        }
        public UsuarioDal Login(string Nombre_Usuario,
        string Contraseña_Hash)
        {
            if (string.IsNullOrEmpty(Nombre_Usuario) || string.IsNullOrEmpty(Contraseña_Hash))
                throw new Exception("Debe ingresar usuario y contraseña.");

            // Aquí podrías hashear el password antes de mandarlo a la DAL
            return usuarioDal.Login(Nombre_Usuario, Contraseña_Hash);
        }
    }
}
