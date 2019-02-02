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
    public partial class UsuarioDesktop : UI.Desktop.ApplicationForm
    {
        private Usuario _UsuarioActual;
        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }
        public UsuarioDesktop()
        {
            InitializeComponent();
        }
        public UsuarioDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }
        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            UsuarioLogic usr = new UsuarioLogic();
            this.UsuarioActual = usr.GetOne(ID);
            this.MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.txtNombre.Text  = this.UsuarioActual.Nombre.ToString();
            this.txtApellido.Text = this.UsuarioActual.Apellido.ToString();
            this.txtEmail.Text = this.UsuarioActual.EMail.ToString();
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtClave.Text = this.UsuarioActual.Clave.ToString();
            this.txtConfirmarClave.Text = "";
            if(this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            if (this.Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
            if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.txtNombre.ReadOnly = true;
                this.txtApellido.ReadOnly = true;
                this.txtUsuario.ReadOnly = true;
                this.txtEmail.ReadOnly = true;
                this.txtClave.Text = "";
                this.txtClave.Select();

            }
        }
        public override void  MapearADatos()
        {
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {   
                if(this.Modo == ModoForm.Alta)
                {
                    UsuarioActual = new Usuario();
                }
                UsuarioActual.Nombre = this.txtNombre.Text;
                UsuarioActual.Apellido = this.txtApellido.Text;
                UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                UsuarioActual.EMail = this.txtEmail.Text;
                UsuarioActual.Clave = this.txtClave.Text;
            }
            if (this.Modo == ModoForm.Alta)
            {
                UsuarioActual.State = BusinessEntity.States.New;
            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                UsuarioActual.State = BusinessEntity.States.Modified;
            }
            else if (this.Modo == ModoForm.Consulta)
            {
                UsuarioActual.State = BusinessEntity.States.Unmodified;
            }
            else if (this.Modo == ModoForm.Baja)
            {
                UsuarioActual.State = BusinessEntity.States.Deleted;
            }
        }
        public override bool Validar() {
            if(this.txtNombre.Text!="" && this.txtApellido.Text!="" && this.txtUsuario.Text != "")
            {
                if(this.txtClave.Text.Length >= 8 && this.txtConfirmarClave.Text.Length >= 8)
                {
                    if(this.txtClave.Text == this.txtConfirmarClave.Text)
                    {
                        return true;
                    }
                        this.Notificar("No coinciden las claves", new MessageBoxButtons(), new MessageBoxIcon());
                }
                else
                {
                    this.Notificar("La clave debe tener al menos 8 caracteres", new MessageBoxButtons(), new MessageBoxIcon());
                }
            }
            else
            {
                this.Notificar("Deben completarse todos los campos", new MessageBoxButtons(), new MessageBoxIcon());
            }
            return false;
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            UsuarioLogic usr = new UsuarioLogic();
            usr.Save(UsuarioActual);
        }
        public override void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public override void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
