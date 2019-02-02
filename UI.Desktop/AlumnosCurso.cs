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
    public partial class AlumnosCurso : UI.Desktop.ApplicationForm
    {
        /* Propiedades LOGIC */
        private CursoLogic _cursoLogic;
        public CursoLogic CursoLogic
        {
            set { _cursoLogic = value; }
            get
            {
                if (_cursoLogic == null)
                {
                    return new CursoLogic();
                }
                return _cursoLogic;
            }
        }

        private AlumnosInscripcionLogic _alumnoInscripcionLogic;
        public AlumnosInscripcionLogic alumnoInscripcionLogic
        {
            set { _alumnoInscripcionLogic = value; }
            get
            {
                if (_alumnoInscripcionLogic == null)
                {
                    return new AlumnosInscripcionLogic();
                }
                return _alumnoInscripcionLogic;
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
        private Curso _CursoActual;
        public Curso CursoActual
        {
            set { _CursoActual = value; }
            get { return _CursoActual; }
        }
        /* ./Propiedades ENTIDAD */

        private bool _edicion;
        public bool edicion
        {
            get { return _edicion; }
            set { _edicion = value; }
        }
        public AlumnosCurso()
        {
            InitializeComponent();
        }
        public AlumnosCurso(int IDCurso) : this()
        {
            this.dgvAlumnos.AutoGenerateColumns = false;
            this.CursoActual = CursoLogic.GetOne(IDCurso);
            this.Listar();
        }
        public void Listar()
        {
            this.dgvAlumnos.Rows.Clear();
            
            string apellido = "";
            string nombre = "";
            int legajo = 0;
            string notaVisible = "-";
            string condicion = "";
            foreach (AlumnoInscripcion ai in alumnoInscripcionLogic.FindAlumnos(this.CursoActual.ID))
            {
                Personas alumno = PersonasLogic.GetOne(ai.IDAlumno);

                apellido = alumno.Apellido;
                nombre = alumno.Nombre;
                legajo = alumno.Legajo;
                condicion = ai.Condicion;
                if (ai.Nota == 0)
                    notaVisible = "-";
                else
                    notaVisible = ai.Nota.ToString();

                this.dgvAlumnos.Rows.Add(ai.ID, apellido, nombre, legajo, notaVisible, condicion);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.edicion)
            {
                this.dgvAlumnos.Columns["col4Nota"].ReadOnly = false;
                this.edicion = true;
                this.btnSalir.Text = "Descartar Cambios";
                this.btnEditar.Text = "Guardar";
            }
            else
            {
                // Guarda los cambios de las notas
                int idAlumnoInscripcion = 0;
                foreach(DataGridViewRow fila in this.dgvAlumnos.Rows)
                {
                    idAlumnoInscripcion = int.Parse(fila.Cells["col0IDAlumnoInscripcion"].Value.ToString());
                    AlumnoInscripcion ai = alumnoInscripcionLogic.GetOne(idAlumnoInscripcion);
                    string nuevaNota = fila.Cells["col4Nota"].Value.ToString();

                    if (nuevaNota == "-")
                    {
                        nuevaNota = "0";
                        ai.Condicion = "Inscripto";
                    }
                    if (nuevaNota != ai.Nota.ToString())
                    {
                        ai.Nota = int.Parse(nuevaNota);
                        ai.fechaCambio = DateTime.Today;
                        ai.State = BusinessEntity.States.Modified;
                        if (ai.Nota < 6 && ai.Nota != 0)
                            ai.Condicion = "No regular";
                        else if (ai.Nota < 8)
                            ai.Condicion = "Regular";
                        else
                            ai.Condicion = "Aprobado";
                        this.alumnoInscripcionLogic.Save(ai);
                    }

                    /*
                    if (nuevaNota == "-")
                    {
                        nuevaNota = "0";
                    }
                    if (nuevaNota != ai.Nota.ToString())
                    { 
                        ai.Nota = int.Parse(fila.Cells["col4Nota"].Value.ToString());
                        if (ai.Nota < 6)
                            ai.Condicion = "No regular";
                        else if (ai.Nota < 8)
                            ai.Condicion = "Regular";
                        else
                            ai.Condicion = "Aprobado";
                        ai.fechaCambio = DateTime.Today;
                    }
                    else
                    {
                        ai.Nota = 0;
                        ai.Condicion = "Inscripto";
                    }
                    ai.State = BusinessEntity.States.Modified;
                    this.alumnoInscripcionLogic.Save(ai);
                    */
                }
                this.btnEditar.Text = "Editar Notas";
                this.btnSalir.Text = "Salir";
                this.dgvAlumnos.Columns["col4Nota"].ReadOnly = false;
                this.edicion = false;
                this.Listar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // A menos que esté en modo edicion, cierra la ventana
            if (!this.edicion)
                this.Close();
            // Si está en modo edición, el botón cancela los cambios
            else
            {
                this.btnSalir.Text = "Salir";
                this.Listar();
                this.edicion = false;
                this.dgvAlumnos.Columns["col4Nota"].ReadOnly = false;
            }
        }
    }
}
