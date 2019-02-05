using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Business.Entities;
using Microsoft.Reporting.WinForms;

namespace UI.Desktop
{
    public partial class FormReportePlanes : Form
    {
        public FormReportePlanes()
        {
            InitializeComponent();
        }

        private void FormReportePlanes_Load(object sender, EventArgs e)
        {
            this.CargarReporte();
            this.reportViewerPlanes.RefreshReport();
        }

        private void CargarReporte()
        {
            // Tabla básica de datos de cursos
            List<ReportePlanes> planesReportes = new List<ReportePlanes>();
            List<ReportePlanes> planMasMaterias = new List<ReportePlanes>();
            List<ReportePlanes> planMenosMaterias = new List<ReportePlanes>();
            List<ReportePlanes> planMasComisiones = new List<ReportePlanes>();
            List<ReportePlanes> PlanMenosComisiones = new List<ReportePlanes>();
            foreach (Plan plan in new PlanLogic().GetAll())
            {
                // Descripcion, especialidad, IDespecialidad, materias, comisiones
                ReportePlanes rp = new ReportePlanes();
                rp.Descripcion = plan.Descripcion;
                rp.Especialidad = new EspecialidadLogic().GetOne(plan.IDEspecialidad).Descripcion;
                rp.IDEspecialidad = plan.IDEspecialidad;
                rp.Materias = (new MateriaLogic().MateriasDeCurso(plan.ID)).Count();
                rp.Comisiones = (new ComisionLogic().ComisionesDePlan(plan.ID)).Count();

                planesReportes.Add(rp);

                if (planMasMaterias.Count() > 0)
                {
                    if (rp.Materias > planMasMaterias[0].Materias)
                    {
                        planMasMaterias.Clear();
                        planMasMaterias.Add(rp);
                    }
                    else if (rp.Materias == planMasMaterias[0].Materias)
                    {
                        planMasMaterias.Add(rp);
                    }
                }
                else
                {
                    planMasMaterias.Add(rp);
                }

                if (planMenosMaterias.Count() > 0)
                {
                    if (rp.Materias < planMenosMaterias[0].Materias)
                    {
                        planMenosMaterias.Clear();
                        planMenosMaterias.Add(rp);
                        //MessageBox.Show("clear");
                    }
                    else if (rp.Materias == planMenosMaterias[0].Materias)
                    {
                        //MessageBox.Show("add");
                        planMenosMaterias.Add(rp);
                    }
                }
                else
                {
                    planMenosMaterias.Add(rp);
                }

                if (planMasComisiones.Count() > 0)
                {
                    if (rp.Comisiones > planMasComisiones[0].Comisiones)
                    {
                        planMasComisiones.Clear();
                        planMasComisiones.Add(rp);
                    }
                    else if (rp.Comisiones == planMasComisiones[0].Comisiones)
                    {
                        planMasComisiones.Add(rp);
                    }
                }
                else
                {
                    planMasComisiones.Add(rp);
                }

                if (PlanMenosComisiones.Count() > 0)
                {
                    if (rp.Comisiones < PlanMenosComisiones[0].Comisiones)
                    {
                        PlanMenosComisiones.Clear();
                        PlanMenosComisiones.Add(rp);
                    }
                    else if (rp.Comisiones == PlanMenosComisiones[0].Comisiones)
                    {
                        PlanMenosComisiones.Add(rp);
                    }
                }
                else
                {
                    PlanMenosComisiones.Add(rp);
                }

            }

            this.reportViewerPlanes.LocalReport.DataSources.Clear();

            // Tabla de cursos general
            this.reportViewerPlanes.LocalReport.DataSources.Add(new ReportDataSource("DataSetPlanes", planesReportes));
            this.reportViewerPlanes.LocalReport.DataSources.Add(new ReportDataSource("DataSetMasComisiones", planMasComisiones));
            this.reportViewerPlanes.LocalReport.DataSources.Add(new ReportDataSource("DataSetMenosComisiones", PlanMenosComisiones));
            this.reportViewerPlanes.LocalReport.DataSources.Add(new ReportDataSource("DataSetMasMaterias", planMasMaterias));
            this.reportViewerPlanes.LocalReport.DataSources.Add(new ReportDataSource("DataSetMenosMaterias", planMenosMaterias));

            // Plan con +- materias
            // Plan con +- comisiones

            this.reportViewerPlanes.RefreshReport();
        }
    }
}
