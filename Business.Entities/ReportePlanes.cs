using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class ReportePlanes : BusinessEntity
    {
        private string _Descripcion;
        private string _Especialidad;
        private int _IDEspecialidad;
        private int _materias;
        private int _comisiones;

        public int Materias { get => _materias; set => _materias = value; }
        public int Comisiones { get => _comisiones; set => _comisiones = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Especialidad { get => _Especialidad; set => _Especialidad = value; }
        public int IDEspecialidad { get => _IDEspecialidad; set => _IDEspecialidad = value; }
    }
}
