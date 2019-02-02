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
    public partial class CursosDocente : GlobalForm
    {
        private Personas _docenteActual;
        public Personas DocenteActual { get => _docenteActual; set => _docenteActual = value; }

        private PersonasLogic _personaLogic;
        private PersonasLogic PersonaLogic
        {
            get
            {
                if (_personaLogic == null)
                {
                    _personaLogic = new PersonasLogic();
                }
                return _personaLogic;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DocenteActual = PersonaLogic.GetOne(this.currentUserId);
            this.tipoFormulario = tipoForm.Docente;
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
            // Carga la grilla con los cursos del docente
            DocenteCursoLogic DCLogic = new DocenteCursoLogic();
            CursoLogic CrsLogic = new CursoLogic();
            AlumnosInscripcionLogic alumnosInscripcionLogic = new AlumnosInscripcionLogic();
            List<DocenteCurso> CursosDelDocente = DCLogic.FindCursos(this.currentUserId);
            List<Curso> Cursos = new List<Curso>();
            int alumnos = 0;
            foreach (DocenteCurso dc in CursosDelDocente)
            {
                Cursos.Add(CrsLogic.GetOne(dc.IDCurso));
                alumnos = alumnosInscripcionLogic.FindAlumnos(dc.IDCurso).Count;
            }
            this.gridView.DataSource = Cursos;
            this.gridView.DataBind();
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

                string idMateria = e.Row.Cells[1].Text;
                string idComision = e.Row.Cells[2].Text;

                e.Row.Cells[1].Text = new MateriaLogic().GetOne(int.Parse(idMateria)).Descripcion;
                e.Row.Cells[2].Text = new ComisionLogic().GetOne(int.Parse(idComision)).Descripcion;
                // Cambiar el cupo por la cantidad de alumnos inscriptos

                DocenteCursoLogic DCLogic = new DocenteCursoLogic();
                AlumnosInscripcionLogic alumnosInscripcionLogic = new AlumnosInscripcionLogic();
                List<DocenteCurso> CursosDelDocente = DCLogic.FindCursos(this.currentUserId);
                int alumnos = 0;
                foreach (DocenteCurso dc in CursosDelDocente)
                {
                    alumnos = alumnosInscripcionLogic.FindAlumnos(dc.IDCurso).Count;
                }
                e.Row.Cells[3].Text = alumnos.ToString();
            }
        }

        /* Métodos de click de grilla de cursos */
        protected void verCursoLinkButton_Click(object sender, EventArgs e)
        {
            /*
            if (this.IsEntitySelected)
            {
                this.gridPanel.Visible = false;
                this.formPanel.Visible = true;
                this.EnableForm(false);
                this.LoadForm(this.SelectedId);

                //Cambia el texto del boton aceptar por "Inscribir" o "Anular inscripcion"
                PersonasLogic persLogic = new PersonasLogic();
                List<AlumnoInscripcion> inscripciondesDeAlumno = AlumnosInscripcionLogic.FindCursos((int)Session["currentUserID"]);

                this.aceptarLinkButton.Text = "Inscribir";
                this.ViewState["AluInscripcionActualState"] = BusinessEntity.States.New.ToString();
                foreach (AlumnoInscripcion ai in inscripciondesDeAlumno)
                {
                    if (ai.IDCurso == this.SelectedId)
                    {
                        this.aceptarLinkButton.Text = "Anular Inscripcion";
                        this.ViewState["AluInscripcionActualID"] = ai.ID;
                        this.ViewState["AluInscripcionActualState"] = BusinessEntity.States.Deleted.ToString();
                        break;
                    }
                }
            }
            */
        }
        /* -- Métodos de click de grilla de cursos -- */

        /* Métodos de click de grilla de edición */
        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            /*
            //Antes de fijarse el modo del formulario se fija si hay un alumno para inscripcion
            if ((bool)this.ViewState["registryModeOn"])
            {
                this.CursoActual = this.CrsLogic.GetOne(this.SelectedId);

                // Guarda el estado de la inscripcion, fijandose en State

                if (this.ViewState["AluInscripcionActualState"].ToString() == BusinessEntity.States.New.ToString())
                {
                    AlumnoInscripcion AluInscripcionActual = new AlumnoInscripcion();
                    List<AlumnoInscripcion> alumnosDeCurso = AlumnosInscripcionLogic.FindAlumnos(this.SelectedId);
                    if (alumnosDeCurso.Count >= this.CursoActual.Cupo)
                    {
                        // Si es una inscripcion nueva, se fija en el cupo del curso
                        Notificar("No hay cupo suficiente para inscribirse al curso");
                    }
                    else
                    {
                        AluInscripcionActual.Condicion = "inscripto";
                        AluInscripcionActual.IDCurso = this.SelectedId;
                        AluInscripcionActual.IDAlumno = (int)Session["currentUserID"];
                        AlumnosInscripcionLogic.Save(AluInscripcionActual);
                    }
                }
                if (this.ViewState["AluInscripcionActualState"].ToString() == BusinessEntity.States.Deleted.ToString())
                {
                    //Debería confirmar
                    AlumnosInscripcionLogic.Delete((int)this.ViewState["AluInscripcionActualID"]);
                }
            }
            else
            {
                switch (this.FormMode)
                {
                    case FormModes.Baja:
                        //Primero debería borrar la relacion asociada
                        this.DocenteCursoActual = new DocenteCurso();
                        this.DocenteCursoActual.ID = this.DocCursoLogic.FindDocente(this.SelectedId).ID;
                        this.DocenteCursoActual.State = BusinessEntity.States.Deleted;
                        this.DocCursoLogic.Save(this.DocenteCursoActual);
                        //Borra las inscripciones del curso y después el curso en sí
                        //AlumnosInscripcionLogic.Delete((int)this.ViewState["AluInscripcionActualID"]);
                        foreach (AlumnoInscripcion ai in AlumnosInscripcionLogic.FindAlumnos(this.SelectedId))
                        {
                            AlumnosInscripcionLogic.Delete(ai.ID);
                        }
                        this.DeleteEntity(this.SelectedId);
                        this.LoadGrid();
                        break;
                    case FormModes.Modificacion:
                        if (this.ValidarCurso())
                        {
                            this.CursoActual = new Curso();
                            this.CursoActual.ID = this.SelectedId;
                            this.CursoActual.State = BusinessEntity.States.Modified;
                            this.LoadEntity(this.CursoActual);
                            this.SaveEntity(this.CursoActual);

                            //Una vez guardado el curso, actualizo la relacion
                            this.DocenteCursoActual = new DocenteCurso();
                            this.DocenteCursoActual.ID = this.DocCursoLogic.FindDocente(this.CursoActual.ID).ID;
                            this.DocenteCursoActual.IDCurso = this.CursoActual.ID;
                            this.DocenteCursoActual.IDDocente = int.Parse(dropDocente.SelectedValue);
                            this.DocenteCursoActual.Cargo = 0;
                            this.DocenteCursoActual.State = BusinessEntity.States.Modified;
                            this.DocCursoLogic.Save(this.DocenteCursoActual);

                            this.LoadGrid();
                        }
                        break;
                    case FormModes.Alta:
                        if (this.ValidarCurso())
                        {
                            this.CursoActual = new Curso();
                            this.LoadEntity(this.CursoActual);
                            this.SaveEntity(this.CursoActual);

                            //Una vez creado el curso, creo la relacion
                            this.DocenteCursoActual = new DocenteCurso();
                            this.DocenteCursoActual.IDCurso = this.CursoActual.ID;
                            this.DocenteCursoActual.IDDocente = int.Parse(dropDocente.SelectedValue);
                            this.DocenteCursoActual.Cargo = 0;
                            this.DocenteCursoActual.State = BusinessEntity.States.New;
                            this.DocCursoLogic.Save(this.DocenteCursoActual);

                            this.LoadGrid();
                        }
                        break;
                    default:
                        break;
                }
            }

            this.gridPanel.Visible = true;
            this.formPanel.Visible = false;
            */
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            /*
            this.gridPanel.Visible = true;
            this.ClearForm();
            this.EnableForm(false);
            this.formPanel.Visible = false;
            */
        }
    }
}