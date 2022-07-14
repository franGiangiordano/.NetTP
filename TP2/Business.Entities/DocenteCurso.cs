using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public partial class DocenteCurso : BusinessEntity
    {
        private int _IDCurso;
        private int _IDDocente;
        private string _Nombre;
        private string _Apellido;
        private int _Legajo;
        private TiposCargos cargo;
        public enum TiposCargos
        {
            Ayudante,
            Profesor,            
        }        

        public int IDCurso { get => _IDCurso; set => _IDCurso = value; }
        public int IDDocente { get => _IDDocente; set => _IDDocente = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public int Legajo { get => _Legajo; set => _Legajo = value; }
        public TiposCargos Cargo { get => cargo; set => cargo = value; }

    }
}
