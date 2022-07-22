using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
   
    public class ModuloUsuarioLogic
    {
        ModuloAdapter md = new ModuloAdapter();

        public int GetIdModulo(string desc)
        {
           return md.GetIdModulo(desc);
        }

        public ModuloUsuario GetModuloUsuario(int idModulo,int idUsuario) {
            return md.GetModuloUsuario(idModulo, idUsuario);
        }

        public void CargarPermisos(List<ModuloUsuario> modulos)
        {
            md.cargarPermisos(modulos);
            return;
        }

        public void EliminarPermisos(int idUsuario)
        {
            md.eliminarPermisos(idUsuario);
            return;
        }

    }
}
