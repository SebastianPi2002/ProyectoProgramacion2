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


        // Ejecuta las validaciones de la clase Evidencia
        // y comprueba que el nombre del testigo no esté vacío.

        public override void Validar()
        {
            base.Validar();

            if (string.IsNullOrEmpty(_nombreTestigo))
            {
                throw new Exception("El nombre del testigo no puede estar vacío.");
            }
        }
    }
}
