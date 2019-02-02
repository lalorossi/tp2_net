namespace UI.Desktop
{
    partial class CursosDocente
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
            this.dgvCursosDocente = new System.Windows.Forms.DataGridView();
            this.col0IdCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4Año = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col1Materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2Comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col3Alumnos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnVerCurso = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursosDocente)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCursosDocente
            // 
            this.dgvCursosDocente.AllowUserToAddRows = false;
            this.dgvCursosDocente.AllowUserToDeleteRows = false;
            this.dgvCursosDocente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursosDocente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col0IdCurso,
            this.col4Año,
            this.col1Materia,
            this.col2Comision,
            this.col3Alumnos});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvCursosDocente, 2);
            this.dgvCursosDocente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCursosDocente.Location = new System.Drawing.Point(3, 3);
            this.dgvCursosDocente.Name = "dgvCursosDocente";
            this.dgvCursosDocente.ReadOnly = true;
            this.dgvCursosDocente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCursosDocente.Size = new System.Drawing.Size(577, 245);
            this.dgvCursosDocente.TabIndex = 0;
            // 
            // col0IdCurso
            // 
            this.col0IdCurso.Frozen = true;
            this.col0IdCurso.HeaderText = "IDCurso";
            this.col0IdCurso.Name = "col0IdCurso";
            this.col0IdCurso.ReadOnly = true;
            this.col0IdCurso.Visible = false;
            // 
            // col4Año
            // 
            this.col4Año.HeaderText = "Año";
            this.col4Año.Name = "col4Año";
            this.col4Año.ReadOnly = true;
            // 
            // col1Materia
            // 
            this.col1Materia.HeaderText = "Materia";
            this.col1Materia.Name = "col1Materia";
            this.col1Materia.ReadOnly = true;
            // 
            // col2Comision
            // 
            this.col2Comision.HeaderText = "Comision";
            this.col2Comision.Name = "col2Comision";
            this.col2Comision.ReadOnly = true;
            // 
            // col3Alumnos
            // 
            this.col3Alumnos.HeaderText = "Alumnos";
            this.col3Alumnos.Name = "col3Alumnos";
            this.col3Alumnos.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvCursosDocente, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnVerCurso, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSalir, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(583, 280);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnVerCurso
            // 
            this.btnVerCurso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerCurso.Location = new System.Drawing.Point(505, 254);
            this.btnVerCurso.Name = "btnVerCurso";
            this.btnVerCurso.Size = new System.Drawing.Size(75, 23);
            this.btnVerCurso.TabIndex = 1;
            this.btnVerCurso.Text = "Ver Curso";
            this.btnVerCurso.UseVisualStyleBackColor = true;
            this.btnVerCurso.Click += new System.EventHandler(this.btnVerCurso_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(3, 254);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // CursosDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 280);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CursosDocente";
            this.Text = "CursosDocente";
            this.Load += new System.EventHandler(this.CursosDocente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursosDocente)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCursosDocente;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnVerCurso;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn col0IdCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn col4Año;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1Materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2Comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn col3Alumnos;
    }
}