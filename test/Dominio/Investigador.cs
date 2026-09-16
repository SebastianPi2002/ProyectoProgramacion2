using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Investigador
    {
        private string _email;
        private string _contrasenia;
        private string _nombre;
        private Rol _rol;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Contrasenia
        {
            get { return _contrasenia; }
            set { _contrasenia = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public Rol Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }

        public Investigador(
            string email,
            string contrasenia,
            string nombre,
            Rol rol)
        {
            _email = email;
            _contrasenia = contrasenia;
            _nombre = nombre;
            _rol = rol;
        }
    }
}
