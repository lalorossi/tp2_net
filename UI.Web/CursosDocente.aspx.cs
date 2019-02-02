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
        
        private bool edicionHabilitada
        {
            get {
                if(this.ViewState["edicionHabilitada"] != null)
                {
                    return (bool)this.ViewState["edicionHabilitada"];
                }
                return false;
            }
            set { this.ViewState["edicionHabilitada"] = value; }
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
                    this.LoadGridCursos();
                }
            }

        }


        /* Métodos de entidad */

        /* -- Métodos de entidad -- */


        /* Métodos de la grilla de cursos */

        private void LoadGridCursos()
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

        /* -- Métodos de la grilla de cursos -- */


        /* Métodos de click de acciones de cursos */

        protected void verCursoLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.gridPanel.Visible = false;
                this.formPanel.Visible = true;
                this.EnableGridAlumnos();
                this.LoadGridAlumnos();
            }
        }

        /* -- Métodos de click de acciones de cursos -- */


        /* Métodos de grilla de alumnos */

        private void EnableGridAlumnos()
        {
            this.habilitarEdicionButton.Visible = true;
            this.aceptarLinkButton.Visible = false;
            this.habilitarEdicionButton.Enabled = true;
            this.aceptarLinkButton.Enabled = false;
            this.cancelarLinkButton.Text = "Atrás";
            this.edicionHabilitada = false;
        }

        private void LoadGridAlumnos()
        {
            // Carga en el formulario de edicion los datos del curso seleccionado
            if (this.IsPostBack)
            {
                List<AlumnoInscripcion> alumnosDelCurso = new AlumnosInscripcionLogic().FindAlumnos(this.SelectedId);
                this.gridViewAlumnos.DataSource = alumnosDelCurso;
                this.gridViewAlumnos.DataBind();
                //Le pone la nota a los alumnos en el dropdown
                foreach (AlumnoInscripcion ai in alumnosDelCurso)
                {
                    if (ai.Nota != 0)
                    {
                        foreach (GridViewRow row in this.gridViewAlumnos.Rows)
                        {
                            if(ai.IDAlumno == int.Parse(row.Cells[6].Text))
                            {
                                var dropDown = row.FindControl("dropNotas") as DropDownList;
                                dropDown.SelectedValue = ai.Nota.ToString();
                            }
                        }
                    }
                }

            }
            //Falta ver qué hace en el caso de que no haya alumnos
        }

        protected void gridViewAlumnos_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string idAlumno = e.Row.Cells[0].Text;

                // Cambia las id de alumnos por nombre apellido y legajo
                e.Row.Cells[0].Text = new PersonasLogic().GetOne(int.Parse(idAlumno)).Apellido;
                e.Row.Cells[1].Text = new PersonasLogic().GetOne(int.Parse(idAlumno)).Nombre;
                e.Row.Cells[2].Text = new PersonasLogic().GetOne(int.Parse(idAlumno)).Legajo.ToString();
                // e.Row.Cells[3].Text = new AlumnosInscripcionLogic().FindSingle(int.Parse(idAlumno), this.SelectedId).Nota.ToString();
                // e.Row.Cells[3].Text = new AlumnosInscripcionLogic().FindSingle(int.Parse(idAlumno), this.SelectedId).Condicion;

                var ddl = e.Row.FindControl("dropNotas") as DropDownList;
                if (ddl != null)
                {
                    ddl.DataSource = new List<string>() { "-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
                    ddl.DataBind();
                }

            }
        }

        /* -- Métodos de grilla de alumnos -- */


        /* Métodos de click de acciones de alumnos */
        
        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            //Inhabilita la edicion de nota
            this.edicionHabilitada = false;

            // Guarda los alumnos, si fuera necesario
            foreach (GridViewRow row in this.gridViewAlumnos.Rows)
            {
                AlumnosInscripcionLogic aiLogic = new AlumnosInscripcionLogic();
                AlumnoInscripcion ai = aiLogic.FindSingle(int.Parse(row.Cells[6].Text), this.SelectedId);
                var dropDown = row.FindControl("dropNotas") as DropDownList;
                string nuevaNota = dropDown.SelectedValue;
                if(nuevaNota == "-")
                {
                    nuevaNota = "0";
                    ai.Condicion = "Inscripto";
                }
                if (nuevaNota != ai.Nota.ToString())
                {
                    ai.Nota = int.Parse(dropDown.SelectedValue);
                    ai.fechaCambio = DateTime.Today;
                    ai.State = BusinessEntity.States.Modified;
                    if (ai.Nota < 6)
                        ai.Condicion = "No regular";
                    else if (ai.Nota < 8)
                        ai.Condicion = "Regular";
                    else
                        ai.Condicion = "Aprobado";
                    aiLogic.Save(ai);
                }
            }

            // Cambia los botones para habilitar edicion o cancelar
            this.cancelarLinkButton.Text = "Atrás";
            this.aceptarLinkButton.Visible = false;
            this.aceptarLinkButton.Enabled = false;
            this.habilitarEdicionButton.Visible = true;
            this.habilitarEdicionButton.Enabled = true;
            this.LoadGridAlumnos();
            this.LoadGridCursos();

        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.edicionHabilitada)
            {
                this.aceptarLinkButton.Visible = false;
                this.habilitarEdicionButton.Visible = true;
                this.aceptarLinkButton.Enabled = false;
                this.habilitarEdicionButton.Enabled = true;
                this.cancelarLinkButton.Text = "Atrás";

                // Habilita la edicion de nota
                foreach (GridViewRow row in this.gridViewAlumnos.Rows)
                {
                    var dropDown = row.FindControl("dropNotas") as DropDownList;
                    dropDown.Enabled = false;
                }
                this.LoadGridAlumnos();
            }
            else
            {
                this.gridPanel.Visible = true;
                this.formPanel.Visible = false;
            }
            this.edicionHabilitada = false;
        }

        protected void habilitarEdicionButton_Click(object sender, EventArgs e)
        {
            this.edicionHabilitada = true;

            // Habilita la edicion de nota
            foreach(GridViewRow row in this.gridViewAlumnos.Rows)
            {
                var dropDown = row.FindControl("dropNotas") as DropDownList;
                dropDown.Enabled = true;
            }

            // Cambia los botones para aceptar o cancelar edicion
            this.cancelarLinkButton.Text = "Cancelar Edicion";
            this.habilitarEdicionButton.Visible = false;
            this.habilitarEdicionButton.Enabled = false;
            this.aceptarLinkButton.Visible = true;
            this.aceptarLinkButton.Enabled = true;
        }

        /* -- Métodos de click de acciones de alumnos -- */


    }
}