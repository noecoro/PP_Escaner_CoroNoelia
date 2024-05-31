#pragma warning disable CS0660
#pragma warning disable CS0661
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public  class Libro : Documento
    {
        #region ATRIBUTO
        private int numPaginas;
        #endregion atributo
        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="titulo">título del libro.</param>
        /// <param name="autor">autor del libro</param>
        /// <param name="anio">año de publicación del libro</param>
        /// <param name="numNormalizado">número normalizado del libro(isbn)</param>
        /// <param name="codebar">código de barras del libro</param>
        /// <param name="numPaginas">número de páginas del libro</param>
        public Libro(string titulo, string autor, int anio, string numNormalizado, string codebar, int numPaginas) : base(titulo, autor, anio, numNormalizado, codebar)
        {
            this.numPaginas = numPaginas;
        }
        #region PROPIEDADES
        /// <summary>
        /// Obtiene el número ISBN normalizado.
        /// </summary>
        public string ISBN { get => NumNormalizado; }
        /// <summary>
        /// Obtiene el número de páginas del libro.
        /// </summary>
        public int NumPaginas { get=> numPaginas; }
        #endregion propiedades
        #region METODOS 4
        /// <summary>
        /// Determina si dos instancias de "Libro" son iguales, comparando sus códigos de barras, ISBN, título y autor.
        /// </summary>
        /// <param name="l1">El primer libro a comparar</param>
        /// <param name="l2">El segundo libro a comparar</param>
        /// <returns>true si las instancias son iguales; de lo contrario, retona false</returns>
        public static bool operator == (Libro l1, Libro l2)
        {
            bool retorno = false;
            if ((l1.Barcode == l2.Barcode) || (l1.ISBN == l2.ISBN) ||
                (l1.Autor == l2.Autor && l1.Titulo == l2.Titulo))
            {
                retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Determina si dos instancias "Libro" no son iguales.
        /// </summary>
        /// <param name="l1">El primer libro a comparar.</param>
        /// <param name="l2">El segundo libro a comparar.</param>
        /// <returns> true si las instancias no son iguales; de lo contrario, retorna false</returns>
        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }
        /// <summary>
        /// Devuelve una  cadena del objeto "Libro",
        /// incluyendo la información básica del libro y el número de páginas.
        /// </summary>
        /// <returns>Una cadena que contiene la información del libro formateado.</returns>
        public override string ToString()
        {
            StringBuilder text = new StringBuilder(base.ToString());
            text.AppendLine($"\tNúmero de páginas: {NumPaginas.ToString()}.");
            return text.ToString();
        }
        #endregion metodos
    }
}

#pragma warning restore CS0660
#pragma warning restore CS0661
