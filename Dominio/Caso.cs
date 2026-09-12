namespace Dominio
{
    public class Caso
    {
        private int _id;
        private string _nombre;
        private string _descripcion;
        private string _estado;
        private Sospechoso _sospechosoPrincipal;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
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

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public Sospechoso SospechosoPrincipal
        {
            get { return _sospechosoPrincipal; }
            set { _sospechosoPrincipal = value; }
        }

        public Caso(int id, string nombre, string descripcion,
                    string estado, Sospechoso sospechosoPrincipal)
        {
            _id = id;
            _nombre = nombre;
            _descripcion = descripcion;
            _estado = estado;
            _sospechosoPrincipal = sospechosoPrincipal;
        }
    }
}
