using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Negocio;

namespace UI.Desktop
{
    public partial class Cursos : Form
    {
        private int idAlumnoActual = -1;
        public Cursos()
        {
            InitializeComponent();
        }
        public Cursos(int idAlumno) : this()
        {
            // Carga todos los cursos, pero le saca los controles de admin y permite inscribirse al curso
            this.tcCursos.TopToolStripPanel.Hide();
            this.tcCursos.TopToolStripPanel.Enabled = false;
            this.btnVerCurso.Show();
            this.btnVerCurso.Enabled = true;

            this.idAlumnoActual = idAlumno;
        }
        public void Listar()
        {
            CursoLogic cList = new CursoLogic();
            //this.dgvCursos.DataSource = cList.GetAll();

            this.dgvCursos.Rows.Clear();

            int anioCalendario = 0;
            int cupo = 0;
            string descripcion = "";
            string comision = "-";
            string materia = "";
            string estadoAlumno = "No inscripto";
            CursoLogic cursoLogic = new CursoLogic();
            foreach (Curso curso in cursoLogic.GetAll())
            {
                ComisionLogic cl = new ComisionLogic();
                MateriaLogic ml = new MateriaLogic();
                anioCalendario = curso.AnioCalendario;
                cupo = curso.Cupo;
                descripcion = curso.Descripcion;
                comision = cl.GetOne(curso.IDComision).Descripcion;
                materia = ml.GetOne(curso.IDMateria).Descripcion;
                AlumnosInscripcionLogic aiLogic = new AlumnosInscripcionLogic();
                if (aiLogic.FindSingle(this.idAlumnoActual, curso.ID).ID > 0)
                {
                    estadoAlumno = aiLogic.FindSingle(this.idAlumnoActual, curso.ID).Condicion;
                }
                else
                {
                    estadoAlumno = "No inscripto";
                }
                if(this.idAlumnoActual != -1)
                {
                    this.dgvCursos.Rows.Add(curso.ID, anioCalendario, cupo, descripcion, comision, materia, estadoAlumno);
                }
                else
                {
                    this.dgvCursos.Rows.Add(curso.ID, anioCalendario, cupo, descripcion, comision, materia, "");
                }
            }

        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.Text = "Cursos";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            CursoDesktop formCurso = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            formCurso.Text = "Agregar curso";
            formCurso.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count > 0)
            {
                //int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                int ID = int.Parse(this.dgvCursos.SelectedRows[0].Cells["col0IDCurso"].Value.ToString());
                CursoDesktop formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formCurso.Text = "Editar curso";
                formCurso.ShowDialog();
                this.Listar();

            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count > 0)
            {
                //int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                int ID = int.Parse(this.dgvCursos.SelectedRows[0].Cells["col0IDCurso"].Value.ToString());
                CursoDesktop formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Baja);
                formCurso.Text = "Eliminar curso";
                formCurso.ShowDialog();
                this.Listar();
            }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerCurso_Click(object sender, EventArgs e)
        {
            // Comprueba que haya un alumno seteado
            if (this.idAlumnoActual > 0)
            {
                // Abre la verntana del curso en "modo alumno"
                if (this.dgvCursos.SelectedRows.Count > 0)
                {
                    //int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                    int ID = int.Parse(this.dgvCursos.SelectedRows[0].Cells["col0IDCurso"].Value.ToString());
                    CursoDesktop formCurso = new CursoDesktop(ID, idAlumnoActual);
                    formCurso.ShowDialog();
                    this.Listar();
                }
            }
        }
    }
}
