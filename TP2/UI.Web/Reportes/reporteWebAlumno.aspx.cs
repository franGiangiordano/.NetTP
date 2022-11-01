using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Reportes
{
    public partial class reporteWebAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "select* from alumnos_inscripciones ai join cursos cu on ai.id_curso = cu.id_curso  join materias m on m.id_materia = cu.id_materia join comisiones com on cu.id_comision = com.id_comision where ai.id_alumno = " + Session["idPersona"].ToString() + ";";
            
            
        }
    }
}