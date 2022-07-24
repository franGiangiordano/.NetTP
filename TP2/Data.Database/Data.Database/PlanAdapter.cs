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
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPlanes = new SqlCommand("select * from planes", sqlconn);

                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                while (drPlanes.Read())
                {
                    Business.Entities.Plan plan;
                    plan = new Business.Entities.Plan();
                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"]; ;
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];
                    planes.Add(plan);
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return planes;
        }

        public Business.Entities.Plan GetOne(int ID)
        {
            Business.Entities.Plan plan;
            plan = new Business.Entities.Plan();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPlanes = new SqlCommand("select * from planes where id_plan=@id", sqlconn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                if (drPlanes.Read())
                {
                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"]; ;
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return plan;
        }

        public bool validaPlanExistente(string desc, int idEsp)
        {
            Plan pl = new Plan();
            try
            {
                OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("select * from planes where desc_plan like @desc and id_especialidad like @idEsp", sqlconn);
                cmdCurso.Parameters.Add("@desc", SqlDbType.VarChar).Value = desc;
                cmdCurso.Parameters.Add("@idEsp", SqlDbType.Int).Value = idEsp;                
                SqlDataReader drCurso = cmdCurso.ExecuteReader();
                while (drCurso.Read())
                {
                    return true;
                }
                drCurso.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar plan", Ex);
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

                SqlCommand cmdDelete = new SqlCommand("delete planes where id_plan=@id", sqlconn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        protected void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("update planes set desc_plan = @desc_plan, " +
                    "id_especialidad = @id_especialidad where id_plan = @id", sqlconn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("insert into planes (desc_plan,id_especialidad) " +
                    "values (@desc_plan,@id_especialidad) " +
                    "select @@identity", sqlconn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
                plan.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(Plan plan)
        {
            try {
                if (plan.State == BusinessEntity.States.New)
                {
                    this.Insert(plan);
                }
                else if (plan.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(plan.ID);
                }
                else if (plan.State == BusinessEntity.States.Modified)
                {
                    this.Update(plan);
                }
                plan.State = BusinessEntity.States.Unmodified;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar plan", Ex);
                throw ExcepcionManejada;
            }            
        }

        public List<Plan> GetDescripcionPlanes()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPlan = new SqlCommand("select distinct id_plan, desc_plan from planes", sqlconn);

                SqlDataReader drPlan = cmdPlan.ExecuteReader();

                while (drPlan.Read())
                {
                    Business.Entities.Plan p;
                    p = new Business.Entities.Plan();
                    p.ID = (int)drPlan["id_plan"];
                    p.Descripcion = (string)drPlan["desc_plan"];
                    planes.Add(p);
                }
                drPlan.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return planes;
        }
    }
}