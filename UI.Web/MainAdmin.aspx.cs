using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class MainAdmin : GlobalForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.tipoFormulario = tipoForm.Admin;

            //Trata de validar al tipo de usuario en la página o lo devuelve al login
            if (!this.ValidarPermisos())
            {
                Response.Redirect("LogInForm.aspx");
            }
            if (!this.IsPostBack)
            {
            }
        }
        protected void btnUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }
        protected void btnCursos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cursos.aspx");
        }
        protected void btnEspecialidades_Click(object sender, EventArgs e)
        {
            Response.Redirect("Especialidades.aspx");
        }

        protected void btnReporteCursos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportesCursosForm.aspx");
        }
        protected void btnReportePlanes_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportesPlanesForm.aspx");
        }
    }
}