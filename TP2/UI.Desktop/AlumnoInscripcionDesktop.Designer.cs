namespace UI.Desktop
{
    partial class AlumnoInscripcionDesktop
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtID = new System.Windows.Forms.Label();
            this.lbCurso = new System.Windows.Forms.Label();
            this.lbComision = new System.Windows.Forms.Label();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.cmbComision = new System.Windows.Forms.ComboBox();
            this.txtIDInscripcion = new System.Windows.Forms.TextBox();
            this.cmbCondicion = new System.Windows.Forms.ComboBox();
            this.lblCondicion = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.37653F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.62347F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel1.Controls.Add(this.txtID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbCurso, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbComision, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbMateria, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbComision, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtIDInscripcion, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbCondicion, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCondicion, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 2, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(726, 406);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtID
            // 
            this.txtID.AutoSize = true;
            this.txtID.Location = new System.Drawing.Point(3, 0);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(72, 13);
            this.txtID.TabIndex = 0;
            this.txtID.Text = "ID Inscripcion";
            // 
            // lbCurso
            // 
            this.lbCurso.AutoSize = true;
            this.lbCurso.Location = new System.Drawing.Point(3, 92);
            this.lbCurso.Name = "lbCurso";
            this.lbCurso.Size = new System.Drawing.Size(42, 13);
            this.lbCurso.TabIndex = 1;
            this.lbCurso.Text = "Materia";
            // 
            // lbComision
            // 
            this.lbComision.AutoSize = true;
            this.lbComision.Location = new System.Drawing.Point(3, 211);
            this.lbComision.Name = "lbComision";
            this.lbComision.Size = new System.Drawing.Size(49, 13);
            this.lbComision.TabIndex = 2;
            this.lbComision.Text = "Comision";
            // 
            // cmbMateria
            // 
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(156, 95);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(121, 21);
            this.cmbMateria.TabIndex = 3;
            // 
            // cmbComision
            // 
            this.cmbComision.FormattingEnabled = true;
            this.cmbComision.Location = new System.Drawing.Point(156, 214);
            this.cmbComision.Name = "cmbComision";
            this.cmbComision.Size = new System.Drawing.Size(121, 21);
            this.cmbComision.TabIndex = 4;
            // 
            // txtIDInscripcion
            // 
            this.txtIDInscripcion.Location = new System.Drawing.Point(156, 3);
            this.txtIDInscripcion.Name = "txtIDInscripcion";
            this.txtIDInscripcion.ReadOnly = true;
            this.txtIDInscripcion.Size = new System.Drawing.Size(100, 20);
            this.txtIDInscripcion.TabIndex = 5;
            // 
            // cmbCondicion
            // 
            this.cmbCondicion.FormattingEnabled = true;
            this.cmbCondicion.Items.AddRange(new object[] {
            "Inscripto",
            "Regular",
            "Aprobado",
            "Libre"});
            this.cmbCondicion.Location = new System.Drawing.Point(580, 95);
            this.cmbCondicion.Name = "cmbCondicion";
            this.cmbCondicion.Size = new System.Drawing.Size(121, 21);
            this.cmbCondicion.TabIndex = 8;
            // 
            // lblCondicion
            // 
            this.lblCondicion.AutoSize = true;
            this.lblCondicion.Location = new System.Drawing.Point(437, 92);
            this.lblCondicion.Name = "lblCondicion";
            this.lblCondicion.Size = new System.Drawing.Size(54, 13);
            this.lblCondicion.TabIndex = 9;
            this.lblCondicion.Text = "Condicion";
            this.lblCondicion.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(156, 353);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.bntAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(437, 353);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // AlumnoInscripcionDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AlumnoInscripcionDesktop";
            this.Text = "AlumnoInscripcionDesktop";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label txtID;
        private System.Windows.Forms.Label lbCurso;
        private System.Windows.Forms.Label lbComision;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.ComboBox cmbComision;
        private System.Windows.Forms.TextBox txtIDInscripcion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbCondicion;
        private System.Windows.Forms.Label lblCondicion;
    }
}