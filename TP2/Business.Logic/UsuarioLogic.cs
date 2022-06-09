using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        UsuarioAdapter _UsuarioData = new UsuarioAdapter();

        public UsuarioLogic()
        {          
        }

        public List<Usuario> GetAll()
        {
            return _UsuarioData.GetAll();
        }

        public Business.Entities.Usuario GetOne(int id)
        {
            return _UsuarioData.GetOne(id);
        }

        public void Delete(int id)
        {
             _UsuarioData.Delete(id);
            return;
        }

        public void Save(Business.Entities.Usuario u)
        {
            _UsuarioData.Save(u);
            return;
        }

        public bool IsValidMailAddress1(string mail)
        {
            try
            {
                System.Net.Mail.MailAddress mailAddress = new System.Net.Mail.MailAddress(mail);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public string validarClave(string clave1, string clave2)
        {
            if (clave1 != clave2)
            {
                return "Los campos de clave no coinciden, verifiquelos e intente nuevamente\n";
            }
            return "";
        }

        public string validarLongitud(string clave1)
        {
            if (clave1.Length < 8)
            {
                return "La contraseña debe tener al menos 8 caracteres\n";
            }
            return "";
        }

        


}
}
