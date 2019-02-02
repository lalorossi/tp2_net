namespace UI.Desktop
{
    partial class MainDocente
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
            this.tblGlobal = new System.Windows.Forms.TableLayoutPanel();
            this.tblControles = new System.Windows.Forms.TableLayoutPanel();
            this.btnCursos = new System.Windows.Forms.Button();
            this.tblGlobal.SuspendLayout();
            this.tblControles.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblGlobal
            // 
            this.tblGlobal.ColumnCount = 3;
            this.tblGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tblGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblGlobal.Controls.Add(this.tblControles, 1, 1);
            this.tblGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblGlobal.Location = new System.Drawing.Point(0, 24);
            this.tblGlobal.Name = "tblGlobal";
            this.tblGlobal.RowCount = 3;
            this.tblGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tblGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblGlobal.Size = new System.Drawing.Size(228, 200);
            this.tblGlobal.TabIndex = 4;
            // 
            // tblControles
            // 
            this.tblControles.ColumnCount = 1;
            this.tblControles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblControles.Controls.Add(this.btnCursos, 0, 0);
            this.tblControles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblControles.Location = new System.Drawing.Point(-8, -22);
            this.tblControles.Name = "tblControles";
            this.tblControles.RowCount = 1;
            this.tblControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblControles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblControles.Size = new System.Drawing.Size(244, 244);
            this.tblControles.TabIndex = 1;
            // 
            // btnCursos
            // 
            this.btnCursos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCursos.Location = new System.Drawing.Point(84, 110);
            this.btnCursos.Name = "btnCursos";
            this.btnCursos.Size = new System.Drawing.Size(75, 23);
            this.btnCursos.TabIndex = 0;
            this.btnCursos.Text = "Cursos";
            this.btnCursos.UseVisualStyleBackColor = true;
            this.btnCursos.Click += new System.EventHandler(this.btnCursos_Click);
            // 
            // MainDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(228, 224);
            this.Controls.Add(this.tblGlobal);
            this.Name = "MainDocente";
            this.Controls.SetChildIndex(this.tblGlobal, 0);
            this.tblGlobal.ResumeLayout(false);
            this.tblControles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblGlobal;
        private System.Windows.Forms.TableLayoutPanel tblControles;
        private System.Windows.Forms.Button btnCursos;
    }
}
