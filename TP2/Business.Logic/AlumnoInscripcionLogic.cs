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
            _AlumnoInscripcionData.Save(i);
            return;
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

    }
}
