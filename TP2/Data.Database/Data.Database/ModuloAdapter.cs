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

        public void cargarPermisos(List<ModuloUsuario> modulos)
        {
            int i = 0;
                using (SqlConnection connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=academia;Integrated Security=SSPI;")) {
                    connection.Open();
                    SqlTransaction sqlTran = connection.BeginTransaction();

                    SqlCommand command = connection.CreateCommand();
                    command.Transaction = sqlTran;
                try
                {                  
                        foreach (ModuloUsuario m in modulos) {
                            i++;
                            command.CommandText =
                              "INSERT INTO modulos_usuarios VALUES("+$"@modulo{i},@usuario{i},@alta{i},@baja{i},@modificacion{i},@consulta{i})";
                            command.Parameters.Add($"@modulo{i}", SqlDbType.Int).Value = m.IdModulo;
                            command.Parameters.Add($"@usuario{i}", SqlDbType.Int).Value = m.IdUsuario;
                            command.Parameters.Add($"@alta{i}", SqlDbType.Bit).Value = m.PermiteAlta;
                            command.Parameters.Add($"@baja{i}", SqlDbType.Bit).Value = m.PermiteBaja;
                            command.Parameters.Add($"@modificacion{i}", SqlDbType.Bit).Value = m.PermiteModificacion;
                            command.Parameters.Add($"@consulta{i}", SqlDbType.Bit).Value = m.PermiteConsulta;
                            command.ExecuteNonQuery();                            
                        }                                                                              
                    // Commit the transaction.
                    sqlTran.Commit();                    
                }
                catch (Exception Ex)
                {
                    //falta rollback
                    sqlTran.Rollback();
                    Exception ExcepcionManejada = new Exception("Error al cargar permisos", Ex);
                    throw ExcepcionManejada;
                }                
            }            

        }

        public void editarPermisos(List<ModuloUsuario> modulos)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=academia;Integrated Security=SSPI;"))
            {
                connection.Open();
                SqlTransaction sqlTran = connection.BeginTransaction();

                SqlCommand command = connection.CreateCommand();
                command.Transaction = sqlTran;
                try
                {
                        foreach (ModuloUsuario m in modulos)
                        {
                            i++;
                            command.CommandText =
                              "UPDATE modulos_usuarios SET=id_modulo =" + $"@modulo{i}," + "id_usuario ="+ $"@usuario{i},"+"alta =" + $"@alta{i}," + "baja =" + $"@baja{i}," + "modificacion =" + $"@modificacion{i}," + "consulta =" + $"@consulta{i} where id=modulo_usuario =" + $"@id{i}";
                            command.Parameters.Add($"@id{i}", SqlDbType.Int).Value = m.ID;
                            command.Parameters.Add($"@modulo{i}", SqlDbType.Int).Value = m.IdModulo;
                            command.Parameters.Add($"@usuario{i}", SqlDbType.Int).Value = m.IdUsuario;
                            command.Parameters.Add($"@alta{i}", SqlDbType.Bit).Value = m.PermiteAlta;
                            command.Parameters.Add($"@baja{i}", SqlDbType.Bit).Value = m.PermiteBaja;
                            command.Parameters.Add($"@modificacion{i}", SqlDbType.Bit).Value = m.PermiteModificacion;
                            command.Parameters.Add($"@consulta{i}", SqlDbType.Bit).Value = m.PermiteConsulta;
                            command.ExecuteNonQuery();
                        }                
                    // Commit the transaction.
                    sqlTran.Commit();
                }
                catch (Exception Ex)
                {
                    sqlTran.Rollback();
                    Exception ExcepcionManejada = new Exception("Error al cargar permisos", Ex);
                    throw ExcepcionManejada;
                }
            }

        }


        public void eliminarPermisos(int idUsuario)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete modulos_usuarios where id_usuario=@id", sqlconn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar permisos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


        }


    }
}
