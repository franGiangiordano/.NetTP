using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones c join planes p on c.id_plan = p.id_plan ", sqlconn);

                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read())
                {
                    Business.Entities.Comision com;
                    com = new Business.Entities.Comision();
                    com.ID = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"]; ;
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IDPlan = (int)drComisiones["id_plan"];
                    com.NombrePlan = (string)drComisiones["desc_plan"];
                    comisiones.Add(com);
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return comisiones;
        }

        public Business.Entities.Comision GetOne(int ID)
        {
            Business.Entities.Comision com;
            com = new Business.Entities.Comision();
            try
            {
                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones where id_comision=@id", sqlconn);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                if (drComisiones.Read())
                {
                    com.ID = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"]; ;
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IDPlan = (int)drComisiones["id_plan"];
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return com;
        }

        public bool validaComisionExistente(string desc, int anio, int plan)
        {
            Comision com = new Comision();
            try
            {
                OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("select * from comisiones where desc_comision like @desc and anio_especialidad like @anio and id_plan like @plan", sqlconn);
                cmdCurso.Parameters.Add("@desc", SqlDbType.VarChar).Value = desc;
                cmdCurso.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                cmdCurso.Parameters.Add("@plan", SqlDbType.Int).Value = plan;
                SqlDataReader drCurso = cmdCurso.ExecuteReader();
                while (drCurso.Read())
                {
                    return true;
                }
                drCurso.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return false;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete comisiones where id_comision=@id", sqlconn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Update(Comision com)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("update comisiones set desc_comision = @desc_comision, " +
                    "anio_especialidad = @anio_especialidad, id_plan=@id_plan where id_comision = @id", sqlconn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = com.ID;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = com.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = com.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = com.IDPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Comision com)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("insert into comisiones (desc_comision,anio_especialidad, id_plan) " +
                    "values (@desc_comision,@anio_especialidad, @id_plan) " +
                    "select @@identity", sqlconn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = com.ID;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = com.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = com.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = com.IDPlan;
                com.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(Comision com)
        {
            try {
                if (com.State == BusinessEntity.States.New)
                {
                    this.Insert(com);
                }
                else if (com.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(com.ID);
                }
                else if (com.State == BusinessEntity.States.Modified)
                {
                    this.Update(com);
                }
                com.State = BusinessEntity.States.Unmodified;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            
        }

        public List<Comision> GetComisionesPlan(int idPlan, int idMateria)
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones co join cursos c on co.id_comision = c.id_comision where co.id_plan = @idPlan and c.id_materia = @idMateria and c.anio_calendario = YEAR(CURRENT_TIMESTAMP)", sqlconn);
                cmdComisiones.Parameters.Add("@idPlan", SqlDbType.Int).Value = idPlan;
                cmdComisiones.Parameters.Add("@idMateria", SqlDbType.Int).Value = idMateria;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read())
                {
                    Business.Entities.Comision com;
                    com = new Business.Entities.Comision();
                    com.ID = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"]; ;
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IDPlan = (int)drComisiones["id_plan"];
                    comisiones.Add(com);
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return comisiones;
        }

        public Business.Entities.Comision GetPorDescripcion(string desc)
        {
            Business.Entities.Comision com;
            com = new Business.Entities.Comision();
            try
            {
                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones where desc_comision=@desc_comision", sqlconn);
                cmdComisiones.Parameters.Add("@desc_comision", SqlDbType.VarChar).Value = desc;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                if (drComisiones.Read())
                {
                    com.ID = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"]; ;
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IDPlan = (int)drComisiones["id_plan"];
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return com;
        }

        public List<String> GetComisionesDeMateria(String desc_materia)
        {
            List<String> comisiones = new List<String>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("select desc_comision from cursos c join comisiones com on c.id_comision=com.id_comision join materias mat on mat.id_materia=c.id_materia where mat.desc_materia=@desc_materia", sqlconn);
                cmdComisiones.Parameters.Add("@desc_materia", SqlDbType.VarChar).Value = desc_materia;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read())
                {                    
                    comisiones.Add((string)drComisiones["desc_comision"]);
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return comisiones;
        }

        public List<Comision> GetDescripciones()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("select id_comision, desc_comision from comisiones", sqlconn);

                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read())
                {
                    Business.Entities.Comision com;
                    com = new Business.Entities.Comision();
                    com.ID = (int)drComisiones["id_comision"];
                    com.Descripcion = (string)drComisiones["desc_comision"]; ;
                    comisiones.Add(com);
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return comisiones;
        }

    }
}
