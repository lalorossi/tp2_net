using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class AlumnoInscripcion:BusinessEntity
    {
        private string _Condicion;
        public string Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }
        private int _IDAlumno;
        public int IDAlumno
        {
            get { return _IDAlumno; }
            set { _IDAlumno = value; }
        }
        private int _IDCurso;
        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }
        private int _Nota;
        public int Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }
        private DateTime _fechaCambio;
        public DateTime fechaCambio
        {
            get { return _fechaCambio; }
            set { _fechaCambio = value; }
        }
    }
}
