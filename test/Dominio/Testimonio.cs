using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Testimonio : Evidencia
    {
        private string _nombreTestigo;
        private Credibilidad _credibilidad;

        public string NombreTestigo
        {

            get { return _nombreTestigo; }
            set { _nombreTestigo = value; }
        }
    

     public Testimonio(
        DateTime fecha,
        string descripcion,
        string nombreTestigo,
        Credibilidad credibilidad
    ) : base(fecha, descripcion)
        {
            _nombreTestigo = nombreTestigo;
            _credibilidad = credibilidad;
        }

    }
}
