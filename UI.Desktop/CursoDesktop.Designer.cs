namespace UI.Desktop
{
    partial class CursoDesktop
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
            this.tlCursos = new System.Windows.Forms.TableLayoutPanel();
            this.lblMateria = new System.Windows.Forms.Label();
            this.lblComision = new System.Windows.Forms.Label();
            this.lblAnio = new System.Windows.Forms.Label();
            this.lblCupo = new System.Windows.Forms.Label();
            this.cbMateria = new System.Windows.Forms.ComboBox();
            this.cbComision = new System.Windows.Forms.ComboBox();
            this.numCupo = new System.Windows.Forms.NumericUpDown();
            this.numAnio = new System.Windows.Forms.NumericUpDown();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblDocente = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cbDocente = new System.Windows.Forms.ComboBox();
            this.materiaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comisionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materiaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.materiaBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.tlCursos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comisionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiaBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // tlCursos
            // 
            this.tlCursos.ColumnCount = 2;
            this.tlCursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlCursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlCursos.Controls.Add(this.lblMateria, 0, 0);
            this.tlCursos.Controls.Add(this.lblComision, 0, 1);
            this.tlCursos.Controls.Add(this.lblAnio, 0, 2);
            this.tlCursos.Controls.Add(this.lblCupo, 0, 3);
            this.tlCursos.Controls.Add(this.cbMateria, 1, 0);
            this.tlCursos.Controls.Add(this.cbComision, 1, 1);
            this.tlCursos.Controls.Add(this.numCupo, 1, 3);
            this.tlCursos.Controls.Add(this.numAnio, 1, 2);
            this.tlCursos.Controls.Add(this.btnAceptar, 0, 5);
            this.tlCursos.Controls.Add(this.lblDocente, 0, 4);
            this.tlCursos.Controls.Add(this.btnCancelar, 1, 5);
            this.tlCursos.Controls.Add(this.cbDocente, 1, 4);
            this.tlCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlCursos.Location = new System.Drawing.Point(0, 0);
            this.tlCursos.Name = "tlCursos";
            this.tlCursos.RowCount = 6;
            this.tlCursos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlCursos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlCursos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlCursos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlCursos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlCursos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlCursos.Size = new System.Drawing.Size(280, 197);
            this.tlCursos.TabIndex = 0;
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Location = new System.Drawing.Point(3, 0);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(42, 13);
            this.lblMateria.TabIndex = 0;
            this.lblMateria.Text = "Materia";
            // 
            // lblComision
            // 
            this.lblComision.AutoSize = true;
            this.lblComision.Location = new System.Drawing.Point(3, 33);
            this.lblComision.Name = "lblComision";
            this.lblComision.Size = new System.Drawing.Size(49, 13);
            this.lblComision.TabIndex = 1;
            this.lblComision.Text = "Comision";
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(3, 66);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(26, 13);
            this.lblAnio.TabIndex = 2;
            this.lblAnio.Text = "Año";
            // 
            // lblCupo
            // 
            this.lblCupo.AutoSize = true;
            this.lblCupo.Location = new System.Drawing.Point(3, 99);
            this.lblCupo.Name = "lblCupo";
            this.lblCupo.Size = new System.Drawing.Size(32, 13);
            this.lblCupo.TabIndex = 3;
            this.lblCupo.Text = "Cupo";
            // 
            // cbMateria
            // 
            this.cbMateria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMateria.FormattingEnabled = true;
            this.cbMateria.Location = new System.Drawing.Point(84, 3);
            this.cbMateria.Name = "cbMateria";
            this.cbMateria.Size = new System.Drawing.Size(193, 21);
            this.cbMateria.TabIndex = 6;
            // 
            // cbComision
            // 
            this.cbComision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbComision.FormattingEnabled = true;
            this.cbComision.Location = new System.Drawing.Point(84, 36);
            this.cbComision.Name = "cbComision";
            this.cbComision.Size = new System.Drawing.Size(193, 21);
            this.cbComision.TabIndex = 7;
            // 
            // numCupo
            // 
            this.numCupo.Location = new System.Drawing.Point(84, 102);
            this.numCupo.Name = "numCupo";
            this.numCupo.Size = new System.Drawing.Size(120, 20);
            this.numCupo.TabIndex = 9;
            // 
            // numAnio
            // 
            this.numAnio.Location = new System.Drawing.Point(84, 69);
            this.numAnio.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.numAnio.Minimum = new decimal(new int[] {
            1950,
            0,
            0,
            0});
            this.numAnio.Name = "numAnio";
            this.numAnio.Size = new System.Drawing.Size(120, 20);
            this.numAnio.TabIndex = 10;
            this.numAnio.Value = new decimal(new int[] {
            1950,
            0,
            0,
            0});
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.Location = new System.Drawing.Point(3, 168);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblDocente
            // 
            this.lblDocente.AutoSize = true;
            this.lblDocente.Location = new System.Drawing.Point(3, 132);
            this.lblDocente.Name = "lblDocente";
            this.lblDocente.Size = new System.Drawing.Size(48, 13);
            this.lblDocente.TabIndex = 3;
            this.lblDocente.Text = "Docente";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(202, 168);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbDocente
            // 
            this.cbDocente.FormattingEnabled = true;
            this.cbDocente.Location = new System.Drawing.Point(84, 135);
            this.cbDocente.Name = "cbDocente";
            this.cbDocente.Size = new System.Drawing.Size(193, 21);
            this.cbDocente.TabIndex = 11;
            // 
            // materiaBindingSource
            // 
            this.materiaBindingSource.DataSource = typeof(Business.Entities.Materia);
            // 
            // comisionBindingSource
            // 
            this.comisionBindingSource.DataSource = typeof(Business.Entities.Comision);
            // 
            // materiaBindingSource1
            // 
            this.materiaBindingSource1.DataSource = typeof(Business.Entities.Materia);
            // 
            // materiaBindingSource2
            // 
            this.materiaBindingSource2.DataSource = typeof(Business.Entities.Materia);
            // 
            // CursoDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(280, 197);
            this.Controls.Add(this.tlCursos);
            this.Name = "CursoDesktop";
            this.tlCursos.ResumeLayout(false);
            this.tlCursos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comisionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiaBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlCursos;
        private System.Windows.Forms.Label lblMateria;
        private System.Windows.Forms.Label lblComision;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label lblCupo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cbMateria;
        private System.Windows.Forms.ComboBox cbComision;
        private System.Windows.Forms.NumericUpDown numCupo;
        private System.Windows.Forms.BindingSource materiaBindingSource;
        private System.Windows.Forms.BindingSource comisionBindingSource;
        private System.Windows.Forms.BindingSource materiaBindingSource1;
        private System.Windows.Forms.BindingSource materiaBindingSource2;
        private System.Windows.Forms.NumericUpDown numAnio;
        private System.Windows.Forms.Label lblDocente;
        private System.Windows.Forms.ComboBox cbDocente;
    }
}
