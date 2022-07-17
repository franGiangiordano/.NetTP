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
    public class DocenteCursoAdapter: Adapter
    {
        public List<DocenteCurso> GetDocentesCurso(int idCurso)
        {
            List<DocenteCurso> personas = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select c.id_dictado, p.nombre, p.apellido, p.legajo, c.cargo from personas p join docentes_cursos c on p.id_persona = c.id_docente where c.id_curso = @idCurso  ", sqlconn);
                cmdPersonas.Parameters.Add("@idCurso", SqlDbType.Int).Value = idCurso;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Business.Entities.DocenteCurso per;
                    per = new Business.Entities.DocenteCurso();
                    per.ID = (int)drPersonas["id_dictado"];
                    per.Nombre = (string)drPersonas["nombre"]; ;
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.Cargo = (DocenteCurso.TiposCargos)drPersonas["cargo"];
                    personas.Add(per);
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de docentes para el curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return personas; //llamar a open , hacer select, exeecute reader

        }

        public Business.Entities.DocenteCurso GetOne(int ID)
        {
            Business.Entities.DocenteCurso per;
            per = new Business.Entities.DocenteCurso();
            try
            {
                this.OpenConnection();

                SqlCommand cmdDocente = new SqlCommand("select * from docentes_cursos where id_dictado=@id", sqlconn);
                cmdDocente.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocente = cmdDocente.ExecuteReader();

                if (drDocente.Read())
                {
                    per.ID = (int)drDocente["id_dictado"];
                    per.IDCurso = (int)drDocente["id_curso"];
                    per.IDDocente = (int)drDocente["id_docente"];                    
                    per.Cargo = (DocenteCurso.TiposCargos)drDocente["cargo"];                    
                }
                drDocente.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return per;
        }


        protected void Insert(DocenteCurso docente)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("insert into docentes_cursos (id_curso, id_docente,cargo) " +
                    "values (@id_curso ,@id_docente,@cargo) " +
                    "select @@identity", sqlconn);
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docente.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docente.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docente.Cargo;
                docente.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al asignar docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void UpdateDocente(DocenteCurso docente)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("update docentes_cursos set " +
                    "id_docente = @id_docente, cargo = @cargo where id_dictado = @id_dictado", sqlconn);
                cmdSave.Parameters.Add("@id_dictado", SqlDbType.Int).Value = docente.ID;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docente.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docente.Cargo; 
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del docente en el curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete docentes_cursos where id_dictado=@id", sqlconn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar docente del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(DocenteCurso docente)
        {
            if (docente.State == BusinessEntity.States.New)
            {
                this.Insert(docente);
            }
            else if (docente.State == BusinessEntity.States.Deleted)
            {
                this.Delete(docente.ID);
            }
            else if (docente.State == BusinessEntity.States.Modified)
            {
                this.UpdateDocente(docente);
            }
            docente.State = BusinessEntity.States.Unmodified;
        }
    }

}
