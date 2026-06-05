using BE;
using System;

namespace SERVICIOS
{
    public static class GestorDV
    {
        public static long CalcularDVH(params string[] atributos)
        {
            long dvhTotal = 0;
            for (int posAtributo = 0; posAtributo < atributos.Length; posAtributo++)
            {
                string valorColumna = atributos[posAtributo];
                if (string.IsNullOrEmpty(valorColumna)) continue;

                for (int posCaracter = 0; posCaracter < valorColumna.Length; posCaracter++)
                {
                    int valorAscii = (int)valorColumna[posCaracter];
                    long calculoParcial = valorAscii * (posCaracter + 1) * (posAtributo + 1);
                    dvhTotal += calculoParcial;
                }
            }
            return dvhTotal;
        }
        public static long CalcularDVHUsuario(Usuario user)
        {
            string idStr = user.ID_Usuario.ToString();
            string nombreStr = user.Nombre_Usuario ?? "";
            string passStr = user.Contraseña_Hash ?? "";

            return CalcularDVH(idStr, nombreStr, passStr);
        }
    }
}