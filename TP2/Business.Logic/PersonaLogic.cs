using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        PersonaAdapter _PersonaData = new PersonaAdapter();

        public PersonaLogic()
        {          
        }

        public List<Persona> GetAll()
        {
            return _PersonaData.GetAll();
        }

        public Business.Entities.Persona GetOne(int id)
        {
            return _PersonaData.GetOne(id);
        }

        public void Delete(int id)
        {
            _PersonaData.Delete(id);
            return;
        }

        public void Save(Business.Entities.Persona u)
        {
            try
            {
                _PersonaData.Save(u);
                return;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar usuarios", Ex);
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

        public Business.Entities.Persona GetOnePorLejago(int legajo)
        {
            return _PersonaData.GetOnePorLejago(legajo);
        }

        public List<Persona> GetLegajos()
        {
            return _PersonaData.GetLegajos();
        }

        public List<Persona> GetLegajosDocentes()
        {
            return _PersonaData.GetLegajosDocentes();
        }

        public List<Persona> GetLegajosAlumnos()
        {
            return _PersonaData.GetLegajosAlumnos();
        }
        public string validaNum(int num)
        {
            if (num > 0)
            {
                return "";
            }
            else
            {
                return "EL campo telefono tiene que ser un numero positivo\n";
            }
        }

        public string validaLeg(int num)
        {
            if (num > 1)
            {
                return "";
            }
            else
            {
                return "EL campo legajo tiene que mayor a 1\n";
            }
        }
        public bool GetPersona(int leg)
        {
            return _PersonaData.GetPersona(leg);
        }

    }
}
