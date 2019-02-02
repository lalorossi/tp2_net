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
    public partial class LogInForm : ApplicationForm
    {
        private Usuario _UsuarioActual;
        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }
        public LogInForm()
        {
            InitializeComponent();
        }
        public bool Validar()
        {
            if (this.inpUserName.Text != "" && this.inpPassword.Text != "")
            {
                UsuarioLogic usr = new UsuarioLogic();
                this.UsuarioActual = usr.GetOneByUserAndPassword(this.inpUserName.Text, this.inpPassword.Text);
                if (this.UsuarioActual.ID > 0)
                {
                    return true;
                }
                else
                {
                    this.Notificar("Usuario y contraseña incorrectos");
                }
            }
            else
            {
                this.Notificar("Debe completar los campos para continuar");
            }
            return false;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                UsuarioLogic usr = new UsuarioLogic();
                this.UsuarioActual = usr.GetOneByUserAndPassword(this.inpUserName.Text, this.inpPassword.Text);
                int tipoUsuario = usr.getPermisos(UsuarioActual.ID);
                // Si es alumno te manda a la pagina de alumno
                if(tipoUsuario == 2)
                {
                    MainAlumno mainAlumno = new MainAlumno(UsuarioActual.ID);
                    mainAlumno.ShowDialog();
                }
                // Si es docente te manda a la pagina de docente
                else if (tipoUsuario == 1)
                {
                    MainDocente mainDocente = new MainDocente(UsuarioActual.ID);
                    mainDocente.ShowDialog();
                }
                // Si es administrador te manda a la pagina de administrador
                else if (tipoUsuario == 0)
                {
                    MainAdmin mainAdmin = new MainAdmin(UsuarioActual.ID);
                    mainAdmin.ShowDialog();
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Muestra la lista de mails de admin
            PersonasLogic pers = new PersonasLogic();
            List<Personas> PersonasAdmin = pers.getAllAdmins(); 
            string listaDeEmails = "";
            if (PersonasAdmin.Count>0){
                listaDeEmails += "Envie un mail con sus datos a un administrador: \n\n";
                foreach(Personas admin in PersonasAdmin)
                {
                    listaDeEmails += admin.Email;
                    listaDeEmails += "\n";
                }
                this.Notificar(listaDeEmails);
            }
            else
            {
                this.Notificar("No hay admins registrados");
            }
        }

        private void LogInForm_Shown(object sender, EventArgs e)
        {
            this.inpPassword.Text = "";
            this.inpUserName.Text = "";
        }
    }
}
