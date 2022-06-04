﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        PersonaAdapter _PersonaData = new PersonaAdapter();

        public PersonaLogic()
        {          
        }

        public List<Persona> GetAll()
        {
            return _PersonaData.GetAll();
        }

        public Business.Entities.Persona GetOne(int id)
        {
            return _PersonaData.GetOne(id);
        }

        public void Delete(int id)
        {
            _PersonaData.Delete(id);
            return;
        }

        public void Save(Business.Entities.Persona u)
        {
            _PersonaData.Save(u);
            return;
        }
    }
}