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
    public partial class LogInForm : GlobalForm
    {
        UsuarioLogic _usrLogic;
        private UsuarioLogic UsrLogic
        {
            get
            {
                if (_usrLogic == null)
                {
                    _usrLogic = new UsuarioLogic();
                }
                return _usrLogic;
            }
        }

        private Usuario UsuarioActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Si hay un usuario logueado, lo manda a su main por tipo de usuario
            if (this.currentUserId != 0)
            {
                UsuarioLogic usr = new UsuarioLogic();
                int permisoUsuario = usr.getPermisos(currentUserId);
                switch (permisoUsuario)
                {
                    case 0:
                        Response.Redirect("MainAdmin.aspx");
                        break;
                    case 1:
                        Response.Redirect("MainDocente.aspx");
                        break;
                    case 2:
                        Response.Redirect("MainAlumno.aspx");
                        break;
                }
            }
            if (!this.IsPostBack)
            {
            this.txtUser.Text = "";
            this.txtPassword.Text = "";
            }
            this.txtUser.Focus();
        }
        public bool LogTry()
        {
            this.UsuarioActual = UsrLogic.GetOneByUserAndPassword(this.txtUser.Text, this.txtPassword.Text);
            if (this.UsuarioActual.ID > 0)
            {
                SelectedId = this.UsuarioActual.ID;
                Session["currentUserID"] = SelectedId;
                return true;
            }
            this.Notificar("Usuario y contraseña incorrectos");
            return false;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.LogTry())
            {
                //Lo manda a la página de home por su tipo de usuario
                switch (UsrLogic.getPermisos(UsuarioActual.ID))
                {
                    case 0:
                        Response.Redirect("MainAdmin.aspx");
                        break;
                    case 1:
                        Server.Transfer("MainDocente.aspx");
                        break;
                    case 2:
                        Server.Transfer("MainAlumno.aspx");
                        break;
                }
            }
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            // Muestra la lista de mails de admin
            PersonasLogic pers = new PersonasLogic();
            List<Personas> PersonasAdmin = pers.getAllAdmins();
            string listaDeEmails = "";
            if (PersonasAdmin.Count > 0)
            {
                foreach (Personas admin in PersonasAdmin)
                {
                    listaDeEmails += admin.Email;
                    listaDeEmails += "\n";
                }
                MostrarNota(listaDeEmails);
            }
            else
            {
                MostrarNota("No hay admins registrados");
            }
        }

        protected void MostrarNota(string texto)
        {
            this.lbRegistro.Visible = true;
            this.lbRegistro.Items.Add(texto);
        }
    }
}