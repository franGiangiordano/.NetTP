using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop.DatosReportes
{
    public partial class ReporteMaterias : Form
    {
        public ReporteMaterias()
        {
            InitializeComponent();
        }

        private void ReporteMaterias_Load(object sender, EventArgs e)
        {

            try
            {
                this.alumnos_inscripcionesTableAdapter.Connection.ConnectionString += @"Server=.\SQLEXPRESS;Initial Catalog=Academia;Integrated Security=false; User=net; Password=net;";
                this.alumnos_inscripcionesTableAdapter.FillBy1(this.DataSetUsuarios.alumnos_inscripciones);
                this.reportViewer1.RefreshReport();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear reporte");
                MessageBox.Show("Error al crear reporte");
                this.Close();
            }



            // TODO: esta línea de código carga datos en la tabla 'DataSetUsuarios.alumnos_inscripciones' Puede moverla o quitarla según sea necesario.
            // TODO: esta línea de código carga datos en la tabla 'DataSetUsuarios.materias' Puede moverla o quitarla según sea necesario.
            //this.materiasTableAdapter.Fill(this.DataSetUsuarios.materias);

        }
    }
}
