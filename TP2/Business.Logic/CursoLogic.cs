using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;


namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        CursoAdapter _CursoData = new CursoAdapter();

        public CursoLogic()
        {
        }

        public List<Curso> GetAll()
        {
            return _CursoData.GetAll();
        }

        public Business.Entities.Curso GetOne(int id)
        {
            return _CursoData.GetOne(id);
        }

        public void Delete(int id)
        {
            _CursoData.Delete(id);
            return;
        }

        public void Save(Business.Entities.Curso c)
        {
            _CursoData.Save(c);
            return;
        }

        public Business.Entities.Curso GetCurso(int idMat, int idCom)
        {
            return _CursoData.GetCurso(idMat,idCom);
        }
    }
}
