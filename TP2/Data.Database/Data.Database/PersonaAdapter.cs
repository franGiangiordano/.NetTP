using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;


//Se trata de una clase de prueba con una DB hardcodeada por lo tanto no formará parte del TP, sin embargo,
//resulta útil para tener como referencia

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Persona> _Personas;

        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas", sqlconn);

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Business.Entities.Persona per;
                    per = new Business.Entities.Persona();
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"]; ;
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.Direccion = (string)drPersonas["direccion"];

                    if (!drPersonas.IsDBNull(4))
                    {
                        per.Email = (string)drPersonas["email"];
                    }
                    else
                    {
                        per.Email = "";
                    }



                    per.Legajo = (int)drPersonas["legajo"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Tipo = (Persona.TipoPersonas)drPersonas["tipo_persona"];
                    per.IDPlan = (int)drPersonas["id_plan"];

                    personas.Add(per);
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return personas; //llamar a open , hacer select, exeecute reader

        }

        public Business.Entities.Persona GetOne(int ID)
        {
            Business.Entities.Persona per;
            per = new Business.Entities.Persona();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona=@id", sqlconn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"]; ;
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Legajo = (int)drPersonas["legajo"];
                    if (!drPersonas.IsDBNull(4))
                    {
                        per.Email = (string)drPersonas["email"];
                    }
                    else
                    {
                        per.Email = "";
                    }

                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Tipo = (Persona.TipoPersonas)drPersonas["tipo_persona"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return per;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona=@id", sqlconn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("update personas set nombre = @nombre, " +
                    "apellido = @apellido, direccion = @direccion, telefono = @telefono, fecha_nac = @fecha_nac, legajo = @legajo, tipo_persona = @tipo_persona, id_plan = @id_plan, email=@email   where id_persona = @id", sqlconn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime, 50).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.Tipo;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        protected void Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("insert into personas (nombre, apellido, direccion,email ,telefono, fecha_nac, legajo, tipo_persona, id_plan) " +
                    "values (@nombre ,@apellido,@direccion,@email,@telefono,@fecha_nac,@legajo,@tipo_persona,@id_plan) " +
                    "select @@identity", sqlconn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime, 50).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.Tipo;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                persona.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }


        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
        }

        public Business.Entities.Persona GetOnePorLejago(int legajo)
        {
            Business.Entities.Persona per;
            per = new Business.Entities.Persona();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas where legajo=@legajo", sqlconn);
                cmdPersonas.Parameters.Add("@legajo", SqlDbType.Int).Value = legajo;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"]; ;
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Tipo = (Persona.TipoPersonas)drPersonas["tipo_persona"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                    if (!drPersonas.IsDBNull(4))
                    {
                        per.Email = (string)drPersonas["email"];
                    }
                    else
                    {
                        per.Email = "";
                    }
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return per;
        }

        public List<Persona> GetLegajos()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdLegajos = new SqlCommand("select distinct id_persona, legajo from personas order by legajo desc", sqlconn);

                SqlDataReader drLegajos = cmdLegajos.ExecuteReader();

                while (drLegajos.Read())
                {
                    Business.Entities.Persona per;
                    per = new Business.Entities.Persona();
                    per.ID = (int)drLegajos["id_persona"];
                    per.Legajo = (int)drLegajos["legajo"];
                    personas.Add(per);
                }
                drLegajos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de legajos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return personas;
        }

        public List<Persona> GetLegajosDocentes()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdLegajos = new SqlCommand("select id_persona, legajo from personas where tipo_persona=1 order by legajo", sqlconn);

                SqlDataReader drLegajos = cmdLegajos.ExecuteReader();

                while (drLegajos.Read())
                {
                    Business.Entities.Persona per;
                    per = new Business.Entities.Persona();
                    per.ID = (int)drLegajos["id_persona"];
                    per.Legajo = (int)drLegajos["legajo"];
                    personas.Add(per);
                }
                drLegajos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de legajos de docentes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return personas;
        }

        public List<Persona> GetLegajosAlumnos()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdLegajos = new SqlCommand("select id_persona, legajo from personas where tipo_persona=0 order by legajo", sqlconn);

                SqlDataReader drLegajos = cmdLegajos.ExecuteReader();

                while (drLegajos.Read())
                {
                    Business.Entities.Persona per;
                    per = new Business.Entities.Persona();
                    per.ID = (int)drLegajos["id_persona"];
                    per.Legajo = (int)drLegajos["legajo"];
                    personas.Add(per);
                }
                drLegajos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de legajos de docentes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return personas;
        }

        public bool GetPersona(int legajo)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas where legajo=@legajo", sqlconn);
                cmdPersonas.Parameters.Add("@legajo", SqlDbType.Int).Value = legajo;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {
                    return true;
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return false;
        }
    }
}
#endregion