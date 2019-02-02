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
    //public partial class MainAlumno : ApplicationForm
    public partial class MainAlumno : MainUser
    {
        public MainAlumno()
        {
            this.InitializeComponent();
        }
        public MainAlumno(int idUsuario) : this()
        {
            UsuarioLogic usr = new UsuarioLogic();
            this.UsuarioActual = usr.GetOne(idUsuario);
            this.tipoFormulario = tipoForm.Alumno;
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            Cursos formCursos = new Cursos(this.UsuarioActual.ID);
            formCursos.ShowDialog();
        }

        private void btnEstadoAcademico_Click(object sender, EventArgs e)
        {
            EstadoAcademico formEstadoAcademico = new EstadoAcademico(this.UsuarioActual.ID);
            formEstadoAcademico.ShowDialog();
        }
    }
}