using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        MateriaAdapter _MateriaData = new MateriaAdapter();

        public MateriaLogic()
        {
        }

        public List<Materia> GetAll()
        {
            return _MateriaData.GetAll();
        }

        public Business.Entities.Materia GetOne(int id)
        {
            return _MateriaData.GetOne(id);
        }

        public void Delete(int id)
        {
            _MateriaData.Delete(id);
            return;
        }

        public void Save(Business.Entities.Materia m)
        {
            _MateriaData.Save(m);
            return;
        }

        public string ValidarHs(string HsSemanales, string HsTotales)
        {

            if (!String.IsNullOrEmpty(HsSemanales) && !String.IsNullOrEmpty(HsTotales) && Int32.Parse(HsSemanales) > Int32.Parse(HsTotales))
            {
                return "La cantidad de hs Totales debe ser superior a las semanales\n";
            }
            return "";
        }

        public List<Materia> GetMateriasPlan(int idPlan)
        {
            return _MateriaData.GetMateriasPlan(idPlan);
        }

        public Business.Entities.Materia GetPorDescripcion(string desc)
        {
            return _MateriaData.GetPorDescripcion(desc);
        }

    }
}
