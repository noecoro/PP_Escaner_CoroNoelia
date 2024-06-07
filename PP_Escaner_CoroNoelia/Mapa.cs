using System;
#pragma warning disable CS0660
#pragma warning disable CS0661
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public  class Mapa : Documento
    {
        #region ATRIBUTOS
        private int alto;
        private int ancho;
        #endregion atributos
        /// <summary>
        /// Inicializa una nueva instancia de la clase mapa
        /// con los datos proporcionados, además de las dimensiones de alto y ancho.
        /// </summary>
        /// <param name="titulo">título del mapa</param>
        /// <param name="autor">autor del mapa</param>
        /// <param name="anio">año de publicación del mapa</param>
        /// <param name="numNormalizado">número normalizado del mapa</param>
        /// <param name="codebar">código de barras del mapa</param>
        /// <param name="alto">dimensión de alto del mapa</param>
        /// <param name="ancho">dimensión de ancho del mapa</param>
        public Mapa(string titulo, string autor, int anio, string numNormalizado, string codebar, int alto,int ancho) : base(titulo, autor, anio, "", codebar)
        {
            this.alto = alto;
            this.ancho = ancho;
        }
        #region PROPIEDADES
        /// <summary>
        /// Obtiene la dimensión de alto del mapa.
        /// </summary>
        public int Alto { get => alto; }
        /// <summary>
        /// Obtiene la dimensión de ancho del mapa.
        /// </summary>
        public int Ancho { get => ancho; }
        /// <summary>
        /// Obtiene la superficie del mapa, calcula el producto de su altura y ancho.
        /// Si la altura o el ancho del mapa es menor o igual a cero, la superficie se considera cero.
        /// </summary>
        public int Superficie
        {
            get
            {
                if (alto <= 0 || ancho <= 0)
                {
                    return 0;
                }
                return alto * ancho;
            }
        }
        #endregion propiedades 

        #region METODOS
        /// <summary>
        /// Determina si dos instancias de "Mapa" son diferentes, comparando si son iguales.
        /// </summary>
        /// <param name="m1">El primer mapa a comparar.</param>
        /// <param name="m2">El segundo mapa a comparar.</param>
        /// <returns>true si las instancias son diferentes; de lo contrario, retorna false returns>
        public static bool operator !=(Mapa m1, Mapa m2) 
        {
            return !(m1 == m2);

        }
        /// <summary>
        /// Determina si dos instancias de "Mapa" son iguales, comparando sus atributos.
        /// </summary>
        /// <param name="m1">El primer mapa a comparar</param>
        /// <param name="m2">El segundo mapa a comparar</param>
        /// <returns>true si las instancias son iguales; de lo contrario, retorna false </returns>
        public static bool operator ==(Mapa m1, Mapa m2)
        {
            bool retorno = false;
            if ((m1.Barcode == m2.Barcode) ||
                (m1.Titulo == m2.Titulo && m1.Autor == m2.Autor &&
                m1.Anio == m2.Anio && m1.Superficie == m2.Superficie))
            {
                retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Devuelve una representación de cadena que describe el mapa, incluyendo su superficie.
        /// </summary>
        /// <returns>Una cadena que representa el mapa, incluyendo su superficie.</returns>
        public override string ToString()
        { 
            StringBuilder text = new StringBuilder(base.ToString());
            text.AppendLine($"\tSuperficie: {Alto} * {Ancho} = {Superficie} cm2.\n");
            return text.ToString();
        }
        #endregion metodos
    }
}
#pragma warning restore CS0660
#pragma warning restore CS0661