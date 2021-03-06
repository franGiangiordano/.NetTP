using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic : BusinessLogic
    {
        AlumnoInscripcionAdapter _AlumnoInscripcionData = new AlumnoInscripcionAdapter();

        public AlumnoInscripcionLogic()
        {
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return _AlumnoInscripcionData.GetAll();
        }

        public Business.Entities.AlumnoInscripcion GetOne(int id)
        {
            return _AlumnoInscripcionData.GetOne(id);
        }

        public void Delete(int id)
        {
            _AlumnoInscripcionData.Delete(id);
            return;
        }

        

        public void Save(Business.Entities.AlumnoInscripcion i)
        {
            
            try {
                _AlumnoInscripcionData.Save(i);
                return;

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear inscripcion", Ex);
                throw ExcepcionManejada;
            }
        }


        public List<AlumnoInscripcion> GetInscripcionesAlumno(int idAlumno)
        {
            return _AlumnoInscripcionData.GetInscripcionesAlumno(idAlumno);
        }

        public List<AlumnoInscripcion> GetInscripcionesDocente(int idDocente)
        {
            return _AlumnoInscripcionData.GetInscripcionesDocente(idDocente);
        }

        public List<AlumnoInscripcion> FiltrarPorComision(int idDocente, int idComision, int idMateria)
        {
            return _AlumnoInscripcionData.FiltrarPorComision(idDocente, idComision, idMateria);
        }

        public bool validarNota(string nota)
        {
            int numericValue;
            if (int.TryParse(nota, out numericValue))
            {
                if (numericValue >= 6 && numericValue <= 10)
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }
    }
}
