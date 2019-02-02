namespace UI.Desktop
{
    partial class Cursos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cursos));
            this.tcCursos = new System.Windows.Forms.ToolStripContainer();
            this.tlCursos = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCursos = new System.Windows.Forms.DataGridView();
            this.cursoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnVerCurso = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.tsCursos = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.col0IDCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col1AnioCalendario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2Cupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col3Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4Comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col5Materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col6Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcCursos.ContentPanel.SuspendLayout();
            this.tcCursos.TopToolStripPanel.SuspendLayout();
            this.tcCursos.SuspendLayout();
            this.tlCursos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cursoBindingSource)).BeginInit();
            this.tsCursos.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcCursos
            // 
            // 
            // tcCursos.ContentPanel
            // 
            this.tcCursos.ContentPanel.Controls.Add(this.tlCursos);
            this.tcCursos.ContentPanel.Size = new System.Drawing.Size(750, 436);
            this.tcCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCursos.Location = new System.Drawing.Point(0, 0);
            this.tcCursos.Name = "tcCursos";
            this.tcCursos.Size = new System.Drawing.Size(750, 461);
            this.tcCursos.TabIndex = 0;
            this.tcCursos.Text = "toolStripContainer1";
            // 
            // tcCursos.TopToolStripPanel
            // 
            this.tcCursos.TopToolStripPanel.Controls.Add(this.tsCursos);
            // 
            // tlCursos
            // 
            this.tlCursos.ColumnCount = 3;
            this.tlCursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlCursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlCursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlCursos.Controls.Add(this.dgvCursos, 0, 0);
            this.tlCursos.Controls.Add(this.btnSalir, 2, 1);
            this.tlCursos.Controls.Add(this.btnVerCurso, 0, 1);
            this.tlCursos.Controls.Add(this.btnActualizar, 1, 1);
            this.tlCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlCursos.Location = new System.Drawing.Point(0, 0);
            this.tlCursos.Name = "tlCursos";
            this.tlCursos.RowCount = 2;
            this.tlCursos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlCursos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlCursos.Size = new System.Drawing.Size(750, 436);
            this.tlCursos.TabIndex = 0;
            // 
            // dgvCursos
            // 
            this.dgvCursos.AllowUserToAddRows = false;
            this.dgvCursos.AllowUserToDeleteRows = false;
            this.dgvCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col0IDCurso,
            this.col1AnioCalendario,
            this.col2Cupo,
            this.col3Descripcion,
            this.col4Comision,
            this.col5Materia,
            this.col6Estado});
            this.tlCursos.SetColumnSpan(this.dgvCursos, 3);
            this.dgvCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCursos.Location = new System.Drawing.Point(3, 3);
            this.dgvCursos.MultiSelect = false;
            this.dgvCursos.Name = "dgvCursos";
            this.dgvCursos.ReadOnly = true;
            this.dgvCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCursos.Size = new System.Drawing.Size(744, 401);
            this.dgvCursos.TabIndex = 0;
            // 
            // cursoBindingSource
            // 
            this.cursoBindingSource.DataSource = typeof(Business.Entities.Curso);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(672, 410);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
            // 
            // btnVerCurso
            // 
            this.btnVerCurso.Enabled = false;
            this.btnVerCurso.Location = new System.Drawing.Point(3, 410);
            this.btnVerCurso.Name = "btnVerCurso";
            this.btnVerCurso.Size = new System.Drawing.Size(79, 23);
            this.btnVerCurso.TabIndex = 3;
            this.btnVerCurso.Text = "Ver Curso";
            this.btnVerCurso.UseVisualStyleBackColor = true;
            this.btnVerCurso.Visible = false;
            this.btnVerCurso.Click += new System.EventHandler(this.btnVerCurso_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(591, 410);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click_1);
            // 
            // tsCursos
            // 
            this.tsCursos.Dock = System.Windows.Forms.DockStyle.None;
            this.tsCursos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsCursos.Location = new System.Drawing.Point(3, 0);
            this.tsCursos.Name = "tsCursos";
            this.tsCursos.Size = new System.Drawing.Size(81, 25);
            this.tsCursos.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevo.Text = "toolStripButton1";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(23, 22);
            this.tsbEditar.Text = "toolStripButton2";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.Text = "toolStripButton3";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // col0IDCurso
            // 
            this.col0IDCurso.HeaderText = "IDCurso";
            this.col0IDCurso.Name = "col0IDCurso";
            this.col0IDCurso.ReadOnly = true;
            this.col0IDCurso.Visible = false;
            // 
            // col1AnioCalendario
            // 
            this.col1AnioCalendario.HeaderText = "Año Calendario";
            this.col1AnioCalendario.Name = "col1AnioCalendario";
            this.col1AnioCalendario.ReadOnly = true;
            // 
            // col2Cupo
            // 
            this.col2Cupo.HeaderText = "Cupo";
            this.col2Cupo.Name = "col2Cupo";
            this.col2Cupo.ReadOnly = true;
            // 
            // col3Descripcion
            // 
            this.col3Descripcion.HeaderText = "Descripcion";
            this.col3Descripcion.Name = "col3Descripcion";
            this.col3Descripcion.ReadOnly = true;
            // 
            // col4Comision
            // 
            this.col4Comision.HeaderText = "Comision";
            this.col4Comision.Name = "col4Comision";
            this.col4Comision.ReadOnly = true;
            // 
            // col5Materia
            // 
            this.col5Materia.HeaderText = "Materia";
            this.col5Materia.Name = "col5Materia";
            this.col5Materia.ReadOnly = true;
            // 
            // col6Estado
            // 
            this.col6Estado.HeaderText = "Estado";
            this.col6Estado.Name = "col6Estado";
            this.col6Estado.ReadOnly = true;
            // 
            // Cursos
            // 
            this.ClientSize = new System.Drawing.Size(750, 461);
            this.Controls.Add(this.tcCursos);
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "Cursos";
            this.Load += new System.EventHandler(this.Cursos_Load);
            this.tcCursos.ContentPanel.ResumeLayout(false);
            this.tcCursos.TopToolStripPanel.ResumeLayout(false);
            this.tcCursos.TopToolStripPanel.PerformLayout();
            this.tcCursos.ResumeLayout(false);
            this.tcCursos.PerformLayout();
            this.tlCursos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cursoBindingSource)).EndInit();
            this.tsCursos.ResumeLayout(false);
            this.tsCursos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcCursos;
        private System.Windows.Forms.TableLayoutPanel tlCursos;
        private System.Windows.Forms.DataGridView dgvCursos;
        private System.Windows.Forms.ToolStrip tsCursos;
        private System.Windows.Forms.BindingSource cursoBindingSource;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.Button btnVerCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn col0IDCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1AnioCalendario;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2Cupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col3Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn col4Comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn col5Materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn col6Estado;
    }
}
