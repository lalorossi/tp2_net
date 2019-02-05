namespace UI.Desktop
{
    partial class FormReporteCursos
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
            this.reportViewerCursos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerCursos
            // 
            this.reportViewerCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerCursos.LocalReport.ReportEmbeddedResource = "UI.Desktop.ReporteCursos.rdlc";
            this.reportViewerCursos.Location = new System.Drawing.Point(0, 0);
            this.reportViewerCursos.Name = "reportViewerCursos";
            this.reportViewerCursos.ServerReport.BearerToken = null;
            this.reportViewerCursos.Size = new System.Drawing.Size(703, 261);
            this.reportViewerCursos.TabIndex = 0;
            // 
            // FormReporteCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(703, 261);
            this.Controls.Add(this.reportViewerCursos);
            this.MinimizeBox = false;
            this.Name = "FormReporteCursos";
            this.Text = "FormReporteCursos";
            this.Load += new System.EventHandler(this.FormReporteCursos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerCursos;
    }
}