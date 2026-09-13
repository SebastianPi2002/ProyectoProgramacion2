using System;

namespace Dominio
{
    public class Evidencia
    {
        
        private static int s_ultimoId = 1;

        
        private int _id;
        private DateTime _fecha;
        private string _descripcion;


       
        public int Id
        {
            get { return _id; }
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


   
        public Evidencia(DateTime fecha, string descripcion)
        {
            _id = s_ultimoId++;

            _fecha = fecha;
            _descripcion = descripcion;

            Validar();
        }


        public void Validar()
        {
            if (_fecha > DateTime.Today)
            {
                throw new Exception(
                    "La fecha de recolección de la evidencia no puede ser posterior a la fecha actual."
                );
            }

            if (string.IsNullOrEmpty(_descripcion))
            {
                throw new Exception(
                    "La descripción de la evidencia no puede estar vacía."
                );
            }
        }


        public override string ToString()
        {
            return $"Id: {_id} - Descripción: {_descripcion}";
        }
    }
}