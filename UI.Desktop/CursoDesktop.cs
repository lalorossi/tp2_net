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
    public partial class CursoDesktop : UI.Desktop.ApplicationForm
    {
        private Curso _CursoActual;
        public Curso CursoActual
        {
            get { return _CursoActual; }
            set { _CursoActual = value; }
        }
        private DocenteCurso _DocCursoActual;
        public DocenteCurso DocCursoActual
        {
            get { return _DocCursoActual; }
            set { _DocCursoActual = value; }
        }
        private AlumnoInscripcion _AluInscripcionActual;
        public AlumnoInscripcion AluInscripcionActual
        {
            get { return _AluInscripcionActual; }
            set { _AluInscripcionActual = value; }
        }
        private int IDAlumno;
        public CursoDesktop()
        {
            InitializeComponent();
            MateriaLogic matLogic = new MateriaLogic();
            this.cbMateria.DataSource = matLogic.GetAll();
            this.cbMateria.DisplayMember = "Descripcion";
            this.cbMateria.ValueMember = "ID";
            this.cbMateria.SelectedItem = null;
            //this.cbMateria.DataBind();

            ComisionLogic comLogic = new ComisionLogic();
            this.cbComision.DataSource = comLogic.GetAll();
            this.cbComision.DisplayMember = "Descripcion";
            this.cbComision.ValueMember = "ID";
            this.cbComision.SelectedItem = null;
            //this.cbComision.DataBind();

            PersonasLogic docLogic = new PersonasLogic();
            this.cbDocente.DataSource = docLogic.getAllDocentes();
            this.cbDocente.DisplayMember = "Descripcion";
            this.cbDocente.ValueMember = "ID";
            this.cbDocente.SelectedItem = null;
            //this.cbComision.DataBind();
            
            DocenteCursoLogic DocCursoLogic = new DocenteCursoLogic();
        }
        public CursoDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }
        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            CursoLogic cur = new CursoLogic();
            this.CursoActual = cur.GetOne(ID);
            this.MapearDeDatos();
        }
        public CursoDesktop(int IDCurso, int IDAlumno) : this()
        {
            this.Modo = ModoForm.Consulta;
            CursoLogic cur = new CursoLogic();
            this.CursoActual = cur.GetOne(IDCurso);
            this.IDAlumno = IDAlumno;
            this.MapearDeDatos();
            this.Text = "Inscripción a curso";
        }
        public override void MapearDeDatos()
        {
            this.cbComision.SelectedValue = this.CursoActual.IDComision;
            this.cbMateria.SelectedValue= this.CursoActual.IDMateria;

            // Acá tiene que buscar el docente en docentes_cursos
            DocenteCursoLogic DocCursoLogic = new DocenteCursoLogic();
            DocCursoActual = DocCursoLogic.FindDocente(CursoActual.ID);
            this.cbDocente.SelectedValue = DocCursoActual.IDDocente;

            this.numAnio.Value= this.CursoActual.AnioCalendario;
            this.numCupo.Value = this.CursoActual.Cupo;
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.cbComision.Enabled = false;
                this.cbMateria.Enabled = false;
                this.cbDocente.Enabled = false;
                this.numAnio.Enabled = false;
                this.numCupo.Enabled = false;
            }
            else if (this.Modo == ModoForm.Consulta)
            {
                this.cbComision.Enabled = false;
                this.cbMateria.Enabled = false;
                this.cbDocente.Enabled = false;
                this.numAnio.Enabled = false;
                this.numCupo.Enabled = false;

                //El boton cambia el nombre dependiendo si está inscripto o no
                AlumnosInscripcionLogic aluInscripcionLogic = new AlumnosInscripcionLogic();
                List<AlumnoInscripcion> inscripciondesDeAlumno = aluInscripcionLogic.FindCursos(this.IDAlumno);

                this.btnAceptar.Text = "Inscribir";
                this.AluInscripcionActual = new AlumnoInscripcion();
                this.AluInscripcionActual.State = BusinessEntity.States.New;
                foreach (AlumnoInscripcion ai in inscripciondesDeAlumno)
                {
                    if(ai.IDCurso == this.CursoActual.ID)
                    {
                        this.btnAceptar.Text = "Anular Inscripcion";
                        this.AluInscripcionActual = ai;
                        this.AluInscripcionActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
                }
            }
        }
        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                if (this.Modo == ModoForm.Alta)
                {
                    CursoActual = new Curso();
                    DocCursoActual = new DocenteCurso();
                }
                CursoActual.AnioCalendario = (int)this.numAnio.Value;
                CursoActual.IDComision = (int)this.cbComision.SelectedValue;
                CursoActual.IDMateria = (int)this.cbMateria.SelectedValue;
                CursoActual.Cupo = (int)this.numCupo.Value;

                DocCursoActual.IDDocente = (int)this.cbDocente.SelectedValue;
                DocCursoActual.Cargo = 0;
            }
            if (this.Modo == ModoForm.Alta)
            {
                CursoActual.State = BusinessEntity.States.New;
                DocCursoActual.State = BusinessEntity.States.New;
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                CursoActual.State = BusinessEntity.States.Modified;
                DocCursoActual.State = BusinessEntity.States.Modified;
            }
            if (this.Modo == ModoForm.Consulta)
            {
                CursoActual.State = BusinessEntity.States.Unmodified;
                DocCursoActual.State = BusinessEntity.States.Unmodified;
            }
            if (this.Modo == ModoForm.Baja)
            {
                CursoActual.State = BusinessEntity.States.Deleted;
                DocCursoActual.State = BusinessEntity.States.Deleted;
            }
        }
        public override bool Validar()
        {
            MateriaLogic matLogic = new MateriaLogic();
            Materia MateriaActual = matLogic.GetOne((int)this.cbMateria.SelectedValue);

            ComisionLogic comLogic = new ComisionLogic();
            Comision ComisionActual = comLogic.GetOne((int)this.cbComision.SelectedValue);

            if (ComisionActual.IDPlan == MateriaActual.IDPlan)
            {
                return true;
            }
            else
            {
                Notificar("La materia y la comision no pertenecen al mismo plan");
                return false;
            }
        }
        public override void GuardarCambios()
        {
            if(this.Modo == ModoForm.Consulta)
            {
                // Si estoy haciendo una inscripcion, no guardo el curso sino la nueva inscripcion
                AlumnosInscripcionLogic aluInscripcionLogic = new AlumnosInscripcionLogic();
                // Si es una inscripcion nueva, se fija en el cupo del curso
                if(this.AluInscripcionActual.State == BusinessEntity.States.New)
                {
                    List<AlumnoInscripcion> alumnosDeCurso = aluInscripcionLogic.FindAlumnos(this.CursoActual.ID);
                    if (alumnosDeCurso.Count >= this.CursoActual.Cupo)
                    {
                        Notificar("No hay cupo suficiente para inscribirse al curso");
                    }
                    else
                    {
                        this.AluInscripcionActual.Condicion = "Inscripto";
                        this.AluInscripcionActual.IDCurso = this.CursoActual.ID;
                        this.AluInscripcionActual.IDAlumno = this.IDAlumno;
                        this.AluInscripcionActual.fechaCambio = new DateTime(1900,1,1);
                        aluInscripcionLogic.Save(this.AluInscripcionActual);
                    }
                }
                if(this.AluInscripcionActual.State == BusinessEntity.States.Deleted)
                {
                    //Debería confirmar
                    aluInscripcionLogic.Delete(this.AluInscripcionActual.ID);
                }
            }
            else
            {
                this.MapearADatos();
                CursoLogic cur = new CursoLogic();
                DocenteCursoLogic dc = new DocenteCursoLogic();
                AlumnosInscripcionLogic ai = new AlumnosInscripcionLogic();
                if(this.Modo != ModoForm.Baja)
                {
                    // Primero guarda el curso y después asigna la nueva id a la relacion
                    cur.Save(CursoActual);
                    DocCursoActual.IDCurso = CursoActual.ID;
                    dc.Save(DocCursoActual);
                }
                else
                {
                    // Primero borra la relacion
                    dc.Save(DocCursoActual);
                    // También tiene que borrar las relaciones de alumnos con el curso
                    foreach(AlumnoInscripcion AluInscripcion in ai.FindAlumnos(CursoActual.ID))
                    {
                        AluInscripcion.State = BusinessEntity.States.Deleted;
                        ai.Save(AluInscripcion);
                    }
                    cur.Save(CursoActual);
                }
            }
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
