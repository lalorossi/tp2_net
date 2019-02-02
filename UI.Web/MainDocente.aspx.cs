using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class MainDocente : GlobalForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.tipoFormulario = tipoForm.Docente;

            //Trata de validar al tipo de usuario en la página o lo devuelve al login
            if (!this.ValidarPermisos())
            {
                Response.Redirect("LogInForm.aspx");
            }
            if (!this.IsPostBack)
            {
            }
        }
        protected void btnCursos_Click(object sender, EventArgs e)
        {
            Response.Redirect("CursosDocente.aspx");
        }
    }
}