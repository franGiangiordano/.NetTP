using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public static class Validaciones
    {
        public static bool EsMailValido(string unMail)
        {
            bool resultado = false;
            try
            {
                // se podria usar expresiones regulares Clase RegEx
                new System.Net.Mail.MailAddress(unMail);
                resultado = true;
            }
            finally
            {
                
            }
            return resultado;
        }
    }
}
