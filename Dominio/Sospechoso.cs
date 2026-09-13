using System;

namespace Dominio
{
    public class Sospechoso
    {
        
        private string _nombre;
        private string _cedula;
        private bool _antecedentes;
        private DateTime _fechaNacimiento;


       
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Cedula
        {
            get { return _cedula; }
            set { _cedula = value; }
        }

        public bool Antecedentes
        {
            get { return _antecedentes; }
            set { _antecedentes = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }


       
        public Sospechoso(
            string nombre,
            string cedula,
            bool antecedentes,
            DateTime fechaNacimiento)
        {
            _nombre = nombre;
            _cedula = cedula;
            _antecedentes = antecedentes;
            _fechaNacimiento = fechaNacimiento;

            Validar();
        }


        // Validaciones
        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre))
            {
                throw new Exception(
                    "El nombre del sospechoso no puede estar vacío."
                );
            }

            if (string.IsNullOrEmpty(_cedula))
            {
                throw new Exception(
                    "La cédula del sospechoso no puede estar vacía."
                );
            }

            if (_fechaNacimiento > DateTime.Today)
            {
                throw new Exception(
                    "La fecha de nacimiento no puede ser posterior a la fecha actual."
                );
            }
        }


       
        public override string ToString()
        {
            return $"Nombre: {_nombre} - Cédula: {_cedula} - " +
                   $"Fecha de nacimiento: {_fechaNacimiento.ToShortDateString()} - " +
                   $"Antecedentes: {_antecedentes}";
        }
    }
}