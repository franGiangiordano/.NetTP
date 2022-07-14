using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;



namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
                
        #endregion

        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", sqlconn);

                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                while (drUsuarios.Read())
                {
                    Business.Entities.Usuario usr;
                    usr = new Business.Entities.Usuario();
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.Nombre = (string)drUsuarios["nombre"]; ;
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];

                    usr.IdPersona = (int)drUsuarios["id_persona"];


                    if (!drUsuarios.IsDBNull(8))
                    {
                        usr.IdPersona = (int)drUsuarios["id_persona"];
                    }
                    else
                    {
                        usr.IdPersona = -1;
                    }

                   
                    usuarios.Add(usr);
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            

            return usuarios; 
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            Business.Entities.Usuario usr;
            usr = new Business.Entities.Usuario();
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario=@id", sqlconn);
                cmdUsuarios.Parameters.Add("@id",SqlDbType.Int).Value=ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if (drUsuarios.Read())
                {                   
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.Nombre = (string)drUsuarios["nombre"]; ;
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.IdPersona = (int)drUsuarios["id_persona"];
                    //usr.IDPersona = (int)drUsuarios["id_persona"];
                    if (!drUsuarios.IsDBNull(8))
                    {
                        usr.IdPersona = (int)drUsuarios["id_persona"];
                    }
                    else
                    {
                        usr.IdPersona = -1;
                    }

                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return usr;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete usuarios where id_usuario=@id", sqlconn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();              
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("update usuarios set nombre_usuario = @nombre_usuario, " +
                    "clave = @clave, habilitado = @habilitado, nombre = @nombre, apellido = @apellido, email = @email, id_persona=@id_persona where id_usuario = @id", sqlconn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar,50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;

                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IdPersona;

                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IdPersona;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("insert into usuarios (nombre_usuario,clave,habilitado,nombre,apellido,email,id_persona) " +
                    "values (@nombre_usuario,@clave,@habilitado,@nombre,@apellido,@email,@id_persona) " +
                    "select @@identity", sqlconn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;

                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IdPersona;

                //cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IdPersona;

                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;            
        }

        //este metodo es para recuperar y validar que el usuario del login es correcto
        public Usuario GetUsuarioLogin(string user, string pass)
        {
            Usuario usr = null;
            try
            {
                OpenConnection();
                SqlCommand cmdBuscarUsuario = new SqlCommand("select * from usuarios where nombre_usuario like @user and clave like @pass", sqlconn);
                cmdBuscarUsuario.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = user;
                cmdBuscarUsuario.Parameters.Add("@pass", SqlDbType.VarChar, 50).Value = pass;
                SqlDataReader drUsuarios = cmdBuscarUsuario.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr = new Usuario();
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.Nombre = (string)drUsuarios["nombre"]; ;
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];

                    usr.IdPersona = (int)drUsuarios["id_persona"];                   

                    if (!drUsuarios.IsDBNull(8))
                    {
                        usr.IdPersona = (int)drUsuarios["id_persona"];
                    }
                    else
                    {
                        usr.IdPersona = -1;
                    }

                }
                drUsuarios.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error buscar el usuario en el Login");
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return usr;
        }

        public List<Usuario> BusquedaUsuario(int cmbCriterio, string criterio)
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();
                if (cmbCriterio == 0)
                {
                    SqlCommand cmdUsuariosID = new SqlCommand("select * from usuarios where id_usuario=@id", sqlconn);
                    cmdUsuariosID.Parameters.Add("@id", SqlDbType.Int).Value = Int32.Parse(criterio);
                    SqlDataReader drUsuariosID = cmdUsuariosID.ExecuteReader();

                    while (drUsuariosID.Read())
                    {
                        Business.Entities.Usuario usr;
                        usr = new Business.Entities.Usuario();
                        usr.ID = (int)drUsuariosID["id_usuario"];
                        usr.Nombre = (string)drUsuariosID["nombre"]; ;
                        usr.Apellido = (string)drUsuariosID["apellido"];
                        usr.NombreUsuario = (string)drUsuariosID["nombre_usuario"];
                        usr.Clave = (string)drUsuariosID["clave"];
                        usr.Email = (string)drUsuariosID["email"];
                        usr.Habilitado = (bool)drUsuariosID["habilitado"];

                        usr.IdPersona = (int)drUsuariosID["id_persona"];

                        if (!drUsuariosID.IsDBNull(8))
                        {
                            usr.IdPersona = (int)drUsuariosID["id_persona"];
                        }
                        else
                        {
                            usr.IdPersona = -1;
                        }

                        usuarios.Add(usr);
                    }
                    drUsuariosID.Close();
                }
                if (cmbCriterio == 1)
                {
                    SqlCommand cmdUsuariosNombreUsr = new SqlCommand("select * from usuarios where nombre_usuario like '%' + @nombre_usuario + '%' order by nombre_usuario", sqlconn);
                    cmdUsuariosNombreUsr.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = criterio;
                    SqlDataReader drUsuariosNombreUsr = cmdUsuariosNombreUsr.ExecuteReader();

                    while (drUsuariosNombreUsr.Read())
                    {
                        Business.Entities.Usuario usr;
                        usr = new Business.Entities.Usuario();
                        usr.ID = (int)drUsuariosNombreUsr["id_usuario"];
                        usr.Nombre = (string)drUsuariosNombreUsr["nombre"]; ;
                        usr.Apellido = (string)drUsuariosNombreUsr["apellido"];
                        usr.NombreUsuario = (string)drUsuariosNombreUsr["nombre_usuario"];
                        usr.Clave = (string)drUsuariosNombreUsr["clave"];
                        usr.Email = (string)drUsuariosNombreUsr["email"];
                        usr.Habilitado = (bool)drUsuariosNombreUsr["habilitado"];

                        usr.IdPersona = (int)drUsuariosNombreUsr["id_persona"];

                        if (!drUsuariosNombreUsr.IsDBNull(4))
                        {
                            usr.IdPersona = (int)drUsuariosNombreUsr["id_persona"];
                        }
                        else
                        {
                            usr.IdPersona = -1;
                        }
                        usuarios.Add(usr);
                    }
                    drUsuariosNombreUsr.Close();
                }
                
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
           
            return usuarios;
        }

       
    }
}
