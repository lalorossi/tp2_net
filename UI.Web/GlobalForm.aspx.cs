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
    public partial class GlobalForm : System.Web.UI.Page
    {
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion,
        }
        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        public int SelectedId
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set { this.ViewState["SelectedID"] = value; }
        }
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

        public bool IsEntitySelected
        {
            get { return (this.SelectedId != 0); }
        }


        public void Notificar(string msj)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), this.Title, "alert('" + msj + "')", true);
        }

        public bool ValidarPermisos()
        {
            if(this.currentUserId != 0)
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
                
                Notificar("El usuario no tiene permiso para entrar a esta página");
                return false;
            }
            else
            {
                Notificar("El usuario no tiene permiso para entrar a esta página");
                return false;
            }
        }
    }
}