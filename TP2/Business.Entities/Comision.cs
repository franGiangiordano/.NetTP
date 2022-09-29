using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Comision:BusinessEntity
    {
        private int _AnioEspecialidad;
        private string _Descripcion;
        private int _IDPlan;
        private string _NombrePlan;

        public int AnioEspecialidad { get => _AnioEspecialidad; set => _AnioEspecialidad = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public int IDPlan { get => _IDPlan; set => _IDPlan = value; }

        public string NombrePlan { get => _NombrePlan; set => _NombrePlan = value; }
    }
}
