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
            try {
                _UsuarioData.Delete(id);
                return;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar usuarios", Ex);
                throw ExcepcionManejada;
            }

        }
        

        public void Save(Business.Entities.Usuario u)
        {
            try {
                _UsuarioData.Save(u);
                return;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }            
            
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

        // este metodo retorna el usuario validado del login
        public Usuario GetUsuarioLogin(string user, string pass)
        {
            try {
                return _UsuarioData.GetUsuarioLogin(user, pass);
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error buscar el usuario en el Login");
                throw ExcepcionManejada;
            }
            
        }

        public List<Usuario> BusquedaUsuario(int cmbCriterio, string criterio)
        {
            return _UsuarioData.BusquedaUsuario(cmbCriterio,criterio);
        }

        public bool GetUser(string userName)
        {
            return _UsuarioData.GetUser(userName);
        }

    }
}
