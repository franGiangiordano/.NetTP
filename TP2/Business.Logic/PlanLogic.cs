using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic :BusinessLogic
    {
        PlanAdapter _PlanData = new PlanAdapter();

        public PlanLogic()
        {
        }

        public List<Plan> GetAll()
        {
            return _PlanData.GetAll();
        }

        public Business.Entities.Plan GetOne(int id)
        {
            return _PlanData.GetOne(id);
        }

        public void Delete(int id)
        {
            _PlanData.Delete(id);
            return;
        }

        public void Save(Business.Entities.Plan p)
        {
            
            try {
                _PlanData.Save(p);
                return;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar plan", Ex);
                throw ExcepcionManejada;
            }
        }

        public List<Plan> GetDescripcionPlanes()
        {
            return _PlanData.GetDescripcionPlanes();
        }

        public bool validarEntero(string desc)
        {
            int numericValue;
            if (int.TryParse(desc, out numericValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string validaDesc(int desc)
        {
            if (desc > 0)
            {
                return "";
            }
            else
            {
                return "La descripcion tiene que ser un numero positivo\n";
            }
        }

        public bool validaPlanExistente(string text, int selectedValue)
        {
            return _PlanData.validaPlanExistente(text, selectedValue);
        }
    }
}

