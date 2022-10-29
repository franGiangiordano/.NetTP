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

        public List<DocenteCurso> GetDocentesNoDisponibles(int idCurso)
        {
            return _docenteCurso.GetDocentesNoDisponibles(idCurso);
        }

        public DocenteCurso GetOne(int id)
        {
            return _docenteCurso.GetOne(id);
        }


        public void Save(Business.Entities.DocenteCurso d)
        {
            
            try
            {
                _docenteCurso.Save(d);
                return;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al asignar docente", Ex);
                throw ExcepcionManejada;
            }
        }

        public bool validarDocenteCargo(DocenteCurso docente) {
           int ayudantes = 0;
           List<DocenteCurso> docentes = _docenteCurso.GetDocentesCurso(docente.IDCurso);            
            if (docentes.Count < 2) {
                return true;
            }
                       
           foreach (DocenteCurso doc in docentes) {                
                if (doc.Cargo.ToString().Equals("Ayudante")) {
                    ayudantes++;
                    Console.WriteLine(ayudantes.ToString());
                }       
           }
           //Maximo 2 ayudantes
            if (ayudantes == 2 && docente.Cargo.ToString().Equals("Ayudante")) {
                return false;
            }
            return true;
        }

    }
}
