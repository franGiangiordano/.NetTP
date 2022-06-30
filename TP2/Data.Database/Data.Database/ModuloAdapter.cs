using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class ModuloAdapter:Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada

        #endregion

        public int GetIdModulo(string desc)
        {
            int id=-1;
            try
            {
                this.OpenConnection();

                SqlCommand cmdModulos = new SqlCommand("select id_modulo from modulos where desc_modulo=@desc", sqlconn);
                cmdModulos.Parameters.Add("@desc", SqlDbType.VarChar).Value = desc;
                SqlDataReader drModulos = cmdModulos.ExecuteReader();

                if (drModulos.Read())
                {
                    id=  (int)drModulos["id_modulo"];                 
                }
                drModulos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return id;
        }



        public Business.Entities.ModuloUsuario GetModuloUsuario(int idModulo, int idUsuario)
        {
            Business.Entities.ModuloUsuario mod;
            mod = new Business.Entities.ModuloUsuario();
            try
            {
                this.OpenConnection();

                SqlCommand cmdModulos = new SqlCommand("select * from modulos_usuarios where id_usuario=@idUsuario and id_modulo=@idModulo", sqlconn);
                cmdModulos.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                cmdModulos.Parameters.Add("@idModulo", SqlDbType.Int).Value = idModulo;
                SqlDataReader drModulos = cmdModulos.ExecuteReader();

                if (drModulos.Read())
                {
                    mod.IdModulo = (int)drModulos["id_modulo"];
                    mod.IdUsuario = (int)drModulos["id_usuario"];
                    mod.PermiteAlta = (bool)drModulos["alta"];
                    mod.PermiteBaja = (bool)drModulos["baja"];
                    mod.PermiteConsulta = (bool)drModulos["consulta"];
                    mod.PermiteModificacion = (bool)drModulos["modificacion"];
                }
                drModulos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar modulos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return mod;
        }

       


    }
}
