
using System;

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


        // Calcula el peso correspondiente a una evidencia física.
        public override int CalcularPeso()
        {
            int peso = base.CalcularPeso();

            if (_huellas)
            {
                peso += 40;
            }

            return peso;
        }
    }
}
