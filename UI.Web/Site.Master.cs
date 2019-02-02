using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lnkEditarUsuario_Click(object sender, EventArgs e)
        {
            this.Context.Items["editModeOn"] = true;
            Server.Transfer("Usuarios.aspx");
        }
        protected void lnkCerrarSesion_Click(object sender, EventArgs e)
        {
            //Borra al usuario de la sesion y vuelve al login (igual con viewState y context, por si a caso)
            ViewState["currentUserID"] = null;
            Session["currentUserId"] = null;
            Context.Items["currentUserId"] = null;
            Response.Redirect("LogInForm.aspx");
        }
    }
}