namespace UI.Desktop
{
    partial class AlumnosCurso
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
            this.tlAlumnosCurso = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAlumnos = new System.Windows.Forms.DataGridView();
            this.col0IDAlumnoInscripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col1Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col3Legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4Nota = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col5Condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.comisionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comisionBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tlAlumnosCurso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comisionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comisionBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tlAlumnosCurso
            // 
            this.tlAlumnosCurso.ColumnCount = 2;
            this.tlAlumnosCurso.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAlumnosCurso.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlAlumnosCurso.Controls.Add(this.dgvAlumnos, 0, 0);
            this.tlAlumnosCurso.Controls.Add(this.btnSalir, 0, 1);
            this.tlAlumnosCurso.Controls.Add(this.btnEditar, 1, 1);
            this.tlAlumnosCurso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlAlumnosCurso.Location = new System.Drawing.Point(0, 0);
            this.tlAlumnosCurso.Name = "tlAlumnosCurso";
            this.tlAlumnosCurso.RowCount = 2;
            this.tlAlumnosCurso.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAlumnosCurso.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlAlumnosCurso.Size = new System.Drawing.Size(658, 215);
            this.tlAlumnosCurso.TabIndex = 0;
            // 
            // dgvAlumnos
            // 
            this.dgvAlumnos.AllowUserToAddRows = false;
            this.dgvAlumnos.AllowUserToDeleteRows = false;
            this.dgvAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col0IDAlumnoInscripcion,
            this.col1Apellido,
            this.col2Nombre,
            this.col3Legajo,
            this.col4Nota,
            this.col5Condicion});
            this.tlAlumnosCurso.SetColumnSpan(this.dgvAlumnos, 2);
            this.dgvAlumnos.Location = new System.Drawing.Point(3, 3);
            this.dgvAlumnos.Name = "dgvAlumnos";
            this.dgvAlumnos.Size = new System.Drawing.Size(652, 180);
            this.dgvAlumnos.TabIndex = 0;
            // 
            // col0IDAlumnoInscripcion
            // 
            this.col0IDAlumnoInscripcion.Frozen = true;
            this.col0IDAlumnoInscripcion.HeaderText = "IDAlumnoInscripcion";
            this.col0IDAlumnoInscripcion.Name = "col0IDAlumnoInscripcion";
            this.col0IDAlumnoInscripcion.ReadOnly = true;
            this.col0IDAlumnoInscripcion.Visible = false;
            // 
            // col1Apellido
            // 
            this.col1Apellido.HeaderText = "Apellido";
            this.col1Apellido.Name = "col1Apellido";
            this.col1Apellido.ReadOnly = true;
            // 
            // col2Nombre
            // 
            this.col2Nombre.HeaderText = "Nombre";
            this.col2Nombre.Name = "col2Nombre";
            this.col2Nombre.ReadOnly = true;
            // 
            // col3Legajo
            // 
            this.col3Legajo.HeaderText = "Legajo";
            this.col3Legajo.Name = "col3Legajo";
            this.col3Legajo.ReadOnly = true;
            // 
            // col4Nota
            // 
            this.col4Nota.HeaderText = "Nota";
            this.col4Nota.Items.AddRange(new object[] {
            "-",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.col4Nota.MaxDropDownItems = 11;
            this.col4Nota.Name = "col4Nota";
            this.col4Nota.ReadOnly = true;
            // 
            // col5Condicion
            // 
            this.col5Condicion.HeaderText = "Condicion";
            this.col5Condicion.Name = "col5Condicion";
            this.col5Condicion.ReadOnly = true;
            // 
            // btnSalir
            // 
            this.btnSalir.AutoSize = true;
            this.btnSalir.Location = new System.Drawing.Point(3, 189);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(580, 189);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar Notas";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // comisionBindingSource
            // 
            this.comisionBindingSource.DataSource = typeof(Business.Entities.Comision);
            // 
            // comisionBindingSource1
            // 
            this.comisionBindingSource1.DataSource = typeof(Business.Entities.Comision);
            // 
            // AlumnosCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(658, 215);
            this.Controls.Add(this.tlAlumnosCurso);
            this.Name = "AlumnosCurso";
            this.tlAlumnosCurso.ResumeLayout(false);
            this.tlAlumnosCurso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comisionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comisionBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlAlumnosCurso;
        private System.Windows.Forms.DataGridView dgvAlumnos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.BindingSource comisionBindingSource;
        private System.Windows.Forms.BindingSource comisionBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col0IDAlumnoInscripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn col3Legajo;
        private System.Windows.Forms.DataGridViewComboBoxColumn col4Nota;
        private System.Windows.Forms.DataGridViewTextBoxColumn col5Condicion;
    }
}
