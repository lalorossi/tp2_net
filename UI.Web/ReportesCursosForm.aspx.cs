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
    public partial class ReportesCursosForm : System.Web.UI.Page
    {
        public int currentUserId
        {
            get
            {
                if (this.Session["currentUserID"] != null)
                {
                    return (int)this.Session["currentUserID"];
                }
                else
                {
                    return 0;
                }
            }
            set { this.Session["currentUserID"] = value; }
        }

        public enum tipoForm
        {
            Alumno,
            Docente,
            Admin,
        }
        private tipoForm _tipoFormulario;
        public tipoForm tipoFormulario { get => _tipoFormulario; set => _tipoFormulario = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.tipoFormulario = tipoForm.Admin;
            if (!this.IsPostBack)
            {
                if (!this.ValidarPermisos())
                {
                    //Trata de validar al tipo de usuario en la página o lo devuelve al login
                    Response.Redirect("LogInForm.aspx");
                }
                else
                {
                    this.CargarReporte();
                }

            }
        }

        public bool ValidarPermisos()
        {
            if (this.currentUserId != 0)
            {
                UsuarioLogic usr = new UsuarioLogic();
                int permisoUsuario = usr.getPermisos(currentUserId);

                //Establecer tipo de usuario permitido para el tipo de formulario
                if (this.tipoFormulario == tipoForm.Admin && permisoUsuario == 0)
                {
                    return true;
                }
                if (this.tipoFormulario == tipoForm.Docente && permisoUsuario == 1)
                {
                    return true;
                }
                if (this.tipoFormulario == tipoForm.Alumno && permisoUsuario == 2)
                {
                    return true;
                }
                
                return false;
            }
            else
            {
                return false;
            }
        }


        private void CargarReporte()
        {
            
            reportViewerCursos.LocalReport.DataSources.Clear();
            /*
            // Tabla de cursos general
            List<ReporteCurso> cursos = new List<ReporteCurso>();
            this.reportViewerCursos.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCursosPro", cursos));

            // Curso con más alumnos
            List<ReporteCurso> cursoConMasAlumnos_List = new List<ReporteCurso>();
            this.reportViewerCursos.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCursoConMasAlumnos", cursoConMasAlumnos_List));

            // Curso con menos alumnos
            List<ReporteCurso> cursoConMenosAlumnos_List = new List<ReporteCurso>();
            this.reportViewerCursos.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCursoConMenosAlumnos", cursoConMenosAlumnos_List));

            // Curso con mayor % de aprobados
            List<ReporteCurso> cursoMasEficiente_List = new List<ReporteCurso>();
            this.reportViewerCursos.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCursoMasEficiente", cursoMasEficiente_List));

            // Curso con menor % de aprobados
            List<ReporteCurso> cursoMenosEficiente_List = new List<ReporteCurso>();
            this.reportViewerCursos.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCursoMenosEficiente", cursoMenosEficiente_List));

            // Curso con mejor promedio (entre alumnos con nota)
            List<ReporteCurso> cursoMejorPromedio_List = new List<ReporteCurso>();
            this.reportViewerCursos.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCursoMayorPromedio", cursoMejorPromedio_List));

            // Curso con peor promedio (entre alumnos con nota)
            List<ReporteCurso> cursoPeorPromedio_List = new List<ReporteCurso>();
            this.reportViewerCursos.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCursoMenorPromedio", cursoPeorPromedio_List));


            // Cantidad de cursos, cursos sin alumnos, cursos finalizados (Todas las notas puestas)
            List<ReporteCurso> datosCursos_List = new List<ReporteCurso>();
            this.reportViewerCursos.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetDatosCurso", datosCursos_List));


            reportViewerCursos.LocalReport.Refresh();
            reportViewerCursos.DataBind();
            */

            // Tabla básica de datos de cursos
            List<ReporteCurso> cursos = new List<ReporteCurso>();
            ReporteCurso cursoConMasAlumnos = new ReporteCurso();
            ReporteCurso cursoConMenosAlumnos = new ReporteCurso();
            ReporteCurso cursoMasEficiente = new ReporteCurso();
            ReporteCurso cursoMenosEficiente = new ReporteCurso();
            ReporteCurso cursoMayorPromedio = new ReporteCurso();
            ReporteCurso cursoMenorPromedio = new ReporteCurso();
            cursoMenorPromedio.Promedio = 11;
            cursoMenosEficiente.PorcAprobados = 101;
            decimal sumaNotas = 0;
            decimal cantAprobados = 0;
            int alumnosConNota = 0;
            int cantCursos = 0;
            int cursosVacios = 0;
            int cursosCerrados = 0;

            foreach (Curso curso in new CursoLogic().GetAll())
            {
                ReporteCurso obj = new ReporteCurso();
                // año | cupo | comision | materia | profesor  | alumnos
                obj.Año = curso.AnioCalendario;
                obj.Cupo = curso.Cupo;
                obj.Comision = new ComisionLogic().GetOne(curso.IDComision).Descripcion;
                obj.Materia = new MateriaLogic().GetOne(curso.IDMateria).Descripcion;
                obj.Profesor = new PersonasLogic().GetOne(new DocenteCursoLogic().FindDocente(curso.ID).IDDocente).Descripcion;
                obj.Alumnos = ((new AlumnosInscripcionLogic().FindAlumnos(curso.ID)).Count);
                cursos.Add(obj);
                if (obj.Alumnos >= cursoConMasAlumnos.Alumnos)
                {
                    cursoConMasAlumnos = obj;
                }
                if (obj.Alumnos <= cursoConMenosAlumnos.Alumnos)
                {
                    cursoConMenosAlumnos = obj;
                }
                sumaNotas = 0;
                cantAprobados = 0;
                alumnosConNota = 0;
                int flagCerrado = 0;
                int flagVacio = 0;
                foreach (AlumnoInscripcion ai in new AlumnosInscripcionLogic().FindAlumnos(curso.ID))
                {
                    flagVacio = 1;
                    sumaNotas += ai.Nota;
                    if (ai.Nota >= 8)
                    {
                        cantAprobados += 1;
                    }
                    if (ai.Nota > 0)
                    {
                        alumnosConNota++;
                    }
                    else
                    {
                        flagCerrado = 1;
                    }
                }
                //MessageBox.Show(alumnosConNota.ToString() + "-" + sumaNotas.ToString() + "-" + cantAprobados.ToString());
                if (obj.Alumnos > 0)
                {
                    if (sumaNotas / alumnosConNota >= cursoMayorPromedio.Promedio)
                    {
                        cursoMayorPromedio = obj;
                        cursoMayorPromedio.Promedio = (sumaNotas / obj.Alumnos);
                    }
                    if (sumaNotas / alumnosConNota <= cursoMenorPromedio.Promedio)
                    {
                        cursoMenorPromedio = obj;
                        cursoMayorPromedio.Promedio = sumaNotas / obj.Alumnos;
                    }
                    if (cantAprobados / obj.Alumnos >= cursoMasEficiente.PorcAprobados)
                    {
                        cursoMasEficiente = obj;
                        cursoMayorPromedio.PorcAprobados = cantAprobados / obj.Alumnos;
                    }
                    if (cantAprobados / obj.Alumnos <= cursoMenosEficiente.PorcAprobados)
                    {
                        cursoMenosEficiente = obj;
                        cursoMayorPromedio.PorcAprobados = cantAprobados / obj.Alumnos;
                    }
                }
                cantCursos++;
                if (flagVacio == 0)
                {
                    cursosVacios++;
                }
                else
                {
                    if (flagCerrado == 0)
                    {
                        cursosCerrados++;
                    }
                }
            }
            this.reportViewerCursos.LocalReport.DataSources.Clear();

            // Tabla de cursos general
            this.reportViewerCursos.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCursosPro", cursos));

            // Curso con más alumnos
            List<ReporteCurso> cursoConMasAlumnos_List = new List<ReporteCurso>();
            cursoConMasAlumnos_List.Add(cursoConMasAlumnos);
            this.reportViewerCursos.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCursoConMasAlumnos", cursoConMasAlumnos_List));

            // Curso con menos alumnos
            List<ReporteCurso> cursoConMenosAlumnos_List = new List<ReporteCurso>();
            cursoConMenosAlumnos_List.Add(cursoConMenosAlumnos);
            this.reportViewerCursos.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCursoConMenosAlumnos", cursoConMenosAlumnos_List));

            // Curso con mayor % de aprobados
            List<ReporteCurso> cursoMasEficiente_List = new List<ReporteCurso>();
            cursoMasEficiente.PorcAprobados *= 100;
            cursoMasEficiente_List.Add(cursoMasEficiente);
            this.reportViewerCursos.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCursoMasEficiente", cursoMasEficiente_List));

            // Curso con menor % de aprobados
            List<ReporteCurso> cursoMenosEficiente_List = new List<ReporteCurso>();
            cursoMenosEficiente.PorcAprobados *= 100;
            cursoMenosEficiente_List.Add(cursoMenosEficiente);
            this.reportViewerCursos.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCursoMenosEficiente", cursoMenosEficiente_List));

            // Curso con mejor promedio (entre alumnos con nota)
            List<ReporteCurso> cursoMejorPromedio_List = new List<ReporteCurso>();
            cursoMejorPromedio_List.Add(cursoMayorPromedio);
            this.reportViewerCursos.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCursoMayorPromedio", cursoMejorPromedio_List));

            // Curso con peor promedio (entre alumnos con nota)
            List<ReporteCurso> cursoPeorPromedio_List = new List<ReporteCurso>();
            cursoPeorPromedio_List.Add(cursoMenorPromedio);
            this.reportViewerCursos.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCursoMenorPromedio", cursoPeorPromedio_List));


            // Cantidad de cursos, cursos sin alumnos, cursos finalizados (Todas las notas puestas)
            List<ReporteCurso> datosCursos_List = new List<ReporteCurso>();
            datosCursos_List.Add(new ReporteCurso() { ID = cantCursos, Alumnos = cursosCerrados, Año = cursosVacios });
            this.reportViewerCursos.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetDatosCurso", datosCursos_List));

            // Gráfico con las condicinoes de alumnos
            // Profesor con más cursos (subinforme)
            // Profesor con menos cursos (al menos un curso por profesor)

            this.reportViewerCursos.LocalReport.Refresh();
            //this.reportViewerCursos.DataBind();
        }
    }
}