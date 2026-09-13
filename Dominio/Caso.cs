namespace Dominio
{
    public class Caso
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
    }
}