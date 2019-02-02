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
    //public partial class MainDocente : ApplicationForm
    public partial class MainDocente : MainUser
    {
        public MainDocente()
        {
            this.InitializeComponent();
        }
        public MainDocente(int idUsuario) : this()
        {
            UsuarioLogic usr = new UsuarioLogic();
            this.UsuarioActual = usr.GetOne(idUsuario);
            this.tipoFormulario = tipoForm.Docente;
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            CursosDocente formCursosDocente = new CursosDocente(this.UsuarioActual.ID);
            formCursosDocente.ShowDialog();
        }
    }
}