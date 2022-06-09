namespace UI.Desktop
{
    partial class MateriaDesktop
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
            this.tlMaterias = new System.Windows.Forms.TableLayoutPanel();
            this.txtHsTotales = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblHsTotales = new System.Windows.Forms.Label();
            this.lblPlan = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblHsSemanales = new System.Windows.Forms.Label();
            this.txtHsSemanales = new System.Windows.Forms.TextBox();
            this.cmbPlan = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tlMaterias.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlMaterias
            // 
            this.tlMaterias.ColumnCount = 4;
            this.tlMaterias.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlMaterias.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlMaterias.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 236F));
            this.tlMaterias.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tlMaterias.Controls.Add(this.txtHsTotales, 3, 1);
            this.tlMaterias.Controls.Add(this.lblId, 0, 0);
            this.tlMaterias.Controls.Add(this.lblDescripcion, 0, 1);
            this.tlMaterias.Controls.Add(this.lblHsTotales, 2, 1);
            this.tlMaterias.Controls.Add(this.lblPlan, 2, 2);
            this.tlMaterias.Controls.Add(this.txtId, 1, 0);
            this.tlMaterias.Controls.Add(this.txtDescripcion, 1, 1);
            this.tlMaterias.Controls.Add(this.lblHsSemanales, 2, 0);
            this.tlMaterias.Controls.Add(this.txtHsSemanales, 3, 0);
            this.tlMaterias.Controls.Add(this.cmbPlan, 3, 2);
            this.tlMaterias.Controls.Add(this.btnAceptar, 2, 3);
            this.tlMaterias.Controls.Add(this.btnCancelar, 3, 3);
            this.tlMaterias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlMaterias.Location = new System.Drawing.Point(0, 0);
            this.tlMaterias.Margin = new System.Windows.Forms.Padding(2);
            this.tlMaterias.Name = "tlMaterias";
            this.tlMaterias.RowCount = 4;
            this.tlMaterias.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlMaterias.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlMaterias.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tlMaterias.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tlMaterias.Size = new System.Drawing.Size(644, 274);
            this.tlMaterias.TabIndex = 0;
            this.tlMaterias.Paint += new System.Windows.Forms.PaintEventHandler(this.tlMaterias_Paint);
            // 
            // txtHsTotales
            // 
            this.txtHsTotales.Location = new System.Drawing.Point(482, 70);
            this.txtHsTotales.Margin = new System.Windows.Forms.Padding(2);
            this.txtHsTotales.Name = "txtHsTotales";
            this.txtHsTotales.Size = new System.Drawing.Size(76, 20);
            this.txtHsTotales.TabIndex = 8;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(2, 0);
            this.lblId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID";
            this.lblId.Visible = false;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(2, 68);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblHsTotales
            // 
            this.lblHsTotales.AutoSize = true;
            this.lblHsTotales.Location = new System.Drawing.Point(246, 68);
            this.lblHsTotales.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHsTotales.Name = "lblHsTotales";
            this.lblHsTotales.Size = new System.Drawing.Size(73, 13);
            this.lblHsTotales.TabIndex = 3;
            this.lblHsTotales.Text = "Horas Totales";
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(246, 136);
            this.lblPlan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(28, 13);
            this.lblPlan.TabIndex = 4;
            this.lblPlan.Text = "Plan";
            this.lblPlan.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(124, 2);
            this.txtId.Margin = new System.Windows.Forms.Padding(2);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(76, 20);
            this.txtId.TabIndex = 5;
            this.txtId.Visible = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(124, 70);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(76, 20);
            this.txtDescripcion.TabIndex = 6;
            // 
            // lblHsSemanales
            // 
            this.lblHsSemanales.AutoSize = true;
            this.lblHsSemanales.Location = new System.Drawing.Point(246, 0);
            this.lblHsSemanales.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHsSemanales.Name = "lblHsSemanales";
            this.lblHsSemanales.Size = new System.Drawing.Size(90, 13);
            this.lblHsSemanales.TabIndex = 2;
            this.lblHsSemanales.Text = "Horas Semanales";
            // 
            // txtHsSemanales
            // 
            this.txtHsSemanales.Location = new System.Drawing.Point(482, 2);
            this.txtHsSemanales.Margin = new System.Windows.Forms.Padding(2);
            this.txtHsSemanales.Name = "txtHsSemanales";
            this.txtHsSemanales.Size = new System.Drawing.Size(76, 20);
            this.txtHsSemanales.TabIndex = 7;
            // 
            // cmbPlan
            // 
            this.cmbPlan.FormattingEnabled = true;
            this.cmbPlan.Items.AddRange(new object[] {
            "1996",
            "2008"});
            this.cmbPlan.Location = new System.Drawing.Point(482, 138);
            this.cmbPlan.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPlan.Name = "cmbPlan";
            this.cmbPlan.Size = new System.Drawing.Size(92, 21);
            this.cmbPlan.TabIndex = 9;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(246, 199);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(56, 19);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(482, 199);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(56, 19);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // MateriaDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 274);
            this.Controls.Add(this.tlMaterias);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MateriaDesktop";
            this.Text = "MateriaDesktop";
            this.Load += new System.EventHandler(this.MateriaDesktop_Load);
            this.tlMaterias.ResumeLayout(false);
            this.tlMaterias.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlMaterias;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblHsSemanales;
        private System.Windows.Forms.Label lblHsTotales;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.TextBox txtHsTotales;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtHsSemanales;
        private System.Windows.Forms.ComboBox cmbPlan;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}