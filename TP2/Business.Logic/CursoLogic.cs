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

        public string validaCupo(int cupo) {
            if (cupo > 0)
            {
                return "";
            }
            else {
                return "El cupo tiene que ser un numero positivo\n";
            }
        }

        public string validaAnioCalendario(int anio)
        {
            if (anio >= DateTime.Now.Year)
            {
                return "";
            }
            else
            {
                return "El año calendario debe ser el actual o posterior\n";
            }
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

        public void Update(Curso curso) {
            _CursoData.Update(curso);
        }

        public void Save(Business.Entities.Curso c)
        {
            
            try {
                _CursoData.Save(c);
                return;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
        }

        public Business.Entities.Curso GetCurso(int idMat, int idCom)
        {
            return _CursoData.GetCurso(idMat,idCom);
        }

        public Boolean TieneCupo(Curso c) {            
            if (c.Cupo > 0) {
                return true;
            }
            return false;
        }

        public Boolean validaCursoExistente(int idMat, int idCom, int anio)
        {
            return _CursoData.validaCursoExistente(idMat, idCom, anio);
        }

        public bool validarEntero(string nota)
        {
            int numericValue;
            if (int.TryParse(nota, out numericValue))
            {                
                    return true;                
            }
            else
            {
                return false;
            }
        }

    }
}
