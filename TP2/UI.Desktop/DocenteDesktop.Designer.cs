namespace UI.Desktop
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
            this.cmbDocente = new System.Windows.Forms.ComboBox();
            this.cmbCargo = new System.Windows.Forms.ComboBox();
            this.lblNomApe1 = new System.Windows.Forms.Label();
            this.lblNomApe2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cmbDocente2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbDocente
            // 
            this.cmbDocente.FormattingEnabled = true;
            this.cmbDocente.Location = new System.Drawing.Point(50, 75);
            this.cmbDocente.Name = "cmbDocente";
            this.cmbDocente.Size = new System.Drawing.Size(150, 21);
            this.cmbDocente.TabIndex = 1;
            this.cmbDocente.SelectedIndexChanged += new System.EventHandler(this.cmbDocente_SelectedIndexChanged);
            // 
            // cmbCargo
            // 
            this.cmbCargo.FormattingEnabled = true;
            this.cmbCargo.Items.AddRange(new object[] {
            "Ayudante",
            "Profesor",
            "Jefe_de_TP"});
            this.cmbCargo.Location = new System.Drawing.Point(400, 75);
            this.cmbCargo.Name = "cmbCargo";
            this.cmbCargo.Size = new System.Drawing.Size(150, 21);
            this.cmbCargo.TabIndex = 2;
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Ayudante",
            "Profesor",
            "Jefe_de_TP"});
            this.comboBox1.Location = new System.Drawing.Point(400, 129);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 21);
            this.comboBox1.TabIndex = 5;
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
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.cmbDocente2);
            this.Controls.Add(this.lblNomApe1);
            this.Controls.Add(this.cmbCargo);
            this.Controls.Add(this.cmbDocente);
            this.Name = "DocenteDesktop";
            this.Text = "DocenteDesktop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbDocente;
        private System.Windows.Forms.ComboBox cmbCargo;
        private System.Windows.Forms.Label lblNomApe1;
        private System.Windows.Forms.Label lblNomApe2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cmbDocente2;
    }
}