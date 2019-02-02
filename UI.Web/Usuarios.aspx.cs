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
    public partial class Usuarios : GlobalForm
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
            this.tipoFormulario = tipoForm.Admin;

            if (!this.IsPostBack)
            {
                // Si un usuario llegó a la página para cambiar sus datos, lo deja pasar
                if (this.Context.Items["editModeOn"] != null)
                {
                    bool newFormMode = (bool)this.Context.Items["editModeOn"];
                    if (newFormMode)
                    {
                        this.SelectedId = (int)Session["currentUserID"];
                        editarLinkButton_Click(null, EventArgs.Empty);
                    }
                }
                else if (!this.ValidarPermisos())
                {
                    //Trata de validar al tipo de usuario en la página o lo devuelve al login
                    Response.Redirect("LogInForm.aspx");
                }
                else
                {
                    this.LoadGrid();
                }
            }
            else
            {
                //Si es postback y el usuario ya editó sus datos, sacarlo
                switch (UsrLogic.getPermisos((int)Session["currentUserID"]))
                {
                    case 1:
                        Response.Redirect("MainDocente.aspx");
                        break;
                    case 2:
                        Response.Redirect("ManinAlumno.aspx");
                        break;
                }
            }
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.UsrLogic.GetAll();
            this.gridView.DataBind();
        }

        private void LoadForm(int id)
        {
            this.UsuarioActual = this.UsrLogic.GetOne(id);
            this.nombreTextBox.Text = this.UsuarioActual.Nombre;
            this.apellidoTextBox.Text = this.UsuarioActual.Apellido;
            this.emailTextBox.Text = this.UsuarioActual.EMail;
            this.habilitadoCheckBox.Checked = this.UsuarioActual.Habilitado;
            this.nombreUsuarioTextBox.Text = this.UsuarioActual.NombreUsuario;
            //this.claveTextBox.Text = this.UsuarioActual.Clave;
            //this.repetirClaveLabel.Text = "";
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedId = (int)this.gridView.SelectedValue;
        }
        protected void gridView_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gridView, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }


        /* Metodos de entidad */
        public void LoadEntity(Usuario usuario)
        {
            usuario.Nombre = this.nombreTextBox.Text;
            usuario.Apellido = this.apellidoTextBox.Text;
            usuario.NombreUsuario = this.nombreUsuarioTextBox.Text;
            usuario.EMail = this.emailTextBox.Text;
            usuario.Clave = this.claveTextBox.Text;
            usuario.Habilitado = this.habilitadoCheckBox.Checked;
        }

        private void SaveEntity(Usuario usuario)
        {
            this.UsrLogic.Save(usuario);
        }

        private void DeleteEntity(int id)
        {
            this.UsrLogic.Delete(id);
        }
        /* -- Metodos de entidad -- */

        /* Métodos de formulario */
        private void EnableForm(bool enable)
        {
            {
                this.nombreTextBox.Enabled = enable;
                this.apellidoTextBox.Enabled = enable;
                this.nombreUsuarioTextBox.Enabled = enable;
                this.emailTextBox.Enabled = enable;
                this.claveTextBox.Visible = enable;
                this.claveLabel.Visible = enable;
                this.repetirClaveTextBox.Visible = enable;
                this.repetirClaveLabel.Visible = enable;
            }
        }

        private void ClearForm()
        {
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.nombreUsuarioTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.habilitadoCheckBox.Checked = false;
        }
        /* -- Métodos de formulario -- */

        /* Métodos de click de grilla de usuarios */
        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.gridPanel.Visible = false;
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.gridPanel.Visible = false;
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedId);
            }
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.gridPanel.Visible = false;
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedId);
            }
        }
        /* -- Métodos de click de grilla de usuarios -- */

        /* Métodos de click de grilla de edición */
        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            this.UsuarioActual = new Usuario();
            this.UsuarioActual.ID = this.SelectedId;
            this.UsuarioActual.State = BusinessEntity.States.Modified;
            this.LoadEntity(this.UsuarioActual);
            this.SaveEntity(this.UsuarioActual);
            this.LoadGrid();
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedId);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.UsuarioActual = new Usuario();
                    this.UsuarioActual.ID = this.SelectedId;
                    this.UsuarioActual.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.UsuarioActual);
                    this.SaveEntity(this.UsuarioActual);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.UsuarioActual = new Usuario();
                    this.LoadEntity(this.UsuarioActual);
                    this.SaveEntity(this.UsuarioActual);
                    this.LoadGrid();
                    break;
                default:
                    break;
            }

            this.gridPanel.Visible = true;
            this.formPanel.Visible = false;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.gridPanel.Visible = true;
            this.ClearForm();
            this.EnableForm(false);
            this.formPanel.Visible = false;
        }
        /* -- Métodos de click de grilla de edición -- */
    }
}