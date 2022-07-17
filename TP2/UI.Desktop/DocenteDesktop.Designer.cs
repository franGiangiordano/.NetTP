
﻿namespace UI.Desktop
{
    partial class DocenteDesktop
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
            this.cmbDocente1 = new System.Windows.Forms.ComboBox();
            this.cmbCargo1 = new System.Windows.Forms.ComboBox();
            this.lblNomApe1 = new System.Windows.Forms.Label();
            this.lblNomApe2 = new System.Windows.Forms.Label();
            this.cmbCargo2 = new System.Windows.Forms.ComboBox();
            this.cmbDocente2 = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbDocente1
            // 
            this.cmbDocente1.FormattingEnabled = true;
            this.cmbDocente1.Location = new System.Drawing.Point(76, 26);
            this.cmbDocente1.Name = "cmbDocente1";
            this.cmbDocente1.Size = new System.Drawing.Size(150, 21);
            this.cmbDocente1.TabIndex = 1;
            // 
            // cmbCargo1
            // 
            this.cmbCargo1.FormattingEnabled = true;
            this.cmbCargo1.Items.AddRange(new object[] {
            "Ayudante",
            "Profesor"});
            this.cmbCargo1.Location = new System.Drawing.Point(661, 26);
            this.cmbCargo1.Name = "cmbCargo1";
            this.cmbCargo1.Size = new System.Drawing.Size(150, 21);
            this.cmbCargo1.TabIndex = 2;
            // 
            // lblNomApe1
            // 
            this.lblNomApe1.AutoSize = true;
            this.lblNomApe1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomApe1.Location = new System.Drawing.Point(393, 25);
            this.lblNomApe1.Name = "lblNomApe1";
            this.lblNomApe1.Size = new System.Drawing.Size(52, 18);
            this.lblNomApe1.TabIndex = 3;
            this.lblNomApe1.Text = "label1";
            // 
            // lblNomApe2
            // 
            this.lblNomApe2.AutoSize = true;
            this.lblNomApe2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomApe2.Location = new System.Drawing.Point(393, 83);
            this.lblNomApe2.Name = "lblNomApe2";
            this.lblNomApe2.Size = new System.Drawing.Size(52, 18);
            this.lblNomApe2.TabIndex = 6;
            this.lblNomApe2.Text = "label1";
            this.lblNomApe2.Visible = false;
            // 
            // cmbCargo2
            // 
            this.cmbCargo2.FormattingEnabled = true;
            this.cmbCargo2.Items.AddRange(new object[] {
            "Ayudante",
            "Profesor"});
            this.cmbCargo2.Location = new System.Drawing.Point(661, 82);
            this.cmbCargo2.Name = "cmbCargo2";
            this.cmbCargo2.Size = new System.Drawing.Size(150, 21);
            this.cmbCargo2.TabIndex = 5;
            this.cmbCargo2.Visible = false;
            // 
            // cmbDocente2
            // 
            this.cmbDocente2.FormattingEnabled = true;
            this.cmbDocente2.Location = new System.Drawing.Point(76, 80);
            this.cmbDocente2.Name = "cmbDocente2";
            this.cmbDocente2.Size = new System.Drawing.Size(150, 21);
            this.cmbDocente2.TabIndex = 4;
            this.cmbDocente2.Visible = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnAceptar.Location = new System.Drawing.Point(613, 153);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(80, 26);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnCancelar.Location = new System.Drawing.Point(728, 153);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 26);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(598, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Cargo";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(598, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Cargo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Legajo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Legajo";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(243, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Nombre y Apellido";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(243, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Nombre y Apellido";
            this.label6.Visible = false;
            // 
            // DocenteDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 203);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblNomApe2);
            this.Controls.Add(this.cmbCargo2);
            this.Controls.Add(this.cmbDocente2);
            this.Controls.Add(this.lblNomApe1);
            this.Controls.Add(this.cmbCargo1);
            this.Controls.Add(this.cmbDocente1);
            this.Name = "DocenteDesktop";
            this.Text = "DocenteDesktop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbDocente1;
        private System.Windows.Forms.ComboBox cmbCargo1;
        private System.Windows.Forms.Label lblNomApe1;
        private System.Windows.Forms.Label lblNomApe2;
        private System.Windows.Forms.ComboBox cmbCargo2;
        private System.Windows.Forms.ComboBox cmbDocente2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}