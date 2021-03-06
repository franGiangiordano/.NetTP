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
            this.lbCurso = new System.Windows.Forms.Label();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.lbComision = new System.Windows.Forms.Label();
            this.cmbComision = new System.Windows.Forms.ComboBox();
            this.cmbLegajo = new System.Windows.Forms.ComboBox();
            this.lblLegajo = new System.Windows.Forms.Label();
            this.lblCondicion = new System.Windows.Forms.Label();
            this.cmbCondicion = new System.Windows.Forms.ComboBox();
            this.lblNota = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.Label();
            this.txtIDInscripcion = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.97015F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.02985F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.37653F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.62347F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.lbCurso, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbMateria, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbComision, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbComision, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbLegajo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLegajo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCondicion, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbCondicion, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNota, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNota, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtIDInscripcion, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(570, 209);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // lbCurso
            // 
            this.lbCurso.AutoSize = true;
            this.lbCurso.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lbCurso.Location = new System.Drawing.Point(3, 0);
            this.lbCurso.Name = "lbCurso";
            this.lbCurso.Size = new System.Drawing.Size(55, 17);
            this.lbCurso.TabIndex = 1;
            this.lbCurso.Text = "Materia";
            // 
            // cmbMateria
            // 
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(92, 3);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(121, 21);
            this.cmbMateria.TabIndex = 3;
            // 
            // lbComision
            // 
            this.lbComision.AutoSize = true;
            this.lbComision.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lbComision.Location = new System.Drawing.Point(3, 48);
            this.lbComision.Name = "lbComision";
            this.lbComision.Size = new System.Drawing.Size(62, 17);
            this.lbComision.TabIndex = 2;
            this.lbComision.Text = "Comision";
            // 
            // cmbComision
            // 
            this.cmbComision.FormattingEnabled = true;
            this.cmbComision.Location = new System.Drawing.Point(92, 51);
            this.cmbComision.Name = "cmbComision";
            this.cmbComision.Size = new System.Drawing.Size(121, 21);
            this.cmbComision.TabIndex = 4;
            // 
            // cmbLegajo
            // 
            this.cmbLegajo.FormattingEnabled = true;
            this.cmbLegajo.Location = new System.Drawing.Point(92, 103);
            this.cmbLegajo.Name = "cmbLegajo";
            this.cmbLegajo.Size = new System.Drawing.Size(121, 21);
            this.cmbLegajo.TabIndex = 13;
            // 
            // lblLegajo
            // 
            this.lblLegajo.AutoSize = true;
            this.lblLegajo.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblLegajo.Location = new System.Drawing.Point(3, 100);
            this.lblLegajo.Name = "lblLegajo";
            this.lblLegajo.Size = new System.Drawing.Size(49, 17);
            this.lblLegajo.TabIndex = 12;
            this.lblLegajo.Text = "Legajo";
            // 
            // lblCondicion
            // 
            this.lblCondicion.AutoSize = true;
            this.lblCondicion.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblCondicion.Location = new System.Drawing.Point(291, 0);
            this.lblCondicion.Name = "lblCondicion";
            this.lblCondicion.Size = new System.Drawing.Size(69, 17);
            this.lblCondicion.TabIndex = 9;
            this.lblCondicion.Text = "Condicion";
            this.lblCondicion.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbCondicion
            // 
            this.cmbCondicion.FormattingEnabled = true;
            this.cmbCondicion.Items.AddRange(new object[] {
            "Regular",
            "Aprobado",
            "Libre"});
            this.cmbCondicion.Location = new System.Drawing.Point(422, 3);
            this.cmbCondicion.Name = "cmbCondicion";
            this.cmbCondicion.Size = new System.Drawing.Size(114, 21);
            this.cmbCondicion.TabIndex = 8;
            // 
            // lblNota
            // 
            this.lblNota.AutoSize = true;
            this.lblNota.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblNota.Location = new System.Drawing.Point(291, 48);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(38, 17);
            this.lblNota.TabIndex = 10;
            this.lblNota.Text = "Nota";
            // 
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(422, 51);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(114, 20);
            this.txtNota.TabIndex = 11;
            // 
            // txtID
            // 
            this.txtID.AutoSize = true;
            this.txtID.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.txtID.Location = new System.Drawing.Point(291, 100);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(87, 17);
            this.txtID.TabIndex = 0;
            this.txtID.Text = "ID Inscripcion";
            this.txtID.Visible = false;
            // 
            // txtIDInscripcion
            // 
            this.txtIDInscripcion.Location = new System.Drawing.Point(422, 103);
            this.txtIDInscripcion.Name = "txtIDInscripcion";
            this.txtIDInscripcion.ReadOnly = true;
            this.txtIDInscripcion.Size = new System.Drawing.Size(114, 20);
            this.txtIDInscripcion.TabIndex = 5;
            this.txtIDInscripcion.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(291, 157);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 26);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Location = new System.Drawing.Point(92, 157);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(80, 26);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.bntAceptar_Click);
            // 
            // AlumnoInscripcionDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 228);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AlumnoInscripcionDesktop";
            this.Text = "AlumnoInscripcionDesktop";
            this.Load += new System.EventHandler(this.AlumnoInscripcionDesktop_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbCurso;
        private System.Windows.Forms.Label lbComision;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.ComboBox cmbComision;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbCondicion;
        private System.Windows.Forms.Label lblCondicion;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.ComboBox cmbLegajo;
        private System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.Label txtID;
        private System.Windows.Forms.TextBox txtIDInscripcion;
    }
}