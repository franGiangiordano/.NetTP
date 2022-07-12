using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        ComisionAdapter _PlanComision = new ComisionAdapter();

        public ComisionLogic()
        {
        }

        public List<Comision> GetAll()
        {
            return _PlanComision.GetAll();
        }

        public Business.Entities.Comision GetOne(int id)
        {
            return _PlanComision.GetOne(id);
        }

        public void Delete(int id)
        {
            _PlanComision.Delete(id);
            return;
        }

        public void Save(Business.Entities.Comision c)
        {
            _PlanComision.Save(c);
            return;
        }

        public List<Comision> GetComisionesPlan(int idPlan, int idMateria)
        {
            return _PlanComision.GetComisionesPlan(idPlan, idMateria);
        }

        public Business.Entities.Comision GetPorDescripcion(string desc)
        {
            return _PlanComision.GetPorDescripcion(desc);
        }


        public List<String> GetComisionesDeMateria(string desc_materia)
        {
            return _PlanComision.GetComisionesDeMateria(desc_materia);
        }

        public List<Comision> GetDescripciones()
        {
            return _PlanComision.GetDescripciones();
        }

    }
}
