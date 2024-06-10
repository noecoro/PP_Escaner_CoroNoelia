using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Representa una excepción personalizada para indicar un tipo incorrecto en una operación.
    /// </summary>
    public class TipoIncorrectoException : Exception
    {
        string nombreClase;
        string nombreMetodo;

        /// <summary>
        /// Inicializa una nueva instancia de la clase TipoIncorrectoException"con un mensaje de error, nombre de la clase y nombre del método.
        /// </summary>
        /// <param name="mensaje">Mensaje de error que describe la excepción</param>
        /// <param name="nombreClase">Nombre de la clase donde ocurrió la excepción.</param>
        /// <param name="nombreMetodo">Nombre del método donde ocurrió la excepción.</param>
        public TipoIncorrectoException(string mensaje, string nombreClase, string nombreMetodo)
        : base(mensaje)
        {
            this.nombreMetodo = nombreMetodo;
            this.nombreClase = nombreClase;
        }
        #region constructores
        /// <summary>
        /// Inicializa una nueva instancia de la clase "TipoIncorrectoException" con un mensaje de error, nombre de la clase, nombre del método y una excepción interna
        /// </summary>
        /// <param name="mensaje">Mensaje de error que describe la excepción</param>
        /// <param name="nombreClase">Nombre de la clase donde ocurrió la excepción</param>
        /// <param name="nombreMetodo">Nombre del método donde ocurrió la excepción</param>
        /// <param name="innerException">Excepción interna que es la causa de esta excepción</param>
        public TipoIncorrectoException(string mensaje, string nombreClase, string nombreMetodo, Exception innerException)
            : base(mensaje, innerException)
        {
            this.nombreMetodo = nombreMetodo;
            this.nombreClase = nombreClase;
        }
        #endregion constructores
        #region propiedas
        /// <summary>
        /// Obtiene el nombre de la clase donde ocurrió la excepción.
        /// </summary>
        public string NombreClase { get => nombreClase; }
        /// <summary>
        /// Obtiene el nombre del método donde ocurrió la excepción.
        /// </summary>
        public string NombreMetodo { get => nombreMetodo; }
        #endregion propiedades
        #region Metodo
        /// <summary>
        /// Devuelve una cadena que representa la excepción actual.
        /// </summary>
        /// <returns>Cadena que representa la excepción actual</returns>
        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"Excepción en el método {NombreMetodo} de la clase {NombreClase}.");
            text.AppendLine("Algo salió mal, revisa los detalles");
            if (this.InnerException != null)
            {
                text.AppendLine($"Detalles: {this.InnerException.Message}");
            }
            else
            {
                text.AppendLine($"Detalles: {base.Message}");//error inesperado
            }
            return text.ToString();
        }
        #endregion
    }
}
