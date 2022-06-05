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
    }
}
