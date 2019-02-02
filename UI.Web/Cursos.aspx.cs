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
    public partial class Cursos : GlobalForm
    {
        CursoLogic _CrsLogic;
        private CursoLogic CrsLogic
        {
            get
            {
                if (_CrsLogic == null)
                {
                    _CrsLogic = new CursoLogic();
                }
                return _CrsLogic;
            }
        }
        private Curso CursoActual;

        DocenteCursoLogic _DocCursoLogic;
        private DocenteCursoLogic DocCursoLogic
        {
            get
            {
                if (_DocCursoLogic == null)
                {
                    _DocCursoLogic  = new DocenteCursoLogic();
                }
                return _DocCursoLogic;
            }
        }
        private DocenteCurso DocenteCursoActual;

        AlumnosInscripcionLogic _AlumnosInscripcionLogic;
        private AlumnosInscripcionLogic AlumnosInscripcionLogic
        {
            get
            {
                if (_AlumnosInscripcionLogic == null)
                {
                    _AlumnosInscripcionLogic = new AlumnosInscripcionLogic();
                }
                return _AlumnosInscripcionLogic;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.tipoFormulario = tipoForm.Admin;
            if (!this.IsPostBack)
            {
                this.ViewState["registryModeOn"] = false;
                if (this.Context.Items["registryModeOn"] != null)
                {
                    this.ViewState["registryModeOn"] = (bool)this.Context.Items["registryModeOn"]; 
                    // Si un usuario llegó a la página para inscribirse a un curso
                    if ((bool)this.ViewState["registryModeOn"])
                    {
                        // Cambia las opciones de admin por el boton "ver curso"
                        this.editarLinkButton.Visible = false;
                        this.editarLinkButton.Enabled = false;
                        this.nuevoLinkButton.Visible = false;
                        this.nuevoLinkButton.Enabled = false;
                        this.eliminarLinkButton.Visible = false;
                        this.eliminarLinkButton.Enabled = false;
                        this.verCursoLinkButton.Visible = true;
                        this.verCursoLinkButton.Enabled = true;

                        this.LoadGrid();
                    }
                }
                else if (!this.ValidarPermisos())
                {
                    //Trata de validar al tipo de usuario en la página o lo devuelve al login
                    Response.Redirect("LogInForm.aspx");
                }
                else
                {
                    this.LoadGrid();
                }
                MateriaLogic matLogic = new MateriaLogic();
                this.dropMaterias.DataSource = matLogic.GetAll();
                this.dropMaterias.DataTextField = "Descripcion";
                this.dropMaterias.DataValueField = "ID";
                this.dropMaterias.DataBind();

                ComisionLogic comLogic = new ComisionLogic();
                this.dropComisiones.DataSource = comLogic.GetAll();
                this.dropComisiones.DataTextField = "Descripcion";
                this.dropComisiones.DataValueField = "ID";
                this.dropComisiones.DataBind();

                PersonasLogic docente = new PersonasLogic();
                this.dropDocente.DataSource = docente.getAllDocentes();
                this.dropDocente.DataTextField = "Descripcion";
                this.dropDocente.DataValueField = "ID";
                this.dropDocente.DataBind();
            }

        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.CrsLogic.GetAll();
            this.gridView.DataBind();
        }

        private void LoadForm(int id)
        {
            // Carga en el formulario de edicion los datos del curso seleccionado
            if (this.IsPostBack)
            {
                this.CursoActual = this.CrsLogic.GetOne(id);
                int idMateria = CursoActual.IDMateria;
                int idComision= CursoActual.IDComision;
                int anioCursado = CursoActual.AnioCalendario;
                int cupo = CursoActual.Cupo;
                int idDocCurso = this.DocCursoLogic.FindDocente(id).IDDocente;

                this.anioCursadoTextBox.Text = anioCursado.ToString();
                this.cupoTextBox.Text = cupo.ToString();
                this.dropComisiones.SelectedValue = idComision.ToString();
                this.dropMaterias.SelectedValue = idMateria.ToString();
                this.dropDocente.SelectedValue = idDocCurso.ToString();
            }
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

                string idMateria = e.Row.Cells[0].Text;
                string idComision = e.Row.Cells[1].Text;

                e.Row.Cells[0].Text =  new MateriaLogic().GetOne(int.Parse(idMateria)).Descripcion;
                e.Row.Cells[1].Text =  new ComisionLogic().GetOne(int.Parse(idComision)).Descripcion;
            }
        }


        /* Metodos de entidad */
        public void LoadEntity(Curso curso)
        {
            //Guarda los datos en pantalla en un objeto curso
            curso.IDMateria = int.Parse(this.dropMaterias.SelectedValue);
            curso.IDComision = int.Parse(this.dropComisiones.SelectedValue);
            curso.AnioCalendario = int.Parse(this.anioCursadoTextBox.Text);
            curso.Cupo = int.Parse(this.cupoTextBox.Text);
        }

        private void SaveEntity(Curso curso)
        {
            // Guarda el curso en DB
            this.CrsLogic.Save(curso);
        }

        private void DeleteEntity(int id)
        {
            // Borra el curso en DB
            this.CrsLogic.Delete(id);
        }
        /* -- Metodos de entidad -- */

        /* Métodos de formulario */
        private void EnableForm(bool enable)
        {
            {
                this.dropMaterias.Enabled = enable;
                this.dropComisiones.Enabled = enable;
                this.dropDocente.Enabled = enable;
                this.anioCursadoTextBox.Enabled = enable;
                this.cupoTextBox.Visible = enable;
            }
        }

        private void ClearForm()
        {
            this.cupoTextBox.Text = string.Empty;
            this.anioCursadoTextBox.Text = string.Empty;
        }
        /* -- Métodos de formulario -- */

        /* Métodos de click de grilla de cursos */
        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.gridPanel.Visible = false;
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.gridPanel.Visible = false;
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedId);
            }
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.gridPanel.Visible = false;
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedId);
            }
        }

        protected void verCursoLinkButton_Click(object sender, EventArgs e)
        {
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
        }
        /* -- Métodos de click de grilla de usuarios -- */

        /* Métodos de click de grilla de edición */
        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
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
                        AluInscripcionActual.fechaCambio = new DateTime(1900, 1, 1);
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
                        foreach(AlumnoInscripcion ai in AlumnosInscripcionLogic.FindAlumnos(this.SelectedId))
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
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.gridPanel.Visible = true;
            this.ClearForm();
            this.EnableForm(false);
            this.formPanel.Visible = false;
        }
        /* -- Métodos de click de grilla de edición -- */

        protected bool ValidarCurso()
        {
            MateriaLogic matLogic = new MateriaLogic();
            Materia MateriaActual = matLogic.GetOne(int.Parse(this.dropMaterias.SelectedValue));

            ComisionLogic comLogic = new ComisionLogic();
            Comision ComisionActual = comLogic.GetOne(int.Parse(this.dropComisiones.SelectedValue));

            if(ComisionActual.IDPlan == MateriaActual.IDPlan)
            {
                return true;
            }
            else
            {
                Notificar("La materia y la comision no pertenecen al mismo plan");
                return false;
            }

        }
    }
}