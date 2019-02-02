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
    public partial class EspecialidadDesktop : UI.Desktop.ApplicationForm
    {
        private Especialidad _EspecialidadActual;
        public Especialidad EspecialidadActual
        {
            get { return _EspecialidadActual; }
            set { _EspecialidadActual = value; }
        }
        public EspecialidadDesktop()
        {
            InitializeComponent();
        }
        public EspecialidadDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }
        public EspecialidadDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            EspecialidadLogic usr = new EspecialidadLogic();
            this.EspecialidadActual = usr.GetOne(ID);
            this.MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion.ToString();
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
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
                this.txtDescripcion.ReadOnly = true;
                this.btnCancelar.Select();
            }
        }
        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                if (this.Modo == ModoForm.Alta)
                {
                    EspecialidadActual = new Especialidad();
                }
            }
            this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
            if (this.Modo == ModoForm.Alta)
            {
                EspecialidadActual.State = BusinessEntity.States.New;
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                EspecialidadActual.State = BusinessEntity.States.Modified;
            }
            if (this.Modo == ModoForm.Consulta)
            {
                EspecialidadActual.State = BusinessEntity.States.Unmodified;
            }
            if (this.Modo == ModoForm.Baja)
            {
                EspecialidadActual.State = BusinessEntity.States.Deleted;
            }
        }
        public override bool Validar()
        {
            if (this.txtDescripcion.Text != "")
            {
                return true;
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
            EspecialidadLogic usr = new EspecialidadLogic();
            usr.Save(EspecialidadActual);
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
