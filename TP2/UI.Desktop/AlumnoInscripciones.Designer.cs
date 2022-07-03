namespace UI.Desktop
{
    partial class AlumnoInscripciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlumnoInscripciones));
            this.tcAlumosInscripciones = new System.Windows.Forms.ToolStripContainer();
            this.tlAlumnosInscripciones = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAlumnosInscripciones = new System.Windows.Forms.DataGridView();
            this.id_inscripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_alumno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_curso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tscAlumnosInscripciones = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tcAlumosInscripciones.ContentPanel.SuspendLayout();
            this.tcAlumosInscripciones.TopToolStripPanel.SuspendLayout();
            this.tcAlumosInscripciones.SuspendLayout();
            this.tlAlumnosInscripciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosInscripciones)).BeginInit();
            this.tscAlumnosInscripciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcAlumosInscripciones
            // 
            // 
            // tcAlumosInscripciones.ContentPanel
            // 
            this.tcAlumosInscripciones.ContentPanel.Controls.Add(this.tlAlumnosInscripciones);
            this.tcAlumosInscripciones.ContentPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tcAlumosInscripciones.ContentPanel.Size = new System.Drawing.Size(1067, 523);
            this.tcAlumosInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcAlumosInscripciones.Location = new System.Drawing.Point(0, 0);
            this.tcAlumosInscripciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tcAlumosInscripciones.Name = "tcAlumosInscripciones";
            this.tcAlumosInscripciones.Size = new System.Drawing.Size(1067, 554);
            this.tcAlumosInscripciones.TabIndex = 0;
            this.tcAlumosInscripciones.Text = "toolStripContainer1";
            // 
            // tcAlumosInscripciones.TopToolStripPanel
            // 
            this.tcAlumosInscripciones.TopToolStripPanel.Controls.Add(this.tscAlumnosInscripciones);
            // 
            // tlAlumnosInscripciones
            // 
            this.tlAlumnosInscripciones.ColumnCount = 2;
            this.tlAlumnosInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAlumnosInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlAlumnosInscripciones.Controls.Add(this.dgvAlumnosInscripciones, 0, 0);
            this.tlAlumnosInscripciones.Controls.Add(this.btnActualizar, 0, 1);
            this.tlAlumnosInscripciones.Controls.Add(this.btnSalir, 1, 1);
            this.tlAlumnosInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlAlumnosInscripciones.Location = new System.Drawing.Point(0, 0);
            this.tlAlumnosInscripciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlAlumnosInscripciones.Name = "tlAlumnosInscripciones";
            this.tlAlumnosInscripciones.RowCount = 2;
            this.tlAlumnosInscripciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAlumnosInscripciones.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlAlumnosInscripciones.Size = new System.Drawing.Size(1067, 523);
            this.tlAlumnosInscripciones.TabIndex = 0;
            // 
            // dgvAlumnosInscripciones
            // 
            this.dgvAlumnosInscripciones.AllowUserToAddRows = false;
            this.dgvAlumnosInscripciones.AllowUserToDeleteRows = false;
            this.dgvAlumnosInscripciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnosInscripciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_inscripcion,
            this.id_alumno,
            this.id_curso,
            this.condicion,
            this.nota,
            this.anio,
            this.materia,
            this.Comision,
            this.Especialidad});
            this.tlAlumnosInscripciones.SetColumnSpan(this.dgvAlumnosInscripciones, 2);
            this.dgvAlumnosInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlumnosInscripciones.Location = new System.Drawing.Point(4, 4);
            this.dgvAlumnosInscripciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvAlumnosInscripciones.Name = "dgvAlumnosInscripciones";
            this.dgvAlumnosInscripciones.ReadOnly = true;
            this.dgvAlumnosInscripciones.RowHeadersWidth = 51;
            this.dgvAlumnosInscripciones.Size = new System.Drawing.Size(1059, 479);
            this.dgvAlumnosInscripciones.TabIndex = 0;
            this.dgvAlumnosInscripciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlumnosInscripciones_CellContentClick);
            // 
            // id_inscripcion
            // 
            this.id_inscripcion.DataPropertyName = "id_inscripcion";
            this.id_inscripcion.HeaderText = "Id Inscripcion";
            this.id_inscripcion.MinimumWidth = 6;
            this.id_inscripcion.Name = "id_inscripcion";
            this.id_inscripcion.ReadOnly = true;
            this.id_inscripcion.Width = 125;
            // 
            // id_alumno
            // 
            this.id_alumno.DataPropertyName = "id_alumno";
            this.id_alumno.HeaderText = "Alumno";
            this.id_alumno.MinimumWidth = 6;
            this.id_alumno.Name = "id_alumno";
            this.id_alumno.ReadOnly = true;
            this.id_alumno.Width = 125;
            // 
            // id_curso
            // 
            this.id_curso.DataPropertyName = "id_curso";
            this.id_curso.HeaderText = "Curso";
            this.id_curso.MinimumWidth = 6;
            this.id_curso.Name = "id_curso";
            this.id_curso.ReadOnly = true;
            this.id_curso.Width = 125;
            // 
            // condicion
            // 
            this.condicion.DataPropertyName = "condicion";
            this.condicion.HeaderText = "Condicion";
            this.condicion.MinimumWidth = 6;
            this.condicion.Name = "condicion";
            this.condicion.ReadOnly = true;
            this.condicion.Width = 125;
            // 
            // nota
            // 
            this.nota.DataPropertyName = "nota";
            this.nota.HeaderText = "Nota";
            this.nota.MinimumWidth = 6;
            this.nota.Name = "nota";
            this.nota.ReadOnly = true;
            this.nota.Width = 125;
            // 
            // anio
            // 
            this.anio.DataPropertyName = "anio";
            this.anio.HeaderText = "Año";
            this.anio.MinimumWidth = 6;
            this.anio.Name = "anio";
            this.anio.ReadOnly = true;
            this.anio.Width = 125;
            // 
            // materia
            // 
            this.materia.DataPropertyName = "materia";
            this.materia.HeaderText = "Materia";
            this.materia.MinimumWidth = 6;
            this.materia.Name = "materia";
            this.materia.ReadOnly = true;
            this.materia.Width = 125;
            // 
            // Comision
            // 
            this.Comision.DataPropertyName = "comision";
            this.Comision.HeaderText = "Comision";
            this.Comision.MinimumWidth = 6;
            this.Comision.Name = "Comision";
            this.Comision.ReadOnly = true;
            this.Comision.Width = 125;
            // 
            // Especialidad
            // 
            this.Especialidad.DataPropertyName = "especialidad";
            this.Especialidad.HeaderText = "Especialidad";
            this.Especialidad.MinimumWidth = 6;
            this.Especialidad.Name = "Especialidad";
            this.Especialidad.ReadOnly = true;
            this.Especialidad.Width = 125;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(855, 491);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(100, 28);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(963, 491);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 28);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tscAlumnosInscripciones
            // 
            this.tscAlumnosInscripciones.Dock = System.Windows.Forms.DockStyle.None;
            this.tscAlumnosInscripciones.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tscAlumnosInscripciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar,
            this.toolStripLabel1});
            this.tscAlumnosInscripciones.Location = new System.Drawing.Point(4, 0);
            this.tscAlumnosInscripciones.Name = "tscAlumnosInscripciones";
            this.tscAlumnosInscripciones.Size = new System.Drawing.Size(341, 31);
            this.tscAlumnosInscripciones.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(29, 28);
            this.tsbNuevo.Text = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(29, 28);
            this.tsbEditar.Text = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(29, 28);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Arial", 10.8F);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(202, 28);
            this.toolStripLabel1.Text = "Listado de Inscripciones";
            // 
            // AlumnoInscripciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tcAlumosInscripciones);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AlumnoInscripciones";
            this.Text = "AlumnoInscripciones";
            this.tcAlumosInscripciones.ContentPanel.ResumeLayout(false);
            this.tcAlumosInscripciones.TopToolStripPanel.ResumeLayout(false);
            this.tcAlumosInscripciones.TopToolStripPanel.PerformLayout();
            this.tcAlumosInscripciones.ResumeLayout(false);
            this.tcAlumosInscripciones.PerformLayout();
            this.tlAlumnosInscripciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosInscripciones)).EndInit();
            this.tscAlumnosInscripciones.ResumeLayout(false);
            this.tscAlumnosInscripciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcAlumosInscripciones;
        private System.Windows.Forms.TableLayoutPanel tlAlumnosInscripciones;
        private System.Windows.Forms.DataGridView dgvAlumnosInscripciones;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip tscAlumnosInscripciones;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_inscripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_alumno;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_curso;
        private System.Windows.Forms.DataGridViewTextBoxColumn condicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nota;
        private System.Windows.Forms.DataGridViewTextBoxColumn anio;
        private System.Windows.Forms.DataGridViewTextBoxColumn materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn Especialidad;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}