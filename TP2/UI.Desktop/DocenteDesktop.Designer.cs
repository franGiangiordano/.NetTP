
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
            this.SuspendLayout();
            // 
            // cmbDocente1
            // 
            this.cmbDocente1.FormattingEnabled = true;
            this.cmbDocente1.Location = new System.Drawing.Point(50, 75);
            this.cmbDocente1.Name = "cmbDocente1";
            this.cmbDocente1.Size = new System.Drawing.Size(150, 21);
            this.cmbDocente1.TabIndex = 1;
            this.cmbDocente1.SelectedIndexChanged += new System.EventHandler(this.cmbDocente1_SelectedIndexChanged);
            // 
            // cmbCargo1
            // 
            this.cmbCargo1.FormattingEnabled = true;
            this.cmbCargo1.Items.AddRange(new object[] {
            "Ayudante",
            "Profesor",
            "Jefe_de_TP"});
            this.cmbCargo1.Location = new System.Drawing.Point(400, 75);
            this.cmbCargo1.Name = "cmbCargo1";
            this.cmbCargo1.Size = new System.Drawing.Size(150, 21);
            this.cmbCargo1.TabIndex = 2;
            // 
            // lblNomApe1
            // 
            this.lblNomApe1.AutoSize = true;
            this.lblNomApe1.Location = new System.Drawing.Point(228, 78);
            this.lblNomApe1.Name = "lblNomApe1";
            this.lblNomApe1.Size = new System.Drawing.Size(35, 13);
            this.lblNomApe1.TabIndex = 3;
            this.lblNomApe1.Text = "label1";
            // 
            // lblNomApe2
            // 
            this.lblNomApe2.AutoSize = true;
            this.lblNomApe2.Location = new System.Drawing.Point(228, 132);
            this.lblNomApe2.Name = "lblNomApe2";
            this.lblNomApe2.Size = new System.Drawing.Size(35, 13);
            this.lblNomApe2.TabIndex = 6;
            this.lblNomApe2.Text = "label1";
            // 
            // cmbCargo2
            // 
            this.cmbCargo2.FormattingEnabled = true;
            this.cmbCargo2.Items.AddRange(new object[] {
            "Ayudante",
            "Profesor",
            "Jefe_de_TP"});
            this.cmbCargo2.Location = new System.Drawing.Point(400, 129);
            this.cmbCargo2.Name = "cmbCargo2";
            this.cmbCargo2.Size = new System.Drawing.Size(150, 21);
            this.cmbCargo2.TabIndex = 5;
            // 
            // cmbDocente2
            // 
            this.cmbDocente2.FormattingEnabled = true;
            this.cmbDocente2.Location = new System.Drawing.Point(50, 129);
            this.cmbDocente2.Name = "cmbDocente2";
            this.cmbDocente2.Size = new System.Drawing.Size(150, 21);
            this.cmbDocente2.TabIndex = 4;
            this.cmbDocente2.SelectedIndexChanged += new System.EventHandler(this.cmbDocente2_SelectedIndexChanged);
            // 
            // DocenteDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}