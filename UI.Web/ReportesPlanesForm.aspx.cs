using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Business.Entities;

namespace UI.Web
{
    public partial class ReportesPlanes : System.Web.UI.Page
    {
        public int currentUserId
        {
            get
            {
                if (this.Session["currentUserID"] != null)
                {
                    return (int)this.Session["currentUserID"];
                }
                else
                {
                    return 0;
                }
            }
            set { this.Session["currentUserID"] = value; }
        }

        public enum tipoForm
        {
            Alumno,
            Docente,
            Admin,
        }
        private tipoForm _tipoFormulario;
        public tipoForm tipoFormulario { get => _tipoFormulario; set => _tipoFormulario = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.tipoFormulario = tipoForm.Admin;
            if (!this.IsPostBack)
            {
                if (!this.ValidarPermisos())
                {
                    //Trata de validar al tipo de usuario en la página o lo devuelve al login
                    Response.Redirect("LogInForm.aspx");
                }
                else
                {
                    this.CargarReporte();
                }

            }
        }

        public bool ValidarPermisos()
        {
            if (this.currentUserId != 0)
            {
                UsuarioLogic usr = new UsuarioLogic();
                int permisoUsuario = usr.getPermisos(currentUserId);

                //Establecer tipo de usuario permitido para el tipo de formulario
                if (this.tipoFormulario == tipoForm.Admin && permisoUsuario == 0)
                {
                    return true;
                }
                if (this.tipoFormulario == tipoForm.Docente && permisoUsuario == 1)
                {
                    return true;
                }
                if (this.tipoFormulario == tipoForm.Alumno && permisoUsuario == 2)
                {
                    return true;
                }

                return false;
            }
            else
            {
                return false;
            }
        }


        private void CargarReporte()
        {
            reportViewerPlanes.LocalReport.DataSources.Clear();
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
            this.reportViewerPlanes.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetPlanes", planesReportes));
            this.reportViewerPlanes.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetMasComisiones", planMasComisiones));
            this.reportViewerPlanes.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetMenosComisiones", PlanMenosComisiones));
            this.reportViewerPlanes.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetMasMaterias", planMasMaterias));
            this.reportViewerPlanes.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetMenosMaterias", planMenosMaterias));

            // Plan con +- materias
            // Plan con +- comisiones

            this.reportViewerPlanes.LocalReport.Refresh();
        }
    }
}