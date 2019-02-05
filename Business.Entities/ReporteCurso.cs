using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class ReporteCurso : BusinessEntity
    {
        // año | cupo | comision | materia | profesor  | alumnos
        private int _año;
        private int _cupo;
        private string _comision;
        private string _materia;
        private string _profesor;
        private int _alumnos;
        private decimal _promedio;
        private decimal _porcAprobados;
        
        public int Año { get => _año; set => _año = value; }
        public int Cupo { get => _cupo; set => _cupo = value; }
        public string Comision { get => _comision; set => _comision = value; }
        public string Materia { get => _materia; set => _materia = value; }
        public string Profesor { get => _profesor; set => _profesor = value; }
        public int Alumnos { get => _alumnos; set => _alumnos = value; }
        public decimal Promedio { get => _promedio; set => _promedio = value; }
        public decimal PorcAprobados { get => _porcAprobados; set => _porcAprobados= value; }
    }
}
