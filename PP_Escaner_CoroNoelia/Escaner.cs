using System;
using System.Collections.Generic;
using System.Linq;
#pragma warning disable CS0660
#pragma warning disable CS0661
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;

namespace Entidades
{
    public class Escaner
    { 
        /// <summary>
        /// Enumera los posibles departamentos de una biblioteca.
        /// </summary>
        public enum Departamento
        {
            /// <summary>
            /// No se ha asignado un departamento.
            /// </summary>
            nulo,
            /// <summary>
            /// Departamento de mapoteca.
            /// </summary>
            mapoteca,
            /// <summary>
            /// Departamento de procesos técnicos.
            /// </summary>
            procesosTecnicos
        }
        /// <summary>
        /// Enumera los posibles tipos de documentos.
        /// </summary>
        public enum TipoDoc
        {
            /// <summary>
            /// Tipo de documento: libro.
            /// </summary>
            libro,
            /// <summary>
            /// Tipo de documento: mapa.
            /// </summary>
            mapa
        }
        #region ATRIBUTOS
        private List<Documento> listaDocumentos;
        private Departamento locacion;
        private string marca;
        private TipoDoc tipo;
        #endregion Atributos
        /// <summary>
        /// Inicializa una nueva instancia de la clase "Escaner" con la marca y el tipo de documento especificados.
        /// </summary>
        /// <param name="marca">marca del escáner</param>
        /// <param name="tipo">tipo de documento que el escáner puede procesar</param>
        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>();
            this.locacion = this.Tipo == TipoDoc.mapa ? Departamento.mapoteca : Departamento.procesosTecnicos;
        }
        #region PROPIEDADES
        /// <summary>
        /// Obtiene la lista de documentos procesados por el escáner.
        /// </summary>
        public List<Documento> ListaDocumentos { get => listaDocumentos; }
        /// <summary>
        /// Obtiene la ubicación del escáner dentro de la biblioteca.
        /// </summary>
        public Departamento Locacion { get => locacion; }
        /// <summary>
        /// Obtiene la marca del escáner.
        /// </summary>
        public string Marca { get => marca; }
        /// <summary>
        /// Obtiene el tipo de documento que el escáner puede procesar.
        /// </summary>
        public TipoDoc Tipo { get => tipo; }
        #endregion propiedades
        #region METODOS 
        /// <summary>
        /// Cambia el estado del documento procesado por el escáner.
        /// </summary>
        /// <param name="d">El documento cuyo estado se va a cambiar</param>
        /// <returns>Verdadero si se cambió con éxito el estado del documento; de lo contrario, retorna falso.</returns>
        public bool CambiarEstadoDocumento(Documento d)
        {

            for (int i = 0; i < listaDocumentos.Count; i++)
            {
                if (listaDocumentos[i] == d)
                {
                    listaDocumentos[i].AvanzarEstado();
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Comprueba si un documento no está presente en la lista de documentos del escáner.
        /// </summary>
        /// <param name="e">El escáner a comparar</param>
        /// <param name="d">El documento a comparar</param>
        /// <returns>Verdadero si el documento no está presente en la lista de documentos del escáner; de lo contrario, retorna falso.</returns>
        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }
        /// <summary>
        /// Agrega un documento al escáner y avanza su estado si cumple con ciertas condiciones.
        /// </summary>
        /// </summary>
        /// <param name="e">escáner al que se agrega el documento.</param>
        /// <param name="d">documento que se agrega al escáner</param>
        /// <returns>verdadero si se agregó el documento al escáner y se avanzó su estado; de lo contrario, falso
        /// </returns></returns>
        public static bool operator +(Escaner e, Documento d)
        {
            if (e.ListaDocumentos.Contains(d))
            {
                throw new DocumentoDuplicadoException("El documento ya esta en el escaner.");
            }
            if (e == d || d.Estado != Documento.Paso.Inicio)
                return false;

            if ((e.Tipo == TipoDoc.libro && d is Libro) || (e.Tipo == TipoDoc.mapa && d is Mapa))
            {
                d.AvanzarEstado();
                e.ListaDocumentos.Add(d);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Comprueba si un escáner contiene un documento específico.
        /// </summary>
        /// <param name="e">El escáner en el que se realiza la búsqueda</param>
        /// <param name="d">El documento que se busca en el escáner</param>
        /// <returns>Verdadero si el escáner contiene el documento especificado, de lo contrario, falso.</returns>

        public static bool operator ==(Escaner e, Documento d)
        {
            foreach (Documento documento in e.listaDocumentos)
            {
                if ((documento is Libro libro && d is Libro libroD && libro == libroD) ||
                    (documento is Mapa mapa && d is Mapa mapaD && mapa == mapaD))
                {
                    return true;
                }
            }
            return false;  
        } 
    }
        #endregion Metodos
}





#pragma warning restore CS0660
#pragma warning restore CS0661