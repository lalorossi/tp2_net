using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        private int _HsSemanales;
        public int HsSemanales
        {
            get { return _HsSemanales; }
            set { _HsSemanales = value; }
        }
        private int _HsTotales;
        public int HsTotales
        {
            get { return _HsTotales; }
            set { _HsTotales = value; }
        }
        private int _IDPlan;
        public int IDPlan
        {
            get { return _IDPlan; }
            set { _IDPlan = value; }
        }
    }
}
