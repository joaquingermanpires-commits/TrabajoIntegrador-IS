using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SERVICIOS
{
    public class Criptografia
    {
        public static string HashearClave(string claveLimpia)
        {
            // Se Valida que no llegue vacía
            if (string.IsNullOrEmpty(claveLimpia))
                return string.Empty;

            // Utilizacion de SHA256(viene nativo en System.Security.Cryptography)
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convercion del texto plano a un arreglo de bytes
                byte[] bytesOriginales = Encoding.UTF8.GetBytes(claveLimpia);

                // Computacion del hash
                byte[] bytesHasheados = sha256.ComputeHash(bytesOriginales);

                // Se Convierte el arreglo de bytes a un string hexadecimal para guardarlo en la bd
                StringBuilder constructorString = new StringBuilder();
                for (int i = 0; i < bytesHasheados.Length; i++)
                {
                    constructorString.Append(bytesHasheados[i].ToString("x2"));
                }

                return constructorString.ToString();
            }
        }
    }
}
