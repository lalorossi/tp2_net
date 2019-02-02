using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        private int _Cargo;
        public int Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }
        private int _IDCurso;
        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }
        private int _IDDocente;
        public int IDDocente
        {
            get { return _IDDocente; }
            set { _IDDocente = value; }
        }
    }
}
