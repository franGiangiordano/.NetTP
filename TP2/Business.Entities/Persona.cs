using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Persona:BusinessEntity
    {
        private string _Telefono;
        private string _Nombre;
        private string _Apellido;
        private string _Direccion;
        private int _IDPlan;
        private int _Legajo;
        private DateTime _FechaNacimiento;
        private TipoPersonas tipo;
        

        public enum TipoPersonas
        {           
            Alumno,
            Docente,
            Administrativo
        }

       
        private string _Email;

        
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public int IDPlan { get => _IDPlan; set => _IDPlan = value; }
        public int Legajo { get => _Legajo; set => _Legajo = value; }
        public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public string Email { get => _Email; set => _Email = value; }
        public TipoPersonas Tipo { get => tipo; set => tipo = value; }
       
    }
}
