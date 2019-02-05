namespace UI.Desktop
{
    partial class MainAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainAdmin));
            this.tblGlobal = new System.Windows.Forms.TableLayoutPanel();
            this.tblControles = new System.Windows.Forms.TableLayoutPanel();
            this.btnCursos = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnEspecialidades = new System.Windows.Forms.Button();
            this.btnAlumnos = new System.Windows.Forms.Button();
            this.btnProfesores = new System.Windows.Forms.Button();
            this.btnPlanesMaterias = new System.Windows.Forms.Button();
            this.btnReportesCursos = new System.Windows.Forms.Button();
            this.btnReportesPlanes = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tblGlobal.SuspendLayout();
            this.tblControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tblGlobal
            // 
            this.tblGlobal.ColumnCount = 3;
            this.tblGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tblGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblGlobal.Controls.Add(this.tblControles, 1, 1);
            this.tblGlobal.Controls.Add(this.pictureBox1, 1, 0);
            this.tblGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblGlobal.Location = new System.Drawing.Point(0, 24);
            this.tblGlobal.Name = "tblGlobal";
            this.tblGlobal.RowCount = 3;
            this.tblGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tblGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblGlobal.Size = new System.Drawing.Size(534, 537);
            this.tblGlobal.TabIndex = 4;
            // 
            // tblControles
            // 
            this.tblControles.ColumnCount = 1;
            this.tblControles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblControles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblControles.Controls.Add(this.btnCursos, 0, 0);
            this.tblControles.Controls.Add(this.btnUsuarios, 0, 1);
            this.tblControles.Controls.Add(this.btnEspecialidades, 0, 2);
            this.tblControles.Controls.Add(this.btnAlumnos, 0, 3);
            this.tblControles.Controls.Add(this.btnProfesores, 0, 4);
            this.tblControles.Controls.Add(this.btnPlanesMaterias, 0, 5);
            this.tblControles.Controls.Add(this.btnReportesCursos, 0, 6);
            this.tblControles.Controls.Add(this.btnReportesPlanes, 0, 7);
            this.tblControles.Location = new System.Drawing.Point(145, 146);
            this.tblControles.Name = "tblControles";
            this.tblControles.RowCount = 8;
            this.tblControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblControles.Size = new System.Drawing.Size(244, 244);
            this.tblControles.TabIndex = 2;
            // 
            // btnCursos
            // 
            this.btnCursos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCursos.Location = new System.Drawing.Point(84, 3);
            this.btnCursos.Name = "btnCursos";
            this.btnCursos.Size = new System.Drawing.Size(75, 23);
            this.btnCursos.TabIndex = 0;
            this.btnCursos.Text = "Cursos";
            this.btnCursos.UseVisualStyleBackColor = true;
            this.btnCursos.Click += new System.EventHandler(this.btnCursos_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUsuarios.Location = new System.Drawing.Point(84, 33);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(75, 23);
            this.btnUsuarios.TabIndex = 0;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnEspecialidades
            // 
            this.btnEspecialidades.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEspecialidades.Location = new System.Drawing.Point(84, 63);
            this.btnEspecialidades.Name = "btnEspecialidades";
            this.btnEspecialidades.Size = new System.Drawing.Size(75, 23);
            this.btnEspecialidades.TabIndex = 0;
            this.btnEspecialidades.Text = "Especialidades";
            this.btnEspecialidades.UseVisualStyleBackColor = true;
            this.btnEspecialidades.Click += new System.EventHandler(this.btnEspecialidades_Click);
            // 
            // btnAlumnos
            // 
            this.btnAlumnos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAlumnos.AutoSize = true;
            this.btnAlumnos.Location = new System.Drawing.Point(84, 93);
            this.btnAlumnos.Name = "btnAlumnos";
            this.btnAlumnos.Size = new System.Drawing.Size(75, 23);
            this.btnAlumnos.TabIndex = 0;
            this.btnAlumnos.Text = "Alumnos (*)";
            this.btnAlumnos.UseVisualStyleBackColor = true;
            // 
            // btnProfesores
            // 
            this.btnProfesores.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnProfesores.AutoSize = true;
            this.btnProfesores.Location = new System.Drawing.Point(82, 123);
            this.btnProfesores.Name = "btnProfesores";
            this.btnProfesores.Size = new System.Drawing.Size(80, 23);
            this.btnProfesores.TabIndex = 0;
            this.btnProfesores.Text = "Profesores (*)";
            this.btnProfesores.UseVisualStyleBackColor = true;
            // 
            // btnPlanesMaterias
            // 
            this.btnPlanesMaterias.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPlanesMaterias.AutoSize = true;
            this.btnPlanesMaterias.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPlanesMaterias.Location = new System.Drawing.Point(68, 153);
            this.btnPlanesMaterias.Name = "btnPlanesMaterias";
            this.btnPlanesMaterias.Size = new System.Drawing.Size(107, 23);
            this.btnPlanesMaterias.TabIndex = 0;
            this.btnPlanesMaterias.Text = "Planes/Materias (*)";
            this.btnPlanesMaterias.UseVisualStyleBackColor = true;
            // 
            // btnReportesCursos
            // 
            this.btnReportesCursos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReportesCursos.AutoSize = true;
            this.btnReportesCursos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReportesCursos.Location = new System.Drawing.Point(77, 183);
            this.btnReportesCursos.Name = "btnReportesCursos";
            this.btnReportesCursos.Size = new System.Drawing.Size(90, 23);
            this.btnReportesCursos.TabIndex = 0;
            this.btnReportesCursos.Text = "Reporte Cursos";
            this.btnReportesCursos.UseVisualStyleBackColor = true;
            this.btnReportesCursos.Click += new System.EventHandler(this.btnReportesCursos_Click);
            // 
            // btnReportesPlanes
            // 
            this.btnReportesPlanes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReportesPlanes.AutoSize = true;
            this.btnReportesPlanes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReportesPlanes.Location = new System.Drawing.Point(77, 213);
            this.btnReportesPlanes.Name = "btnReportesPlanes";
            this.btnReportesPlanes.Size = new System.Drawing.Size(90, 23);
            this.btnReportesPlanes.TabIndex = 0;
            this.btnReportesPlanes.Text = "Reporte Planes";
            this.btnReportesPlanes.UseVisualStyleBackColor = true;
            this.btnReportesPlanes.Click += new System.EventHandler(this.btnReportesPlanes_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(145, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(244, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // MainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(534, 561);
            this.Controls.Add(this.tblGlobal);
            this.MaximumSize = new System.Drawing.Size(550, 600);
            this.Name = "MainAdmin";
            this.Controls.SetChildIndex(this.tblGlobal, 0);
            this.tblGlobal.ResumeLayout(false);
            this.tblControles.ResumeLayout(false);
            this.tblControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblGlobal;
        private System.Windows.Forms.TableLayoutPanel tblControles;
        private System.Windows.Forms.Button btnCursos;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnEspecialidades;
        private System.Windows.Forms.Button btnAlumnos;
        private System.Windows.Forms.Button btnProfesores;
        private System.Windows.Forms.Button btnPlanesMaterias;
        private System.Windows.Forms.Button btnReportesCursos;
        private System.Windows.Forms.Button btnReportesPlanes;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
