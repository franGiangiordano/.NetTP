using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        EspecialidadAdapter _EspecialidadData = new EspecialidadAdapter();

        public EspecialidadLogic()
        {
        }

        public List<Especialidad> GetAll()
        {
            return _EspecialidadData.GetAll();
        }

        public Business.Entities.Especialidad GetOne(int id)
        {
            return _EspecialidadData.GetOne(id);
        }

        public void Delete(int id)
        {
            _EspecialidadData.Delete(id);
            return;
        }

        public void Save(Business.Entities.Especialidad m)
        {
            _EspecialidadData.Save(m);
            return;
        }

        public List<Especialidad> GetEspecialidades()
        {
            return _EspecialidadData.GetEspecialidades();
        }

    }
}
