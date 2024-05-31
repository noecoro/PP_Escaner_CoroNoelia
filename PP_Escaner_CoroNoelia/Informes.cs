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
        /// <summary>
        ///Muestra los documentos que están en estado "Distribuido" en un escáner y recopila información sobre 
        ///la extensión total, la cantidad y un resumen de los documentos.
        /// </summary>
        /// <param name="e">El escáner del que se muestran los documentos.</param>
        /// <param name="extension">La extensión total de los documentos que están en estado "Distribuido"</param>
        /// <param name="cantidad">La cantidad de documentos que están en estado "Distribuido"</param>
        /// <param name="resumen">Un resumen de los documentos que están en estado "Distribuido"</param>
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Distribuido, out extension, out cantidad, out resumen);
        }
        /// <summary>
        /// Muestra los documentos de un escáner según su estado y recopila información sobre la extensión 
        /// total, la cantidad y un resumen de los documentos.
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
                    if (documento is Libro libro && e.Tipo == Escaner.TipoDoc.libro)
                    {
                        extension += libro.NumPaginas;
                    }
                    else if (documento is Mapa mapa && e.Tipo == Escaner.TipoDoc.mapa)
                    {
                        extension += mapa.Superficie;
                    }
                    cantidad++;
                    resumen += documento.ToString();
                }
            }
        }
        /// <summary>
        ///Muestra los documentos que están en estado "EnEscaner" en un escáner y recopila información sobre 
        ///la extensión total, la cantidad y un resumen de los documentos.
        /// </summary>
        /// <param name="e">El escáner del que se muestran los documentos.</param>
        /// <param name="extension">La extensión total de los documentos que están en estado "EnEscaner"</param>
        /// <param name="cantidad">La cantidad de documentos que están en estado "EnEscaner"</param>
        /// <param name="resumen">Un resumen de los documentos que están en estado "EnEscaner"</param>
        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnEscaner, out extension, out cantidad, out resumen);
        }
        /// <summary>
        ///Muestra los documentos que están en estado "EnRevision" en un escáner y recopila información sobre 
        ///la extensión total, la cantidad y un resumen de los documentos.
        /// </summary>
        /// <param name="e">El escáner del que se muestran los documentos.</param>
        /// <param name="extension">La extensión total de los documentos que están en estado "EnRevision"</param>
        /// <param name="cantidad">La cantidad de documentos que están en estado "EnRevision"</param>
        /// <param name="resumen">Un resumen de los documentos que están en estado "EnRevision"</param>
        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnRevision, out extension, out cantidad, out resumen);
        }
        /// <summary>
        ///Muestra los documentos que están en estado "Terminado" en un escáner y recopila información sobre 
        ///la extensión total, la cantidad y un resumen de los documentos.
        /// </summary>
        /// <param name="e">El escáner del que se muestran los documentos</param>
        /// <param name="extension">La extensión total de los documentos que están en estado "Terminado"</param>
        /// <param name="cantidad">La cantidad de documentos que están en estado "Terminado"</param>
        /// <param name="resumen">Un resumen de los documentos que están en estado "Terminado"</param>
        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Terminado, out extension, out cantidad, out resumen);
        }
        
    }
}
