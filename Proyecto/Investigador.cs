using System;
using System.Collections.Generic;

namespace Proyecto
{
    public class Investigador
    {
        private string _email;
        private string _contrasenia;

        private string _nombre;

        private List<Evidencia> _evidencia;


        private Rol _rol;

        public string Email {   get { return _email; }    set { _email = value; } }

        private string Contrasenia { get; set; }

        private string Nombre { get; set; }

        public List<Evidencia> Evidencias
        {
            get { return _evidencia; }
            set { _evidencia = value; }
        }


        public Investigador(string email, string contrasenia, string nombre, List<Evidencia> evidencia, Rol rol)
        {
            _email = email;
            _contrasenia = contrasenia;
            _nombre = nombre;
            _evidencia = evidencia;
            _rol = rol;
        }


    }
}
