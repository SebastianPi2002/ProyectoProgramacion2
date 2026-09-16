using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Fisica : Evidencia
    {
        private bool _huellas;

        public bool Huellas
        {

            get { return _huellas; }
            set { _huellas = value; }
        }
        public Fisica(
            DateTime fecha,
            string descripcion,
            bool huellas
        ) : base(fecha, descripcion)
        {
            _huellas = huellas;
        }

     }
    }
