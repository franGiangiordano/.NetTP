using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;

//Se trata de una clase de prueba con una DB hardcodeada por lo tanto no formará parte del TP, sin embargo,
//resulta útil para tener como referencia

namespace Data.Database
{
    public class PersonaAdapter:Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Persona> _Personas;

        private static List<Persona> Personas
        {
            get
            {
                if (_Personas == null)
                {
                    _Personas = new List<Business.Entities.Persona>();
                    Business.Entities.Persona usr;
                    usr = new Business.Entities.Persona();
                    usr.ID = 1;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Casimiro";
                    usr.Apellido = "Cegado";
                    usr.Telefono = "213112331";
                    usr.Email = "casimirocegado@gmail.com";
                    usr.Direccion = "asdad";
                    usr.IDPlan = 1;
                    usr.Tipo = (Persona.TipoPersonas)1;
                    usr.Legajo = 123123;
                    usr.FechaNacimiento = DateTime.Now;
                    _Personas.Add(usr);

                    
                }
                return _Personas;
            }            
         }
        #endregion

        public List<Persona> GetAll()
        {
            return new List<Persona>(Personas);
        }

        public Business.Entities.Persona GetOne(int ID)
        {
            return Personas.Find(delegate(Persona u) { return u.ID == ID; });
        }

        public void Delete(int ID)
        {
            Personas.Remove(this.GetOne(ID));
        }

        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (Persona usr in Personas)
                {
                    if (usr.ID > NextID)
                    {
                        NextID = usr.ID;
                    }
                }
                persona.ID = NextID + 1;
                Personas.Add(persona);
            }
            else if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                Personas[Personas.FindIndex(delegate(Persona u) { return u.ID == persona.ID; })]=persona;
            }
            persona.State = BusinessEntity.States.Unmodified;            
        }
    }
}
