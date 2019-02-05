namespace UI.Desktop
{
    partial class FormReportePlanes
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Curso_ReporteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewerPlanes = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.Curso_ReporteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Curso_ReporteBindingSource
            // 
            this.Curso_ReporteBindingSource.DataMember = "Curso_Reporte";
            // 
            // reportViewerPlanes
            // 
            this.reportViewerPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Curso_ReporteBindingSource;
            this.reportViewerPlanes.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerPlanes.LocalReport.ReportEmbeddedResource = "UI.Desktop.ReportePlanes.rdlc";
            this.reportViewerPlanes.Location = new System.Drawing.Point(0, 0);
            this.reportViewerPlanes.Name = "reportViewerPlanes";
            this.reportViewerPlanes.ServerReport.BearerToken = null;
            this.reportViewerPlanes.Size = new System.Drawing.Size(800, 450);
            this.reportViewerPlanes.TabIndex = 0;
            // 
            // FormReportePlanes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerPlanes);
            this.Name = "FormReportePlanes";
            this.Text = "FormReportePlanes";
            this.Load += new System.EventHandler(this.FormReportePlanes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Curso_ReporteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerPlanes;
        private System.Windows.Forms.BindingSource Curso_ReporteBindingSource;
    }
}