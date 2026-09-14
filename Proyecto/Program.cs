using Dominio;
namespace Proyecto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema sistema = new Sistema();

            sistema.PrecargarDatos();
        }
    }
}
