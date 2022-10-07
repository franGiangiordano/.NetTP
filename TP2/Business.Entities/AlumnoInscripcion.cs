using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Entities
{
    public class AlumnoInscripcion:BusinessEntity
    {
        private string _Condicion;        
        private int _IDAlumno;
        private int _IDCurso;
        private int _Nota;
        private string _Especialidad;
        private string _Comision;
        private string _Materia;
        private int _Anio;
        private string _NomAlumno;







        public string Condicion { get => _Condicion; set => _Condicion = value; }
        public int IDAlumno { get => _IDAlumno; set => _IDAlumno = value; }
        public int IDCurso { get => _IDCurso; set => _IDCurso = value; }
        public int Nota { get => _Nota; set => _Nota = value; }
        public string Especialidad { get => _Especialidad; set => _Especialidad = value; }
        public string Comision { get => _Comision; set => _Comision = value; }
        public string Materia { get => _Materia; set => _Materia = value; }
        public int Anio { get => _Anio; set => _Anio = value; }
        public string NomAlumno { get => _NomAlumno; set => _NomAlumno = value; }
    }
}
