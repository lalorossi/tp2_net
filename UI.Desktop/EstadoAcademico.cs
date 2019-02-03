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
    public partial class EstadoAcademico : Form
    {
        private int idAlumnoActual;
        private bool mostrarFiltros;
        private bool[] filtrosAplicados = { false, false, false };

        public EstadoAcademico()
        {
            InitializeComponent();
        }
        public EstadoAcademico(int idAlumno) : this()
        {
            // Carga todos los cursos, pero le saca los controles de admin y permite inscribirse al curso

            this.idAlumnoActual = idAlumno;
            this.mostrarFiltros = false;
        }

        private void EstadoAcademico_Load(object sender, EventArgs e)
        {
            this.lblTitulo.Text = "Promedio total: ";
            //Cambia a "promedio del filtro" cuando se selecciona uno
            this.Listar();
        }

        public void Listar()
        {            
            CursoLogic cList = new CursoLogic();

            this.dgvCursos.Rows.Clear();

            int anioCalendario = 0;
            Comision comision;
            Materia materia;
            Personas profesor;
            string estado = "Inscripto";
            int nota = 0;
            string fechaModificacion = "";
            int cantidad = 0;
            float promedio = 0;


            var dataSourceComisiones = new List<Comision>();
            var dataSourceAño = new List<string>();
            var dataSourceEstado = new List<string>();
            dataSourceComisiones.Add(new Comision { Descripcion = "Filtrar por comisión", ID = 0 });
            dataSourceAño.Add("Filtrar por año");

            AlumnosInscripcionLogic aiLogic = new AlumnosInscripcionLogic();
            foreach (AlumnoInscripcion ai in aiLogic.FindCursos(this.idAlumnoActual))
            {
                CursoLogic curLogic = new CursoLogic();
                ComisionLogic comLogic = new ComisionLogic();
                MateriaLogic matLogic = new MateriaLogic();
                PersonasLogic perLogic = new PersonasLogic();
                DocenteCursoLogic dcLogic = new DocenteCursoLogic();

                Curso curso = curLogic.GetOne(ai.IDCurso);

                anioCalendario = curso.AnioCalendario;
                comision = comLogic.GetOne(curso.IDComision);
                materia = matLogic.GetOne(curso.IDMateria);
                profesor = perLogic.GetOne(dcLogic.FindDocente(curso.ID).IDDocente);
                nota = ai.Nota;
                fechaModificacion = ai.fechaCambio.ToShortDateString();
                if(fechaModificacion == "1/1/1900")
                {
                    fechaModificacion = "-";
                }
                else
                {
                    cantidad += 1;
                    promedio += nota;
                }

                if (aiLogic.FindSingle(this.idAlumnoActual, curso.ID).ID > 0)
                {
                    estado = aiLogic.FindSingle(this.idAlumnoActual, curso.ID).Condicion;
                }
                else
                {
                    estado = "No inscripto";
                }
                this.dgvCursos.Rows.Add(ai.IDCurso, comision.ID, anioCalendario, comision.Descripcion, materia.Descripcion, profesor.Descripcion, estado, nota, fechaModificacion);
                dataSourceComisiones.Add(comision);
                dataSourceAño.Add(anioCalendario.ToString());
            }
            dataSourceEstado.Add("Filtrar por estado");
            dataSourceEstado.Add("Inscripto");
            dataSourceEstado.Add("No regular");
            dataSourceEstado.Add("Regular");
            dataSourceEstado.Add("Aprobado");

            this.cbFiltroComision.DataSource = dataSourceComisiones;
            this.cbFiltroComision.DisplayMember = "Descripcion";
            this.cbFiltroComision.ValueMember = "ID";

            this.cbFiltroAño.DataSource = dataSourceAño;
            this.cbFiltroEstado.DataSource = dataSourceEstado;


            if (cantidad != 0)
            {
                promedio = promedio / cantidad;
                this.lblTitulo.Text += promedio.ToString();
            }
            else
            {
                this.lblTitulo.Text = "Sin notas";
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblFlechaFiltro_Click_Click(object sender, EventArgs e)
        {
            //Activa o desactiva los filtros
            // La viarable filtros pordria cambiar a un array con [0] siendo sin filtros
            if (!mostrarFiltros)
            {
                //Muestra los filtros
                this.lblFlechaFiltro.Text = "p";
                this.switchFiltros();
            }
            else
            {
                //Muestra los filtros
                this.lblFlechaFiltro.Text = "q";
                this.switchFiltros();
            }
            this.mostrarFiltros = !this.mostrarFiltros;

        }

        private void switchFiltros()
        {
            if (this.mostrarFiltros)
            {
                this.tableLayoutPanel1.RowStyles[2].SizeType = SizeType.Absolute;
                this.tableLayoutPanel1.RowStyles[3].SizeType = SizeType.Absolute;
                this.tableLayoutPanel1.RowStyles[4].SizeType = SizeType.Absolute;
                this.tableLayoutPanel1.RowStyles[2].Height = 0;
                this.tableLayoutPanel1.RowStyles[3].Height = 0;
                this.tableLayoutPanel1.RowStyles[4].Height = 0;
            }
            else
            {
                this.tableLayoutPanel1.RowStyles[2].SizeType = SizeType.AutoSize;
                this.tableLayoutPanel1.RowStyles[3].SizeType = SizeType.AutoSize;
                this.tableLayoutPanel1.RowStyles[4].SizeType = SizeType.AutoSize;
            }
        }

        private void aplicarFiltros()
        {
            int cantFiltros = 0;
            for (int u = 0; u < this.dgvCursos.RowCount; u++)
            {
                this.dgvCursos.Rows[u].Visible = true;
            }
            // Saca los filtros (muestra todos  cursos)
            if (this.filtrosAplicados[0] || this.filtrosAplicados[1] || this.filtrosAplicados[2])
            {
                // Aplica el filtro
                for (int u = 0; u < this.dgvCursos.RowCount; u++)
                {
                    //MessageBox.Show(this.dgvCursos.Rows[u].Cells[6].Value.ToString() + "," + this.dgvCursos.Rows[u].Cells[2].Value.ToString() + "," + this.dgvCursos.Rows[u].Cells[1].Value.ToString());
                    if (this.filtrosAplicados[0])
                    {
                        if (this.dgvCursos.Rows[u].Cells[6].Value.ToString() != this.cbFiltroEstado.SelectedValue.ToString())
                        {
                            this.dgvCursos.Rows[u].Visible = false;
                        }
                    }
                    if (this.filtrosAplicados[1])
                    {
                        if (this.dgvCursos.Rows[u].Cells[2].Value.ToString() != this.cbFiltroAño.SelectedValue.ToString())
                        {
                            this.dgvCursos.Rows[u].Visible = false;
                        }
                    }
                    if (this.filtrosAplicados[2])
                    {
                        if (this.dgvCursos.Rows[u].Cells[1].Value.ToString() != this.cbFiltroComision.SelectedValue.ToString())
                        {
                            this.dgvCursos.Rows[u].Visible = false;
                        }
                    }
                }
            }
            cantFiltros = this.filtrosAplicados[0] ? ++cantFiltros : cantFiltros;
            cantFiltros = this.filtrosAplicados[1] ? ++cantFiltros : cantFiltros;
            cantFiltros = this.filtrosAplicados[2] ? ++cantFiltros : cantFiltros;

            this.lblFiltrosAplicados.Text = cantFiltros == 0 ? "(Sin": "("+ cantFiltros;
            this.lblFiltrosAplicados.Text += " filtros aplicados)";

            float promedio = 0;
            int cant = 0;
            for (int u = 0; u < this.dgvCursos.RowCount; u++)
            {
                if (this.dgvCursos.Rows[u].Visible == true && this.dgvCursos.Rows[u].Cells[7].Value.ToString() != "0")
                {
                    promedio += (int)this.dgvCursos.Rows[u].Cells[7].Value;
                    cant++;
                }
            }

            if (cantFiltros == 0)
            {
                this.lblTitulo.Text = cant == 0 ? "Sin notas" : "Promedio total: " + promedio.ToString();
                this.lblFiltrosAplicados.Text = "(Sin filtros aplicados)";
            }
            else
            {
                this.lblTitulo.Text = cant == 0 ? "Sin notas" : "Promedio del filtro: " + promedio.ToString();
                if (cantFiltros != 1)
                {
                    this.lblFiltrosAplicados.Text = "(" + cantFiltros + " filtros aplicados)";
                }
                else
                {
                    this.lblFiltrosAplicados.Text = "(" + cantFiltros + " filtro aplicado)";
                }
            }
            

        }

        private void chkFiltroEstado_CheckedChanged(object sender, EventArgs e)
        {
            this.filtrosAplicados[0] = !this.filtrosAplicados[0];
            this.aplicarFiltros();
        }

        private void chkFiltroAño_CheckedChanged(object sender, EventArgs e)
        {
            this.filtrosAplicados[1] = !this.filtrosAplicados[1];
            this.aplicarFiltros();
        }

        private void chkFiltroComison_CheckedChanged(object sender, EventArgs e)
        {
            this.filtrosAplicados[2] = !this.filtrosAplicados[2];
            this.aplicarFiltros();
        }

        private void cbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.cbFiltroEstado.SelectedIndex == 0)
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

        private void cbFiltroAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbFiltroAño.SelectedIndex == 0)
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

        private void cbFiltroComision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbFiltroComision.SelectedIndex == 0)
            {
                this.chkFiltroComison.Checked = false;
                this.chkFiltroComison.Enabled = false;
                this.filtrosAplicados[2] = false;
            }
            else
            {
                this.chkFiltroComison.Enabled = true;
                if (this.filtrosAplicados[2])
                {
                    this.aplicarFiltros();
                }
            }
        }
    }
}
