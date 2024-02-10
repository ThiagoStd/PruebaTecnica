using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica
{
    public class Variables
    {

        public static PruebaTecnicaEntities _bd = new PruebaTecnicaEntities();
        public static int _user;
        public static string _apiUrl = "http://pbiz.zonavirtual.com/api/Prueba/Consulta";

        /// <summary>
        ///  Función para obtener el hash de un string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ObtenerHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convertir la cadena de entrada a un arreglo de bytes
                byte[] bytes = Encoding.UTF8.GetBytes(input);

                // Calcular el hash
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

    }
}
