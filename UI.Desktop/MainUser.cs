using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Business.Entities;

namespace UI.Desktop
{
    public partial class MainUser : ApplicationForm
    {
        private Usuario _UsuarioActual;
        public Usuario UsuarioActual { get => _UsuarioActual; set => _UsuarioActual = value; }
        private tipoForm _tipoFormulario;
        public tipoForm tipoFormulario{ get => _tipoFormulario; set => _tipoFormulario = value; }

        public enum tipoForm
        {
            Alumno,
            Docente,
            Admin,
        }
        public tipoForm Modo;
        public MainUser()
        {
            InitializeComponent();
        }
        public bool ValidarPermisos()
        {
            // Validar que el usuario sea docente o cerrar el formulario
            UsuarioLogic usr = new UsuarioLogic();
            int permisoUsuario = usr.getPermisos(this.UsuarioActual.ID);

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
        

        private void MainUser_Shown(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                if (!this.ValidarPermisos())
                {
                    Notificar("El usuario no tiene permisos para acceder a este formulario");
                    this.Close();
                }
                else
                {
                    this.Text = this.UsuarioActual.Nombre;
                    this.Text += " (" + this.tipoFormulario.ToString() + ")";
                }
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Esto debería llamar a UsuarioDesktop con los datos del usuario actual
            int ID = this.UsuarioActual.ID;
            UsuarioDesktop formUser = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formUser.ShowDialog();
        }
    }
}
