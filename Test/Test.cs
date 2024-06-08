using Entidades;
using System.Net.Http.Headers;
using System.Drawing;
using static Entidades.Documento;
using static Entidades.Escaner;
using System.Runtime.InteropServices;
using System.Xml.Linq;
namespace Test
{
    internal class Test
    {
        static void Main(string[] args)
        {
            try
            {
                Escaner escanerLibros = new Escaner("MarcaX", Escaner.TipoDoc.libro);
               // Libro libro = new Libro("Yerma", "García Lorca, Federico", 1995, "11111", "22222", 100);
                Mapa mapa = new Mapa("Buenos Aires", "Instituto Geográfico de Buenos Aires", 2005, "", "99999", 30, 15);

                // Intentar agregar un mapa al escáner de libros
                if (!(escanerLibros + mapa))
                {
                    Console.WriteLine("No se pudo agregar el mapa al escáner de libros.");
                }
            }
            catch (TipoIncorrectoException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            try
            {
                Escaner escanerMapas = new Escaner("MarcaY", Escaner.TipoDoc.mapa);
                Libro libro = new Libro("ISBN repetido", "García Lorca, Federico", 2003, "11112", "22224", 2);

                // Intentar agregar un libro al escáner de mapas +
                if (!(escanerMapas + libro))
                {
                    Console.WriteLine("No se pudo agregar el libro al escáner de mapas.");
                }
            }
            catch (TipoIncorrectoException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadKey();
        }
    }
}
