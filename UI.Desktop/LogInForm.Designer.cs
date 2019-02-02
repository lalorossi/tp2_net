namespace UI.Desktop
{
    partial class LogInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            this.inpUserName = new System.Windows.Forms.TextBox();
            this.inpPassword = new System.Windows.Forms.TextBox();
            this.lblUsuasrio = new System.Windows.Forms.Label();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.tblIngreso = new System.Windows.Forms.TableLayoutPanel();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.imgUTNLogo = new System.Windows.Forms.PictureBox();
            this.tblGlobal = new System.Windows.Forms.TableLayoutPanel();
            this.tblIngreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgUTNLogo)).BeginInit();
            this.tblGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // inpUserName
            // 
            this.inpUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inpUserName.Location = new System.Drawing.Point(84, 3);
            this.inpUserName.Name = "inpUserName";
            this.inpUserName.Size = new System.Drawing.Size(113, 20);
            this.inpUserName.TabIndex = 1;
            // 
            // inpPassword
            // 
            this.inpPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inpPassword.Location = new System.Drawing.Point(84, 29);
            this.inpPassword.Name = "inpPassword";
            this.inpPassword.Size = new System.Drawing.Size(113, 20);
            this.inpPassword.TabIndex = 2;
            this.inpPassword.UseSystemPasswordChar = true;
            // 
            // lblUsuasrio
            // 
            this.lblUsuasrio.AutoSize = true;
            this.lblUsuasrio.Location = new System.Drawing.Point(3, 0);
            this.lblUsuasrio.Name = "lblUsuasrio";
            this.lblUsuasrio.Size = new System.Drawing.Size(46, 13);
            this.lblUsuasrio.TabIndex = 1;
            this.lblUsuasrio.Text = "Usuario:";
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(3, 26);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(64, 13);
            this.lblContraseña.TabIndex = 1;
            this.lblContraseña.Text = "Contraseña:";
            // 
            // tblIngreso
            // 
            this.tblIngreso.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tblIngreso.ColumnCount = 2;
            this.tblIngreso.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblIngreso.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblIngreso.Controls.Add(this.lblUsuasrio, 0, 0);
            this.tblIngreso.Controls.Add(this.inpPassword, 1, 1);
            this.tblIngreso.Controls.Add(this.lblContraseña, 0, 1);
            this.tblIngreso.Controls.Add(this.inpUserName, 1, 0);
            this.tblIngreso.Controls.Add(this.btnLogIn, 1, 2);
            this.tblIngreso.Controls.Add(this.btnRegistrar, 0, 2);
            this.tblIngreso.Location = new System.Drawing.Point(75, 247);
            this.tblIngreso.Name = "tblIngreso";
            this.tblIngreso.RowCount = 3;
            this.tblIngreso.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblIngreso.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblIngreso.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblIngreso.Size = new System.Drawing.Size(197, 100);
            this.tblIngreso.TabIndex = 2;
            // 
            // btnLogIn
            // 
            this.btnLogIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogIn.Location = new System.Drawing.Point(122, 55);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(75, 23);
            this.btnLogIn.TabIndex = 4;
            this.btnLogIn.Text = "Entrar";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(3, 55);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 3;
            this.btnRegistrar.Text = "Registrarse";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // imgUTNLogo
            // 
            this.imgUTNLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgUTNLogo.Image")));
            this.imgUTNLogo.Location = new System.Drawing.Point(75, 63);
            this.imgUTNLogo.Name = "imgUTNLogo";
            this.imgUTNLogo.Size = new System.Drawing.Size(197, 178);
            this.imgUTNLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgUTNLogo.TabIndex = 3;
            this.imgUTNLogo.TabStop = false;
            // 
            // tblGlobal
            // 
            this.tblGlobal.ColumnCount = 3;
            this.tblGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblGlobal.Controls.Add(this.imgUTNLogo, 1, 1);
            this.tblGlobal.Controls.Add(this.tblIngreso, 1, 2);
            this.tblGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblGlobal.Location = new System.Drawing.Point(0, 0);
            this.tblGlobal.Name = "tblGlobal";
            this.tblGlobal.RowCount = 4;
            this.tblGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblGlobal.Size = new System.Drawing.Size(348, 411);
            this.tblGlobal.TabIndex = 4;
            // 
            // LogInForm
            // 
            this.AcceptButton = this.btnLogIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(348, 411);
            this.Controls.Add(this.tblGlobal);
            this.MinimumSize = new System.Drawing.Size(350, 450);
            this.Name = "LogInForm";
            this.Text = "LogInForm";
            this.Activated += new System.EventHandler(this.LogInForm_Shown);
            this.Shown += new System.EventHandler(this.LogInForm_Shown);
            this.tblIngreso.ResumeLayout(false);
            this.tblIngreso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgUTNLogo)).EndInit();
            this.tblGlobal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox inpUserName;
        private System.Windows.Forms.TextBox inpPassword;
        private System.Windows.Forms.Label lblUsuasrio;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.TableLayoutPanel tblIngreso;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.PictureBox imgUTNLogo;
        private System.Windows.Forms.TableLayoutPanel tblGlobal;
    }
}