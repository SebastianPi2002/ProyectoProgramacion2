using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Evidencia
    {
        private int _id;
        private DateTime _fecha;
        private string _descripcion;
       

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
    }
}
