using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;
using static Entidades.Escaner;

namespace Entidades
{
    public static class Informes
    { 
       public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Distribuido, out extension, out cantidad, out resumen);
        }
        /// <summary>
        /// Muestra los documentos de un escáner que tienen un estado específico y calcula la extensión total y la cantidad de documentos mostrados.
        /// </summary>
        /// <param name="e">El escáner del que se mostrarán los documentos</param>
        /// <param name="estado">El estado de los documentos que se desean mostrar</param>
        /// <param name="extension">La extensión total de los documentos mostrados.</param>
        /// <param name="cantidad">La cantidad de documentos mostrados</param>
        /// <param name="resumen">Un resumen de los documentos mostrados en formato de texto</param>
        private static void MostrarDocumentosPorEstado(Escaner e, Documento.Paso estado, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            resumen = "";

            foreach (Documento documento in e.ListaDocumentos)
            {
                if (documento.Estado == estado)
                {
                    cantidad++;
                    if (documento is Libro libro)
                    {
                        extension += libro.NumPaginas;
                        resumen += $"Libro: Título: {libro.Titulo}, Autor: {libro.Autor}, Páginas: {libro.NumPaginas}\n";
                    }
                    else if (documento is Mapa mapa)
                    {
                        extension += mapa.Superficie;
                        resumen += $"Mapa: Título: {mapa.Titulo}, Autor: {mapa.Autor}, Superficie: {mapa.Superficie} cm²\n";
                    }
                }
            }
        }
        /// <summary>
        /// Muestra los documentos que están actualmente en el escáner y calcula la extensión total y la cantidad de documentos mostrados.Llama al método MostrarDocumentosPorEstado con el estado Documento.Paso.EnEscaner para mostrar los documentos que están actualmente en el escáner.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="extension"></param>
        /// <param name="cantidad"></param>
        /// <param name="resumen"></param>
        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnEscaner, out extension, out cantidad, out resumen);
        }
        /// <summary>
        /// Muestra los documentos que están actualmente en el escáner y calcula la extensión total y la cantidad de documentos mostrados.Llama al método MostrarDocumentosPorEstado con el estado Documento.Paso.EnRevision para mostrar los documentos que están actualmente en el escáner.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="extension"></param>
        /// <param name="cantidad"></param>
        /// <param name="resumen"></param>
        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnRevision, out extension, out cantidad, out resumen);
        }
        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Terminado, out extension, out cantidad, out resumen);
        }
        
    }
}
