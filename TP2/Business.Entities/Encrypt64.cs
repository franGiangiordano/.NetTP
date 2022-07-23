using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Business.Entities
{
    public class Encrypt64
    {
        public string Encriptar(string mensaje) {

            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(mensaje));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();

        }

        public string Desencriptar(string mensajeEncriptado) {
            string result = "";
            byte[] decrypted = Convert.FromBase64String(mensajeEncriptado);
            result = System.Text.Encoding.Unicode.GetString(decrypted);
            return result;
        }

    }
}
