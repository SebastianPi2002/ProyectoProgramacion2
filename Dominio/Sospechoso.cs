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

        public Sospechoso(string nombre, string cedula, bool antecedentes,
                          DateTime fechaNacimiento)
        {
            _nombre = nombre;
            _cedula = cedula;
            _antecedentes = antecedentes;
            _fechaNacimiento = fechaNacimiento;
        }
    }
}