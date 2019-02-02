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
    public partial class CursosDocente : Form
    {
        /* Propiedades LOGIC */
        private CursoLogic _cursoLogic;
        public CursoLogic CursoLogic
        {
            set { _cursoLogic = value; }
            get
            {
                if(_cursoLogic == null)
                {
                    return new CursoLogic();
                }
                return _cursoLogic;
            }
        }

        private DocenteCursoLogic _docenteCursoLogic;
        public DocenteCursoLogic DocenteCursoLogic
        {
            set { _docenteCursoLogic = value; }
            get
            {
                if(_docenteCursoLogic == null)
                {
                    return new DocenteCursoLogic();
                }
                return _docenteCursoLogic;
            }
        }

        private PersonasLogic _personasLogic;
        public PersonasLogic PersonasLogic
        {
            set { _personasLogic = value; }
            get
            {
                if (_personasLogic == null)
                {
                    return new PersonasLogic();
                }
                return _personasLogic;
            }
        }
        /* ./Propiedades LOGIC */

        /* Propiedades ENTIDAD */
        private Personas _DocenteActual;
        public Personas DocenteActual
        {
            set { _DocenteActual = value; }
            get { return _DocenteActual; }
        }
        /* ./Propiedades ENTIDAD */

        public CursosDocente()
        {
            InitializeComponent();
        }
        public CursosDocente(int IDDocente) : this()
        {
            this.DocenteActual = PersonasLogic.GetOne(IDDocente);
            this.Listar();
        }

        public void Listar()
        {
            this.dgvCursosDocente.Rows.Clear();

            Materia materia;
            Comision comision;
            int alumnos = 0;
            Curso curso;
            foreach(DocenteCurso dc in DocenteCursoLogic.FindCursos(this.DocenteActual.ID))
            {
                MateriaLogic materiaLogic = new MateriaLogic();
                ComisionLogic comisionLogic = new ComisionLogic();
                AlumnosInscripcionLogic alumnosInscripcionLogic = new AlumnosInscripcionLogic();
                CursoLogic cursoLogic = new CursoLogic();

                materia = materiaLogic.GetOne(this.CursoLogic.GetOne(dc.IDCurso).IDMateria);
                comision = comisionLogic.GetOne(this.CursoLogic.GetOne(dc.IDCurso).IDComision);
                alumnos = alumnosInscripcionLogic.FindAlumnos(dc.IDCurso).Count;
                curso = cursoLogic.GetOne(dc.IDCurso);
                //                            |  idCurso  |         AÑO        |       MATERIA       |      COMISION      |  ALUMNOS |
                this.dgvCursosDocente.Rows.Add(dc.IDCurso, curso.AnioCalendario, materia.Descripcion, comision.Descripcion, alumnos);
            }
        }

        private void btnVerCurso_Click(object sender, EventArgs e)
        {
            if (this.dgvCursosDocente.SelectedRows.Count > 0)
            {
                int ID = (int)this.dgvCursosDocente.SelectedRows[0].Cells["col0IdCurso"].Value;
                AlumnosCurso formAlumnos = new AlumnosCurso(ID);
                formAlumnos.Text = "Alumnos del curso";
                formAlumnos.ShowDialog();
                this.Listar();

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CursosDocente_Load(object sender, EventArgs e)
        {
            this.Text = "Mis cursos";
        }
    }
}
