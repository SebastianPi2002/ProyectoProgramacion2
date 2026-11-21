namespace Dominio
{
    public class Caso : IValidable
    {
        private static int s_ultimoId = 1;

        private int _id;
        private string _nombre;
        private string _descripcion;
        private bool _cerrado;
        private Sospechoso _sospechosoPrincipal;
        private Investigador _investigador;
        private List<Evidencia> _evidencias;

        public int Id
        {
            get { return _id; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public bool Cerrado
        {
            get { return _cerrado; }
            set { _cerrado = value; }
        }

        public Sospechoso SospechosoPrincipal
        {
            get { return _sospechosoPrincipal; }
            set { _sospechosoPrincipal = value; }
        }

        public Investigador Investigador
        {
            get { return _investigador; }
            set { _investigador = value; }
        }

        public List<Evidencia> Evidencias
        {
            get { return _evidencias; }
        }

        public Caso(
            string nombre,
            string descripcion,
            bool cerrado,
            Sospechoso sospechosoPrincipal,
            Investigador investigador)
        {
            _id = s_ultimoId++;

            _nombre = nombre;
            _descripcion = descripcion;
            _cerrado = cerrado;
            _sospechosoPrincipal = sospechosoPrincipal;
            _investigador = investigador;

            _evidencias = new List<Evidencia>();
        }

        // Verifica que el caso tenga datos válidos,
        // un sospechoso principal y un investigador
        // cuyo rol sea DETECTIVE.

        public void Validar() {
            
            if (string.IsNullOrEmpty(_nombre))
            {
                throw new Exception("El nombre no puede estar vacio");
            }

            if (string.IsNullOrEmpty(_descripcion))
            {
                throw new Exception("La descripcion no puede estar vacia");
            }

            if (_sospechosoPrincipal == null)
            {
                throw new Exception("Sospechoso no puede ser nulo");
            }

            if (_investigador == null)
            {
                throw new Exception("El investigador no puede ser nulo");
            }

            if (_investigador.Rol != Rol.DETECTIVE)
            {
                throw new Exception("El investigador del caso debe ser detective");
            }

        }

        // Registra una evidencia luego de comprobar que no sea nula
        // y validar sus datos.

        public void AltaEvidencia(Evidencia evidencia)
        {
            if (evidencia == null)
            {
                throw new Exception("La evidencia no puede ser nula");
            }

            evidencia.Validar();

            _evidencias.Add(evidencia);
        }


        // Calcula el peso total de las evidencias asociadas al caso.

        public int CalcularPesoTotal()
        {
            int pesoTotal = 0;

            foreach (Evidencia evidencia in _evidencias)
            {
                pesoTotal += evidencia.CalcularPeso();
            }

            if (_sospechosoPrincipal.Antecedentes)
            {
                pesoTotal += 10;
            }

            if (pesoTotal > 100)
            {
                pesoTotal = 100;
            }

            return pesoTotal;
        }


        // Genera la recomendación de acusación según las condiciones del caso.
        public string GenerarRecomendacion()
        {
            int peso = CalcularPesoTotal();

            if (peso < 30)
            {
                return $"DESESTIMADO: El caso {_nombre} carece de fundamentos. " +
                       $"El peso de la prueba es {peso} y debería ser desestimado.";
            }

            if (peso <= 70)
            {
                return $"CONTINUAR INVESTIGANDO: El caso {_nombre} " +
                       $"necesita más investigación. El peso de la prueba es {peso}.";
            }

            return $"IMPUTACIÓN INMINENTE: El caso {_nombre} " +
                   $"tiene un peso de prueba de {peso} y se recomienda imputar " +
                   $"a {_sospechosoPrincipal.Nombre}.";
        }


      

     

        public override string ToString()
        {
            return $"Id: {_id} - Nombre: {_nombre}";
        }
    }
}