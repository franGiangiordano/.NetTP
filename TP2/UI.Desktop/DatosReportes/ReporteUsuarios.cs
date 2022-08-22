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
    public partial class ReporteUsuarios : Form
    {
        public ReporteUsuarios()
        {
            InitializeComponent();
        }

        public ReporteUsuarios(int idPersona)
        {
            InitializeComponent();
        }

        private void ReporteUsuarios_Load(object sender, EventArgs e)
        {
            //Aca definimos el string que usa el dataSet
            // TODO: esta línea de código carga datos en la tabla 'dataSetUsuarios.usuarios1' Puede moverla o quitarla según sea necesario.
           try
            {
                this.usuarios1TableAdapter.Connection.ConnectionString += @"Server=.\SQLEXPRESS;Initial Catalog=Academia;Integrated Security=false; User=net; Password=net;";
                this.usuarios1TableAdapter.FillBy(this.dataSetUsuarios.usuarios1);

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear reporte");
                MessageBox.Show("Error al crear reporte");
                this.Close();
            }

            // TODO: esta línea de código carga datos en la tabla 'dataSetUsuarios.usuarios' Puede moverla o quitarla según sea necesario.
            //this.usuariosTableAdapter.Fill(this.dataSetUsuarios.usuarios);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
