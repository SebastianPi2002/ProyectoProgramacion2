using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Grabacion
    {
        private int _calidad;
        private bool _infraganti;

        public int Calidad
        {

            get { return _calidad; }
            set { _calidad = value; }
        }

        public bool Infraganti
        {

            get { return _infraganti; }
            set { _infraganti= value; }
        }



    }


}
