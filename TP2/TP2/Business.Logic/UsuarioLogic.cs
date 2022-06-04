using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        UsuarioAdapter _UsuarioData = new UsuarioAdapter();

        public UsuarioLogic()
        {          
        }

        public List<Usuario> GetAll()
        {
            return _UsuarioData.GetAll();
        }

        public Business.Entities.Usuario GetOne(int id)
        {
            return _UsuarioData.GetOne(id);
        }

        public void Delete(int id)
        {
             _UsuarioData.Delete(id);
            return;
        }

        public void Save(Business.Entities.Usuario u)
        {
            _UsuarioData.Save(u);
            return;
        }
    }
}
