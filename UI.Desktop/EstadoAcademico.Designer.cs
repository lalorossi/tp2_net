namespace UI.Desktop
{
    partial class EstadoAcademico
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
            this.dgvCursos = new System.Windows.Forms.DataGridView();
            this.col0IDCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col0IDComision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col1anioCalendario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2Comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col3Materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4Profesor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col5Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col6Nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col7FechaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.cbFiltroAño = new System.Windows.Forms.ComboBox();
            this.cbFiltroComision = new System.Windows.Forms.ComboBox();
            this.lblFiltros = new System.Windows.Forms.Label();
            this.chkFiltroEstado = new System.Windows.Forms.CheckBox();
            this.chkFiltroAño = new System.Windows.Forms.CheckBox();
            this.chkFiltroComison = new System.Windows.Forms.CheckBox();
            this.lblFlechaFiltro = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFiltrosAplicados = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dgvCursos, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbFiltroEstado, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSalir, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbFiltroAño, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbFiltroComision, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblFiltros, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkFiltroEstado, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkFiltroAño, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkFiltroComison, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblFlechaFiltro, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTitulo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFiltrosAplicados, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(746, 309);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvCursos
            // 
            this.dgvCursos.AllowUserToAddRows = false;
            this.dgvCursos.AllowUserToDeleteRows = false;
            this.dgvCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col0IDCurso,
            this.col0IDComision,
            this.col1anioCalendario,
            this.col2Comision,
            this.col3Materia,
            this.col4Profesor,
            this.col5Estado,
            this.col6Nota,
            this.col7FechaModificacion});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvCursos, 3);
            this.dgvCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCursos.Location = new System.Drawing.Point(3, 49);
            this.dgvCursos.Name = "dgvCursos";
            this.dgvCursos.ReadOnly = true;
            this.dgvCursos.Size = new System.Drawing.Size(754, 228);
            this.dgvCursos.TabIndex = 3;
            // 
            // col0IDCurso
            // 
            this.col0IDCurso.Frozen = true;
            this.col0IDCurso.HeaderText = "Curso";
            this.col0IDCurso.Name = "col0IDCurso";
            this.col0IDCurso.ReadOnly = true;
            this.col0IDCurso.Visible = false;
            // 
            // col0IDComision
            // 
            this.col0IDComision.HeaderText = "Comision";
            this.col0IDComision.Name = "col0IDComision";
            this.col0IDComision.ReadOnly = true;
            this.col0IDComision.Visible = false;
            // 
            // col1anioCalendario
            // 
            this.col1anioCalendario.HeaderText = "Año";
            this.col1anioCalendario.Name = "col1anioCalendario";
            this.col1anioCalendario.ReadOnly = true;
            // 
            // col2Comision
            // 
            this.col2Comision.HeaderText = "Comision";
            this.col2Comision.Name = "col2Comision";
            this.col2Comision.ReadOnly = true;
            // 
            // col3Materia
            // 
            this.col3Materia.HeaderText = "Materia";
            this.col3Materia.Name = "col3Materia";
            this.col3Materia.ReadOnly = true;
            // 
            // col4Profesor
            // 
            this.col4Profesor.HeaderText = "Profesor";
            this.col4Profesor.Name = "col4Profesor";
            this.col4Profesor.ReadOnly = true;
            // 
            // col5Estado
            // 
            this.col5Estado.HeaderText = "Condicion";
            this.col5Estado.Name = "col5Estado";
            this.col5Estado.ReadOnly = true;
            // 
            // col6Nota
            // 
            this.col6Nota.HeaderText = "Nota";
            this.col6Nota.Name = "col6Nota";
            this.col6Nota.ReadOnly = true;
            // 
            // col7FechaModificacion
            // 
            this.col7FechaModificacion.HeaderText = "Fecha de Modificación";
            this.col7FechaModificacion.Name = "col7FechaModificacion";
            this.col7FechaModificacion.ReadOnly = true;
            // 
            // cbFiltroEstado
            // 
            this.cbFiltroEstado.FormattingEnabled = true;
            this.cbFiltroEstado.Location = new System.Drawing.Point(55, 49);
            this.cbFiltroEstado.Name = "cbFiltroEstado";
            this.cbFiltroEstado.Size = new System.Drawing.Size(111, 21);
            this.cbFiltroEstado.TabIndex = 4;
            this.cbFiltroEstado.Text = "Estado Académico";
            this.cbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.cbFiltroEstado_SelectedIndexChanged);
            // 
            // btnSalir
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnSalir, 2);
            this.btnSalir.Location = new System.Drawing.Point(3, 283);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // cbFiltroAño
            // 
            this.cbFiltroAño.FormattingEnabled = true;
            this.cbFiltroAño.Location = new System.Drawing.Point(55, 49);
            this.cbFiltroAño.Name = "cbFiltroAño";
            this.cbFiltroAño.Size = new System.Drawing.Size(111, 21);
            this.cbFiltroAño.TabIndex = 5;
            this.cbFiltroAño.Text = "Año";
            this.cbFiltroAño.SelectedIndexChanged += new System.EventHandler(this.cbFiltroAño_SelectedIndexChanged);
            // 
            // cbFiltroComision
            // 
            this.cbFiltroComision.FormattingEnabled = true;
            this.cbFiltroComision.Location = new System.Drawing.Point(55, 49);
            this.cbFiltroComision.Name = "cbFiltroComision";
            this.cbFiltroComision.Size = new System.Drawing.Size(111, 21);
            this.cbFiltroComision.TabIndex = 6;
            this.cbFiltroComision.Text = "Comison";
            this.cbFiltroComision.SelectedIndexChanged += new System.EventHandler(this.cbFiltroComision_SelectedIndexChanged);
            // 
            // lblFiltros
            // 
            this.lblFiltros.AutoSize = true;
            this.lblFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltros.Location = new System.Drawing.Point(3, 29);
            this.lblFiltros.Name = "lblFiltros";
            this.lblFiltros.Size = new System.Drawing.Size(46, 17);
            this.lblFiltros.TabIndex = 0;
            this.lblFiltros.Text = "Filtros";
            // 
            // chkFiltroEstado
            // 
            this.chkFiltroEstado.AutoSize = true;
            this.chkFiltroEstado.Location = new System.Drawing.Point(3, 49);
            this.chkFiltroEstado.Name = "chkFiltroEstado";
            this.chkFiltroEstado.Size = new System.Drawing.Size(15, 1);
            this.chkFiltroEstado.TabIndex = 7;
            this.chkFiltroEstado.UseVisualStyleBackColor = true;
            this.chkFiltroEstado.CheckedChanged += new System.EventHandler(this.chkFiltroEstado_CheckedChanged);
            // 
            // chkFiltroAño
            // 
            this.chkFiltroAño.AutoSize = true;
            this.chkFiltroAño.Location = new System.Drawing.Point(3, 49);
            this.chkFiltroAño.Name = "chkFiltroAño";
            this.chkFiltroAño.Size = new System.Drawing.Size(15, 1);
            this.chkFiltroAño.TabIndex = 7;
            this.chkFiltroAño.UseVisualStyleBackColor = true;
            this.chkFiltroAño.CheckedChanged += new System.EventHandler(this.chkFiltroAño_CheckedChanged);
            // 
            // chkFiltroComison
            // 
            this.chkFiltroComison.AutoSize = true;
            this.chkFiltroComison.Location = new System.Drawing.Point(3, 49);
            this.chkFiltroComison.Name = "chkFiltroComison";
            this.chkFiltroComison.Size = new System.Drawing.Size(15, 1);
            this.chkFiltroComison.TabIndex = 7;
            this.chkFiltroComison.UseVisualStyleBackColor = true;
            this.chkFiltroComison.CheckedChanged += new System.EventHandler(this.chkFiltroComison_CheckedChanged);
            // 
            // lblFlechaFiltro
            // 
            this.lblFlechaFiltro.AutoSize = true;
            this.lblFlechaFiltro.Font = new System.Drawing.Font("Wingdings 3", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblFlechaFiltro.Location = new System.Drawing.Point(55, 29);
            this.lblFlechaFiltro.Name = "lblFlechaFiltro";
            this.lblFlechaFiltro.Size = new System.Drawing.Size(20, 15);
            this.lblFlechaFiltro.TabIndex = 0;
            this.lblFlechaFiltro.Text = "q";
            this.lblFlechaFiltro.Click += new System.EventHandler(this.lblFlechaFiltro_Click_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(55, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(69, 29);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "label1";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblFiltrosAplicados
            // 
            this.lblFiltrosAplicados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFiltrosAplicados.AutoSize = true;
            this.lblFiltrosAplicados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltrosAplicados.Location = new System.Drawing.Point(172, 16);
            this.lblFiltrosAplicados.Name = "lblFiltrosAplicados";
            this.lblFiltrosAplicados.Size = new System.Drawing.Size(103, 13);
            this.lblFiltrosAplicados.TabIndex = 0;
            this.lblFiltrosAplicados.Text = "(Sin filtros aplicados)";
            // 
            // EstadoAcademico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 309);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EstadoAcademico";
            this.Text = "EstadoAcademico";
            this.Load += new System.EventHandler(this.EstadoAcademico_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cbFiltroEstado;
        private System.Windows.Forms.ComboBox cbFiltroComision;
        private System.Windows.Forms.DataGridView dgvCursos;
        private System.Windows.Forms.ComboBox cbFiltroAño;
        private System.Windows.Forms.Label lblFiltros;
        private System.Windows.Forms.CheckBox chkFiltroEstado;
        private System.Windows.Forms.CheckBox chkFiltroAño;
        private System.Windows.Forms.CheckBox chkFiltroComison;
        private System.Windows.Forms.Label lblFlechaFiltro;
        private System.Windows.Forms.Label lblFiltrosAplicados;
        private System.Windows.Forms.DataGridViewTextBoxColumn col0IDCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn col0IDComision;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1anioCalendario;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2Comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn col3Materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn col4Profesor;
        private System.Windows.Forms.DataGridViewTextBoxColumn col5Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn col6Nota;
        private System.Windows.Forms.DataGridViewTextBoxColumn col7FechaModificacion;
    }
}