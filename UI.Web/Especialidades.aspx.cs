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
    public partial class Especialidades : GlobalForm
    {
        EspecialidadLogic _EspLogic;
        private EspecialidadLogic EspLogic
        {
            get
            {
                if (_EspLogic == null)
                {
                    _EspLogic = new EspecialidadLogic();
                }
                return _EspLogic;
            }
        }


        private Especialidad EspecialidadActual;


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
                    this.LoadGrid();
                }
                
            }


        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.EspLogic.GetAll();
            this.gridView.DataBind();
        }

        private void LoadForm(int id)
        {
            this.EspecialidadActual = this.EspLogic.GetOne(id);
            string descripcion = EspecialidadActual.Descripcion;

                
            this.descripcionTextBox.Text = descripcion;
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Find the value in the c04_oprogrs column. You'll have to use
                
            }
        }


        /* Metodos de entidad */
        public void LoadEntity(Especialidad especialidad)
        {
            especialidad.Descripcion = this.descripcionTextBox.Text;
        }

        private void SaveEntity(Especialidad especialidad)
        {
            this.EspLogic.Save(especialidad);
        }

        private void DeleteEntity(int id)
        {
            this.EspLogic.Delete(id);
        }
        /* -- Metodos de entidad -- */

        /* Métodos de formulario */
        private void EnableForm(bool enable)
        {
            {
                this.descripcionTextBox.Enabled = enable;
            }
        }

        private void ClearForm()
        {
            this.descripcionTextBox.Text = string.Empty;
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
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedId);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.EspecialidadActual = new Especialidad();
                    this.EspecialidadActual.ID = this.SelectedId;
                    this.EspecialidadActual.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.EspecialidadActual);
                    this.SaveEntity(this.EspecialidadActual);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.EspecialidadActual = new Especialidad();
                    this.LoadEntity(this.EspecialidadActual);
                    this.SaveEntity(this.EspecialidadActual);
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