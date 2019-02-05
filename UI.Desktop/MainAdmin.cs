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
    //public partial class MainAdmin : ApplicationForm
    public partial class MainAdmin : MainUser
    {
        public MainAdmin()
        {
            this.InitializeComponent();
        }
        public MainAdmin(int idUsuario) : this()
        {
            UsuarioLogic usr = new UsuarioLogic();
            this.UsuarioActual = usr.GetOne(idUsuario);
            this.tipoFormulario = tipoForm.Admin;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios formUsuarios = new Usuarios();
            formUsuarios.Show();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            Cursos formCursos = new Cursos();
            formCursos.Show();
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades formEspecialidades = new Especialidades();
            formEspecialidades.Show();
        }

        private void btnReportesCursos_Click(object sender, EventArgs e)
        {
            FormReporteCursos formReporteCursos = new FormReporteCursos();
            formReporteCursos.Show();
        }

        private void btnReportesPlanes_Click(object sender, EventArgs e)
        {
            FormReportePlanes formReportePlanes = new FormReportePlanes();
            formReportePlanes.Show();
        }
    }
}