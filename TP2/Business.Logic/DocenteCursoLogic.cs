using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class DocenteCursoLogic : BusinessLogic
    {
        DocenteCursoAdapter _docenteCurso = new DocenteCursoAdapter();

        public DocenteCursoLogic()
        {

        }

        public List <DocenteCurso> GetDocentesCurso(int idCurso)
        {
            return _docenteCurso.GetDocentesCurso(idCurso);
        }

        public DocenteCurso GetOne(int id)
        {
            return _docenteCurso.GetOne(id);
        }


        public void Save(Business.Entities.DocenteCurso d)
        {
            _docenteCurso.Save(d);
            return;
        }


    }
}
