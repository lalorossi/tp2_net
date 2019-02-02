using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using Data.Database;


namespace Negocio
{
    public class AlumnosInscripcionLogic : BusinessLogic
    {
        public AlumnoInscripcionAdapter AlumnosInscripcionData;
        public AlumnosInscripcionLogic()
        {
            AlumnosInscripcionData = new AlumnoInscripcionAdapter();
        }
        public AlumnoInscripcion GetOne(int idAlumnoInscripcion)
        {
            return AlumnosInscripcionData.GetOne(idAlumnoInscripcion);
        }
        public List<AlumnoInscripcion> GetAll()
        {
            return AlumnosInscripcionData.GetAll();
        }
        public void Save(AlumnoInscripcion alumnoInscripcion)
        {
            AlumnosInscripcionData.Save(alumnoInscripcion);
        }
        public void Delete(int idAlumnoInscripcion)
        {
            AlumnosInscripcionData.Delete(idAlumnoInscripcion);
        }
        public List<AlumnoInscripcion> FindCursos(int IDAlumno)
        {
            return AlumnosInscripcionData.FindCursos(IDAlumno);
        }
        public List<AlumnoInscripcion> FindAlumnos(int IDCurso)
        {
            return AlumnosInscripcionData.FindAlumnos(IDCurso);
        }
        public AlumnoInscripcion FindSingle(int IDAlumno, int IDCurso)
        {
            return AlumnosInscripcionData.FindSingle(IDAlumno, IDCurso);
        }
    }
}