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




        // Ejecuta las validaciones de la clase Evidencia
        // y comprueba que la calidad de la grabación esté entre 1 y 5.

        public override void Validar()
        {

            base.Validar();
            if (_calidad < 1 || _calidad > 5 )
            {
                throw new Exception("La calidad de la grabación debe estar entre 1 y 5.");
            }

        }
    }



}
