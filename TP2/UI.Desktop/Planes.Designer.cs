namespace UI.Desktop
{
    partial class Planes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Planes));
            this.tcEspecialidades = new System.Windows.Forms.ToolStripContainer();
            this.tlEspecialidades = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPlanes = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsEspecialidades = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbBorrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tcEspecialidades.ContentPanel.SuspendLayout();
            this.tcEspecialidades.TopToolStripPanel.SuspendLayout();
            this.tcEspecialidades.SuspendLayout();
            this.tlEspecialidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).BeginInit();
            this.tsEspecialidades.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcEspecialidades
            // 
            // 
            // tcEspecialidades.ContentPanel
            // 
            this.tcEspecialidades.ContentPanel.Controls.Add(this.tlEspecialidades);
            this.tcEspecialidades.ContentPanel.Margin = new System.Windows.Forms.Padding(2);
            this.tcEspecialidades.ContentPanel.Size = new System.Drawing.Size(787, 339);
            this.tcEspecialidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcEspecialidades.Location = new System.Drawing.Point(0, 0);
            this.tcEspecialidades.Margin = new System.Windows.Forms.Padding(2);
            this.tcEspecialidades.Name = "tcEspecialidades";
            this.tcEspecialidades.Size = new System.Drawing.Size(787, 366);
            this.tcEspecialidades.TabIndex = 0;
            this.tcEspecialidades.Text = "toolStripContainer1";
            // 
            // tcEspecialidades.TopToolStripPanel
            // 
            this.tcEspecialidades.TopToolStripPanel.Controls.Add(this.tsEspecialidades);
            // 
            // tlEspecialidades
            // 
            this.tlEspecialidades.ColumnCount = 2;
            this.tlEspecialidades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlEspecialidades.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlEspecialidades.Controls.Add(this.dgvPlanes, 0, 0);
            this.tlEspecialidades.Controls.Add(this.btnActualizar, 0, 1);
            this.tlEspecialidades.Controls.Add(this.btnSalir, 1, 1);
            this.tlEspecialidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlEspecialidades.Location = new System.Drawing.Point(0, 0);
            this.tlEspecialidades.Margin = new System.Windows.Forms.Padding(2);
            this.tlEspecialidades.Name = "tlEspecialidades";
            this.tlEspecialidades.RowCount = 2;
            this.tlEspecialidades.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlEspecialidades.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlEspecialidades.Size = new System.Drawing.Size(787, 339);
            this.tlEspecialidades.TabIndex = 0;
            // 
            // dgvPlanes
            // 
            this.dgvPlanes.AllowUserToAddRows = false;
            this.dgvPlanes.AllowUserToDeleteRows = false;
            this.dgvPlanes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPlanes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPlanes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(241)))));
            this.dgvPlanes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPlanes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlanes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPlanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Descripcion,
            this.Especialidad});
            this.tlEspecialidades.SetColumnSpan(this.dgvPlanes, 2);
            this.dgvPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlanes.EnableHeadersVisualStyles = false;
            this.dgvPlanes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.dgvPlanes.Location = new System.Drawing.Point(2, 2);
            this.dgvPlanes.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPlanes.MultiSelect = false;
            this.dgvPlanes.Name = "dgvPlanes";
            this.dgvPlanes.ReadOnly = true;
            this.dgvPlanes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlanes.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPlanes.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPlanes.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPlanes.RowTemplate.Height = 24;
            this.dgvPlanes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanes.Size = new System.Drawing.Size(783, 305);
            this.dgvPlanes.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 46;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 120;
            // 
            // Especialidad
            // 
            this.Especialidad.DataPropertyName = "idEspecialidad";
            this.Especialidad.HeaderText = "Especialidad";
            this.Especialidad.Name = "Especialidad";
            this.Especialidad.ReadOnly = true;
            this.Especialidad.Width = 127;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.btnActualizar.Location = new System.Drawing.Point(609, 311);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(86, 26);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.btnSalir.Location = new System.Drawing.Point(699, 311);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(86, 26);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tsEspecialidades
            // 
            this.tsEspecialidades.Dock = System.Windows.Forms.DockStyle.None;
            this.tsEspecialidades.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsEspecialidades.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbBorrar,
            this.toolStripLabel1});
            this.tsEspecialidades.Location = new System.Drawing.Point(3, 0);
            this.tsEspecialidades.Name = "tsEspecialidades";
            this.tsEspecialidades.Size = new System.Drawing.Size(208, 27);
            this.tsEspecialidades.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(24, 24);
            this.tsbNuevo.Text = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(24, 24);
            this.tsbEditar.Text = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbBorrar
            // 
            this.tsbBorrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBorrar.Image = ((System.Drawing.Image)(resources.GetObject("tsbBorrar.Image")));
            this.tsbBorrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBorrar.Name = "tsbBorrar";
            this.tsbBorrar.Size = new System.Drawing.Size(24, 24);
            this.tsbBorrar.Text = "Borrar";
            this.tsbBorrar.Click += new System.EventHandler(this.tsbBorrar_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Arial", 10.8F);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(124, 24);
            this.toolStripLabel1.Text = "Listado de Planes";
            // 
            // Planes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 366);
            this.Controls.Add(this.tcEspecialidades);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Planes";
            this.Text = "Planes";
            this.tcEspecialidades.ContentPanel.ResumeLayout(false);
            this.tcEspecialidades.TopToolStripPanel.ResumeLayout(false);
            this.tcEspecialidades.TopToolStripPanel.PerformLayout();
            this.tcEspecialidades.ResumeLayout(false);
            this.tcEspecialidades.PerformLayout();
            this.tlEspecialidades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).EndInit();
            this.tsEspecialidades.ResumeLayout(false);
            this.tsEspecialidades.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcEspecialidades;
        private System.Windows.Forms.TableLayoutPanel tlEspecialidades;
        private System.Windows.Forms.DataGridView dgvPlanes;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip tsEspecialidades;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbBorrar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Especialidad;
    }
}