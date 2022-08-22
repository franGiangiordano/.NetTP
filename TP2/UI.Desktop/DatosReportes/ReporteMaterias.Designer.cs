
namespace UI.Desktop.DatosReportes
{
    partial class ReporteMaterias
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.alumnosinscripcionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetUsuarios = new UI.Desktop.DatosReportes.DataSetUsuarios();
            this.materiasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.alumnos_inscripcionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.alumnos_inscripcionesTableAdapter = new UI.Desktop.DatosReportes.DataSetUsuariosTableAdapters.alumnos_inscripcionesTableAdapter();
            this.materiasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materiasTableAdapter = new UI.Desktop.DatosReportes.DataSetUsuariosTableAdapters.materiasTableAdapter();
            this.dataSetUsuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.alumnosinscripcionesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.alumnosinscripcionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiasBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alumnos_inscripcionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetUsuariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alumnosinscripcionesBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.alumnosinscripcionesBindingSource1;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.materiasBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Desktop.DatosReportes.InformeMaterias.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // alumnosinscripcionesBindingSource
            // 
            this.alumnosinscripcionesBindingSource.DataMember = "alumnos_inscripciones";
            this.alumnosinscripcionesBindingSource.DataSource = this.DataSetUsuarios;
            // 
            // DataSetUsuarios
            // 
            this.DataSetUsuarios.DataSetName = "DataSetUsuarios";
            this.DataSetUsuarios.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // materiasBindingSource1
            // 
            this.materiasBindingSource1.DataMember = "materias";
            this.materiasBindingSource1.DataSource = this.DataSetUsuarios;
            // 
            // alumnos_inscripcionesBindingSource
            // 
            this.alumnos_inscripcionesBindingSource.DataMember = "alumnos_inscripciones";
            this.alumnos_inscripcionesBindingSource.DataSource = this.DataSetUsuarios;
            // 
            // alumnos_inscripcionesTableAdapter
            // 
            this.alumnos_inscripcionesTableAdapter.ClearBeforeFill = true;
            // 
            // materiasBindingSource
            // 
            this.materiasBindingSource.DataMember = "materias";
            this.materiasBindingSource.DataSource = this.DataSetUsuarios;
            // 
            // materiasTableAdapter
            // 
            this.materiasTableAdapter.ClearBeforeFill = true;
            // 
            // dataSetUsuariosBindingSource
            // 
            this.dataSetUsuariosBindingSource.DataSource = this.DataSetUsuarios;
            this.dataSetUsuariosBindingSource.Position = 0;
            // 
            // alumnosinscripcionesBindingSource1
            // 
            this.alumnosinscripcionesBindingSource1.DataMember = "alumnos_inscripciones";
            this.alumnosinscripcionesBindingSource1.DataSource = this.dataSetUsuariosBindingSource;
            // 
            // ReporteMaterias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteMaterias";
            this.Text = "ReporteMaterias";
            this.Load += new System.EventHandler(this.ReporteMaterias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.alumnosinscripcionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiasBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alumnos_inscripcionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetUsuariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alumnosinscripcionesBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource alumnos_inscripcionesBindingSource;
        private DataSetUsuarios DataSetUsuarios;
        private System.Windows.Forms.BindingSource materiasBindingSource;
        private DataSetUsuariosTableAdapters.alumnos_inscripcionesTableAdapter alumnos_inscripcionesTableAdapter;
        private DataSetUsuariosTableAdapters.materiasTableAdapter materiasTableAdapter;
        private System.Windows.Forms.BindingSource alumnosinscripcionesBindingSource;
        private System.Windows.Forms.BindingSource materiasBindingSource1;
        private System.Windows.Forms.BindingSource alumnosinscripcionesBindingSource1;
        private System.Windows.Forms.BindingSource dataSetUsuariosBindingSource;
    }
}