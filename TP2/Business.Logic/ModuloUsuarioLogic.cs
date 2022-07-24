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
            try { return md.GetIdModulo(desc); }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar modulos", Ex);
                throw ExcepcionManejada;
            }
        }

        public ModuloUsuario GetModuloUsuario(int idModulo,int idUsuario) {
            
            try { return md.GetModuloUsuario(idModulo, idUsuario); }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar modulos", Ex);
                throw ExcepcionManejada;
            }
        }

        public void CargarPermisos(List<ModuloUsuario> modulos)
        {
            
            try {
                md.cargarPermisos(modulos);
                return;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar modulos", Ex);
                throw ExcepcionManejada;
            }
        }

        public void EliminarPermisos(int idUsuario)
        {
            try
            {
                md.eliminarPermisos(idUsuario);
                return;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar modulos", Ex);
                throw ExcepcionManejada;
            }
           
        }

    }
}
