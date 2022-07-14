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
    internal class DocenteCursoAdapter: Adapter
    {
        public List<DocenteCurso> GetDocentesCurso(int idCurso)
        {
            List<DocenteCurso> personas = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select p.id_persona, p.nombre, p.apellido, p.legajo, c.cargo from personas p join docentes_cursos c on p.id_persona = c.id_docente where c.id_curso = @idCurso  ", sqlconn);
                cmdPersonas.Parameters.Add("@idCurso", SqlDbType.Int).Value = idCurso;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Business.Entities.DocenteCurso per;
                    per = new Business.Entities.DocenteCurso();
                    per.ID = (int)drPersonas["id_persona"];
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
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


            return personas; //llamar a open , hacer select, exeecute reader

        }
    }

}
