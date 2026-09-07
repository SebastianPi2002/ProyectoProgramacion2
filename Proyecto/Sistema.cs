using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto
{
    public class Sistema
    {
        private List<Investigador> _investigadores;
        private List<Caso> _casos;
        private List<Sospechoso> _sospechosos;

        public Sistema()
        {
            _investigadores = new List<Investigador>();
            _casos = new List<Caso>();
            _sospechosos = new List<Sospechoso>();
        }
    }
}
