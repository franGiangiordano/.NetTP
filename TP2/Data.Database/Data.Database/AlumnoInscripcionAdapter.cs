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
    public class AlumnoInscripcionAdapter: Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdInscripciones = new SqlCommand("select * from alumnos_inscripciones", sqlconn);

                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();

                while (drInscripciones.Read())
                {
                    Business.Entities.AlumnoInscripcion ins;
                    ins = new Business.Entities.AlumnoInscripcion();
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.IDAlumno = (int)drInscripciones["id_alumno"]; ;
                    ins.IDCurso = (int)drInscripciones["id_curso"];
                    ins.Condicion = (string)drInscripciones["condicion"];


                    if (!drInscripciones.IsDBNull(4)) {
                        ins.Nota = (int)drInscripciones["nota"];
                    }
                    else {
                        ins.Nota = -1;
                    }
                                                                
                    inscripciones.Add(ins);
                }
                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return inscripciones; 
        }

        public Business.Entities.AlumnoInscripcion GetOne(int ID)
        {
            Business.Entities.AlumnoInscripcion ins;
            ins = new Business.Entities.AlumnoInscripcion();
            try
            {
                this.OpenConnection();

                SqlCommand cmdInscripciones = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion=@id", sqlconn);
                cmdInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();

                if (drInscripciones.Read())
                {
                    ins = new Business.Entities.AlumnoInscripcion();
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.IDAlumno = (int)drInscripciones["id_alumno"]; ;
                    ins.IDCurso = (int)drInscripciones["id_curso"];
                    ins.Condicion = (string)drInscripciones["condicion"];
                    
                    if (!drInscripciones.IsDBNull(4))
                    {
                        ins.Nota = (int)drInscripciones["nota"];
                    }
                    else
                    {
                        ins.Nota = -1;
                    }
                }
                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return ins;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete alumnos_inscripciones where id_inscripcion=@id", sqlconn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        protected void Update(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("update alumnos_inscripciones set id_alumno = @id_alumno, " +
                    "id_curso = @id_curso, condicion = @condicion, nota = @nota where id_inscripcion = @id", sqlconn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = inscripcion.ID;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int, 50).Value = inscripcion.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int, 50).Value = inscripcion.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar).Value = inscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int, 50).Value = inscripcion.Nota;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(AlumnoInscripcion inscripcion)
        {
                try
                {
                    this.OpenConnection();

                    SqlCommand cmdSave = new SqlCommand("insert into alumnos_inscripciones (id_alumno,id_curso,condicion) " +
                        "values (@id_alumno,@id_curso,@condicion) " +
                        "select @@identity", sqlconn);
                    cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = inscripcion.ID;
                    cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int, 50).Value = inscripcion.IDAlumno;
                    cmdSave.Parameters.Add("@id_curso", SqlDbType.Int, 50).Value = inscripcion.IDCurso;
                    cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar).Value = inscripcion.Condicion;
                   // cmdSave.Parameters.Add("@nota", SqlDbType.Int, 50).Value = inscripcion.Nota;
                   //Siempre que se de alta una inscripcion no se deberia incluir la nota
                    inscripcion.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al crear inscripcion", Ex);
                    throw ExcepcionManejada;
                }
                finally
                {
                    this.CloseConnection();
                }

        }

        public void Save(AlumnoInscripcion inscripcion)
        {
            if (inscripcion.State == BusinessEntity.States.New)
            {
                this.Insert(inscripcion);
            }
            else if (inscripcion.State == BusinessEntity.States.Deleted)
            {
                this.Delete(inscripcion.ID);
            }
            else if (inscripcion.State == BusinessEntity.States.Modified)
            {
                this.Update(inscripcion);
            }
            inscripcion.State = BusinessEntity.States.Unmodified;
        }

        
    }
}
