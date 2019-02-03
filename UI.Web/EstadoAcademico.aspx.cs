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
    public partial class EstadoAcademico : GlobalForm
    {

        private Personas _alumnoActual;
        public Personas AlumnoActual { get => _alumnoActual; set => _alumnoActual = value; }

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
        
        //private bool[] filtrosAplicados = { false, false, false };

        private bool[] filtrosAplicados
        {
            get
            {
                if(this.ViewState["filtrosAplicados"] == null)
                {
                    this.ViewState["filtrosAplicados"] = new bool[] { false, false, false };
                    return new bool[] { false, false, false };
                }
                else
                {
                    return (bool[])this.ViewState["filtrosAplicados"];
                }
            }
            set
            {
                this.ViewState["filtrosAplicados"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.AlumnoActual = this.PersonaLogic.GetOne(this.currentUserId);
            this.tipoFormulario = tipoForm.Alumno;
            if (!this.IsPostBack)
            {
                if (!this.ValidarPermisos())
                {
                    //Trata de validar al tipo de usuario en la página o lo devuelve al login
                    Response.Redirect("LogInForm.aspx");
                }
                else
                {
                    this.filtrosAplicados[0] = false;
                    this.filtrosAplicados[1] = false;
                    this.filtrosAplicados[2] = false;
                    this.LoadGridCursos();
                    this.llenarDropDowns();
                    this.escribirPromedio();
                }
            }
        }



        /* Métodos de entidad */
        /* -- Métodos de entidad -- */


        /* Métodos de la grilla de cursos */

        private void LoadGridCursos()
        {

            // Carga la grilla con los cursos del alumno
            List<AlumnoInscripcion> CursosDelAlumno = new AlumnosInscripcionLogic().FindCursos(this.AlumnoActual.ID);
            this.gridViewCursos.DataSource = CursosDelAlumno;
            this.gridViewCursos.DataBind();
        }

        protected void gridViewCursos_DataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            // Año, Comisión, Materia, Profesor, Estado, Nota, Fecha de Modificacion
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string idCurso = e.Row.Cells[0].Text;
                Curso cursoActual = new CursoLogic().GetOne(int.Parse(idCurso));

                // Cambia las id de alumnos por las descripciones de los objetos
                e.Row.Cells[0].Text = cursoActual.AnioCalendario.ToString();
                e.Row.Cells[1].Text = new ComisionLogic().GetOne(cursoActual.IDComision).Descripcion;
                e.Row.Cells[2].Text = new MateriaLogic().GetOne(cursoActual.IDMateria).Descripcion;
                e.Row.Cells[3].Text = new PersonasLogic().GetOne(new DocenteCursoLogic().FindDocente(cursoActual.ID).IDDocente).Descripcion;
                //e.Row.Cells[6].Text = DateTime.Parse(e.Row.Cells[6].Text).ToShortDateString();
                if(DateTime.Parse(e.Row.Cells[6].Text).ToShortDateString() == "1/1/1900")
                {
                    e.Row.Cells[6].Text = "-";
                }
                else
                {
                    e.Row.Cells[6].Text = DateTime.Parse(e.Row.Cells[6].Text).ToShortDateString();
                }
                e.Row.Cells[5].Text = e.Row.Cells[5].Text == "0" ? "-" : e.Row.Cells[5].Text;
            }
        }

        private void escribirPromedio()
        {
            float promedio = 0;
            int cant = 0;
            for (int u = 0; u < this.gridViewCursos.Rows.Count; u++)
            {
                if (this.gridViewCursos.Rows[u].Visible == true && this.gridViewCursos.Rows[u].Cells[5].Text != "-")
                {
                    promedio += int.Parse(this.gridViewCursos.Rows[u].Cells[5].Text);
                    cant++;
                }
            }
            this.SpanTitulo.InnerText = cant == 0 ? "Sin notas" : "Promedio total: " + promedio.ToString();
        }

        /* -- Métodos de la grilla de cursos -- */


        /* Métodos de panel de filtros */

        private void llenarDropDowns()
        {
            List<string> dataSourceComisiones = new List<string>();
            List<string> dataSourceAño = new List<string>();


            // Carga el primer miembro de los dropdown
            dataSourceAño.Add("Filtrar por año");
            dataSourceComisiones.Add("Filtrar por comisión");
            
            foreach(GridViewRow row in this.gridViewCursos.Rows)
            {
                dataSourceAño.Add(row.Cells[0].Text);
                dataSourceComisiones.Add(row.Cells[1].Text);
            }
            List<string> dataSourceEstado = new List<string> { "Filtrar por estado", "Inscripto", "No regular", "Regular", "Aprobado" };
            this.dropFiltroAño.DataSource = dataSourceAño;
            this.dropFiltroComision.DataSource = dataSourceComisiones;
            this.dropFiltroEstado.DataSource = dataSourceEstado;


            this.dropFiltroComision.DataBind();
            this.dropFiltroEstado.DataBind();
            this.dropFiltroAño.DataBind();
        }

        protected void chkFiltroEstado_CheckedChanged(object sender, EventArgs e)
        {
            this.filtrosAplicados[0] = !this.filtrosAplicados[0];
            this.aplicarFiltros();
            // Notificar(this.filtrosAplicados[0].ToString() + "_" + this.filtrosAplicados[1].ToString() + "_" + this.filtrosAplicados[2].ToString());
        }

        protected void chkFiltroAño_CheckedChanged(object sender, EventArgs e)
        {
            this.filtrosAplicados[1] = !this.filtrosAplicados[1];
            this.aplicarFiltros();
            // Notificar(this.filtrosAplicados[0].ToString() + "_" + this.filtrosAplicados[1].ToString() + "_" + this.filtrosAplicados[2].ToString());
        }

        protected void chkFiltroComision_CheckedChanged(object sender, EventArgs e)
        {
            this.filtrosAplicados[2] = !this.filtrosAplicados[2];
            this.aplicarFiltros();
            // Notificar(this.filtrosAplicados[0].ToString() + "_" + this.filtrosAplicados[1].ToString() + "_" + this.filtrosAplicados[2].ToString());
        }

        protected void dropFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dropFiltroEstado.SelectedIndex == 0)
            {
                this.chkFiltroEstado.Checked = false;
                this.chkFiltroEstado.Enabled = false;
                this.filtrosAplicados[0] = false;
            }
            else
            {
                this.chkFiltroEstado.Enabled = true;
                if (this.filtrosAplicados[0])
                {
                    this.aplicarFiltros();
                }
            }
        }

        protected void dropFiltroAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dropFiltroAño.SelectedIndex == 0)
            {
                this.chkFiltroAño.Checked = false;
                this.chkFiltroAño.Enabled = false;
                this.filtrosAplicados[1] = false;
            }
            else
            {
                this.chkFiltroAño.Enabled = true;
                if (this.filtrosAplicados[1])
                {
                    this.aplicarFiltros();
                }
            }
        }

        protected void dropFiltroComision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dropFiltroComision.SelectedIndex == 0)
            {
                this.chkFiltroComision.Checked = false;
                this.chkFiltroComision.Enabled = false;
                this.filtrosAplicados[2] = false;
            }
            else
            {
                this.chkFiltroComision.Enabled = true;
                if (this.filtrosAplicados[2])
                {
                    this.aplicarFiltros();
                }
            }
        }

        void aplicarFiltros()
        {
            // Saca los filtros (muestra todos  cursos)
            this.LoadGridCursos();
            int cantFiltros = 0;
            if (this.filtrosAplicados[0] || this.filtrosAplicados[1] || this.filtrosAplicados[2])
            {
                // Aplica el filtro
                for (int u = 0; u < this.gridViewCursos.Rows.Count; u++)
                {
                    if (this.filtrosAplicados[0])
                    {
                        if (this.gridViewCursos.Rows[u].Cells[4].Text.ToString() != this.dropFiltroEstado.SelectedValue.ToString())
                        {
                            this.gridViewCursos.Rows[u].Visible = false;
                        }
                    }
                    if (this.filtrosAplicados[1])
                    {
                        if (this.gridViewCursos.Rows[u].Cells[0].Text.ToString() != this.dropFiltroAño.SelectedValue.ToString())
                        {
                            this.gridViewCursos.Rows[u].Visible = false;
                        }
                    }
                    if (this.filtrosAplicados[2])
                    {
                        if (this.gridViewCursos.Rows[u].Cells[1].Text.ToString() != this.dropFiltroComision.SelectedValue.ToString())
                        {
                            this.gridViewCursos.Rows[u].Visible = false;
                        }
                    }
                }
            }
            cantFiltros = this.filtrosAplicados[0] ? ++cantFiltros : cantFiltros;
            cantFiltros = this.filtrosAplicados[1] ? ++cantFiltros : cantFiltros;
            cantFiltros = this.filtrosAplicados[2] ? ++cantFiltros : cantFiltros;

            this.lblFiltrosAplicados.InnerText = cantFiltros == 0 ? "(Sin" : "(" + cantFiltros;
            this.lblFiltrosAplicados.InnerText += " filtros aplicados)";

            float promedio = 0;
            int cant = 0;
            for (int u = 0; u < this.gridViewCursos.Rows.Count; u++)
            {
                if (this.gridViewCursos.Rows[u].Visible == true && this.gridViewCursos.Rows[u].Cells[5].Text != "-")
                {
                    promedio += int.Parse(this.gridViewCursos.Rows[u].Cells[5].Text);
                    cant++;
                }
            }

            if (cantFiltros == 0)
            {
                this.SpanTitulo.InnerText = cant == 0 ? "Sin notas" : "Promedio total: " + promedio.ToString();
                this.lblFiltrosAplicados.InnerText = "(Sin filtros aplicados)";
            }
            else
            {
                this.SpanTitulo.InnerText = cant == 0 ? "Sin notas" : "Promedio del filtro: " + promedio.ToString();
                if (cantFiltros != 1)
                {
                    this.lblFiltrosAplicados.InnerText = "(" + cantFiltros + " filtros aplicados)";
                }
                else
                {
                    this.lblFiltrosAplicados.InnerText = "(" + cantFiltros + " filtro aplicado)";

                }
            }
        }

        /* -- Métodos de panel de filtros-- */


        /* Métodos de click de acciones de cursos */
        /* -- Métodos de click de acciones de cursos -- */


        /* Métodos de grilla de alumnos */
        /* -- Métodos de grilla de alumnos -- */


        /* Métodos de click de acciones de alumnos */
        /* -- Métodos de click de acciones de alumnos -- */

    }
}