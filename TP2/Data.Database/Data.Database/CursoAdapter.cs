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
    public class CursoAdapter : Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("select * from cursos c join materias m on m.id_materia=c.id_materia join comisiones co on co.id_comision=c.id_comision", sqlconn);
                SqlDataReader drCurso = cmdCurso.ExecuteReader();
                while (drCurso.Read())
                {
                    Curso curso = new Curso();
                    curso.ID = (int)drCurso["id_curso"];
                    curso.IDMateria = (int)drCurso["id_materia"];
                    curso.IDComision = (int)drCurso["id_comision"];
                    curso.AnioCalendario = (int)drCurso["anio_calendario"];
                    curso.DescripcionComision = (string)drCurso["desc_comision"];
                    curso.DescripcionMateria = (string)drCurso["desc_materia"];
                    curso.Cupo = (int)drCurso["cupo"];
                    cursos.Add(curso);
                }
                drCurso.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return cursos;
        }

        public Curso GetOne(int id)
        {
            Curso curso = new Curso();
            try
            {
                OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("select * from cursos where id_curso = @id_curso", sqlconn);
                cmdCurso.Parameters.Add("@id_curso", SqlDbType.Int).Value = id;
                SqlDataReader drCurso = cmdCurso.ExecuteReader();
                while (drCurso.Read())
                {
                    curso.ID = (int)drCurso["id_curso"];
                    curso.IDMateria = (int)drCurso["id_materia"];
                    curso.IDComision = (int)drCurso["id_comision"];
                    curso.AnioCalendario = (int)drCurso["anio_calendario"];
                    curso.Cupo = (int)drCurso["cupo"];
                }
                drCurso.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return curso;
        }

        public void Delete(int id)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_curso = @id_curso", sqlconn);
                cmdDelete.Parameters.Add("@id_curso", SqlDbType.Int).Value = id;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Insert(Curso curso)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into cursos(id_materia, id_comision, anio_calendario, cupo) " +
                    "values(@id_materia, @id_comision, @anio_calendario, @cupo) select @@identity", sqlconn);
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(Curso curso)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "update cursos set id_materia = @id_materia, id_comision = @id_comision, anio_calendario = @anio_calendario, cupo = @cupo where id_curso = @id_curso", sqlconn);
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = curso.ID;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            try {
                if (curso.State == BusinessEntity.States.Deleted)
                {
                    Delete(curso.ID);
                }
                else if (curso.State == BusinessEntity.States.Modified)
                {
                    Update(curso);
                }
                else if (curso.State == BusinessEntity.States.New)
                {
                    Insert(curso);
                }
                curso.State = BusinessEntity.States.Unmodified;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }            
        }

        public Curso GetCurso(int idMat, int idCom)
        {
            Curso curso = new Curso();
            try
            {
                OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("select * from cursos where id_materia = @id_materia and id_comision = @id_comision and anio_calendario=@anio_calendario", sqlconn);
                cmdCurso.Parameters.Add("@id_materia", SqlDbType.Int).Value = idMat;
                cmdCurso.Parameters.Add("@id_comision", SqlDbType.Int).Value = idCom;
                cmdCurso.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = DateTime.Now.Year;
                SqlDataReader drCurso = cmdCurso.ExecuteReader();
                while (drCurso.Read())
                {
                    curso.ID = (int)drCurso["id_curso"];
                    curso.IDMateria = (int)drCurso["id_materia"];
                    curso.IDComision = (int)drCurso["id_comision"];
                    curso.AnioCalendario = (int)drCurso["anio_calendario"];
                    curso.Cupo = (int)drCurso["cupo"];
                }
                drCurso.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return curso;
        }

        public bool validaCursoExistente(int idMat, int idCom, int anio) {
            Curso curso = new Curso();
            try
            {
                OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("select * from cursos where id_materia = @idMat and id_comision=@idCom and anio_calendario=@anio", sqlconn);
                cmdCurso.Parameters.Add("@idMat", SqlDbType.Int).Value = idMat;
                cmdCurso.Parameters.Add("@idCom", SqlDbType.Int).Value = idCom;
                cmdCurso.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                SqlDataReader drCurso = cmdCurso.ExecuteReader();
                while (drCurso.Read())
                {
                    return true;
                }
                drCurso.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return false;


        }

    }
}