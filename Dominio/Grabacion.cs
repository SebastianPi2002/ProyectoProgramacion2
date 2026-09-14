using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Grabacion : Evidencia
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

        public Grabacion(
        DateTime fecha,
        string descripcion,
        int calidad,
        bool infraganti
    ) : base (fecha, descripcion)
        {
            _calidad = calidad;
            _infraganti = infraganti;
        }

    }


}
