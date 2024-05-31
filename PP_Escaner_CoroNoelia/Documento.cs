using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades;

public abstract class Documento
{
    /// <summary>
    /// Enumera los posibles estados del documento en el proceso.
    /// </summary>
    public enum Paso 
    {
        /// <summary>
        /// El documento está en estado inicial.
        /// </summary>
        Inicio,
        /// <summary>
        /// El documento ha sido distribuido para su procesamiento.
        /// </summary>
        Distribuido,
        /// <summary>
        /// El documento está siendo escaneado.
        /// </summary>
        EnEscaner,
        /// <summary>
        /// El documento está en proceso de revisión.
        /// </summary>
        EnRevision,
        /// <summary>
        /// El documento ha sido terminado.
        /// </summary>
        Terminado
    }
    #region ATRIBUTOS
    private int anio;
    private string autor;
    private string barcode;
    private Paso estado;
    private string numNormalizado;
    private string titulo;
    #endregion atributos
    /// <summary>
    /// Constructor de la clase base Documento
    /// </summary>
    /// <param name="titulo">título del documento </param>
    /// <param name="autor">autor del documento</param>
    /// <param name="anio">año de publicación del documento</param>
    /// <param name="numNormalizado">número normalizado(isbn) del documento</param>
    /// <param name="barcode">código de barras del documento</param>
    public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
    {
        this.titulo = titulo;
        this.autor = autor;
        this.anio = anio;
        this.numNormalizado = numNormalizado;
        this.barcode = barcode;
        this.estado = Paso.Inicio;
    }
    #region PROPIEDADES
    /// <summary>
    /// Obtiene el año de publicacion del documento
    /// </summary>
    public int Anio { get => anio; }
    /// <summary>
    /// Obtiene el autor del documento.
    /// </summary>
    public string Autor { get => autor; }
    /// <summary>
    /// Obtiene el código de barras del documento.
    /// </summary>
    public string Barcode { get => barcode; }
    /// <summary>
    /// Obtiene  el estado del documento en el proceso.
    /// </summary>
    public Paso Estado { get => estado; }
    /// <summary>
    /// Obtiene el número normalizado(isbn) del documento.
    /// </summary>
    protected string NumNormalizado { get => numNormalizado; }
    /// <summary>
    ///  Obtiene el título del documento
    /// </summary>
    public string Titulo { get => titulo; }
    #endregion propiedades
    /// <summary>
    ///  Avanza el estado del documento si no está en el estado "Terminado".
    /// </summary>
    /// <returns>Retorna verdadero si el estado del documento se pudo avanzar, de lo contrario, falso; </returns>
    public bool AvanzarEstado()
    {
        if (estado == Paso.Terminado)
        {
            return false;
        }
        estado++;
        return true;
    }
    /// <summary>
    /// Devuelve una representación en cadena del objeto "Documento"
    /// incluyendo el título, autor, año, código de barras y, si corresponde tambien el número normalizado.
    /// </summary>
    /// <returns>Una cadena con la información del documento formateada.</returns>
    public override string ToString()
    {
        string numNormalizado = this is Libro ? $"\n\tISBN: {this.NumNormalizado}" : "";
        StringBuilder text = new StringBuilder();

        text.AppendLine($"\n\tTitulo: {this.Titulo}");
        text.AppendLine($"\tAutor: {this.Autor}");
        text.AppendLine($"\tAño: {this.Anio.ToString()}{numNormalizado}");
        text.AppendLine($"\tCód. de barras: {this.Barcode}");
        return text.ToString();
    }
}
