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
       private int numPaginas;

        public Libro(string titulo, string autor, int anio, string numNormalizado, string codebar, int numPaginas) : base(titulo, autor, anio, numNormalizado, codebar)
        {
            this.numPaginas = numPaginas;
        }
        #region PROPIEDADES
        public string ISBN { get => NumNormalizado; }
        public int NumPaginas { get=> numPaginas; }
        #endregion propiedades

        #region METODOS 4
        /// <summary>
        /// Determina si dos instancias "Libro" no son iguales.
        /// </summary>
        /// <param name="l1">El primer libro a comparar.</param>
        /// <param name="l2">El segundo libro a comparar.</param>
        /// <returns> true si las instancias no son iguales; de lo contrario, retorna false</returns>
        public static bool operator != (Libro l1, Libro l2) 
        {
            return !(l1 == l2);
        }
        /// <summary>
        /// Determina si dos instancias de "Libro" son iguales, comparando sus códigos de barras, ISBN, título y autor.
        /// </summary>
        /// <param name="l1">El primer libro a comparar</param>
        /// <param name="l2">El segundo libro a comparar</param>
        /// <returns>true si las instancias son iguales; de lo contrario, retona false</returns>
        public static bool operator == (Libro l1, Libro l2)
        { 
            return l1.Barcode == l2.Barcode ||
                   l1.ISBN == l2.ISBN || l1.Anio == l2.Anio || l1.NumPaginas == l2.NumPaginas ||
                   (l1.Titulo == l2.Titulo && l1.Autor == l2.Autor);
        }
        /// <summary>
        /// Devuelve una  cadena del objeto "Libro",
        /// incluyendo la información básica del libro y el número de páginas.
        /// </summary>
        /// <returns>Una cadena que contiene la información del libro formateado.</returns>
        public override string ToString()
        { 
            StringBuilder text = new StringBuilder(base.ToString());

            text.AppendLine($"Numero de paginas: {NumPaginas.ToString()}");

            return text.ToString();
            }
        #endregion
    }
}

#pragma warning restore CS0660
#pragma warning restore CS0661
