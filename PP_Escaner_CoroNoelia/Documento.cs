using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades;

public abstract class Documento
{
    public enum Paso { Inicio, Distribuido, EnEscaner, EnRevision, Terminado }

    private int anio;
    private string autor;
    private string barcode;
    private Paso estado;
    private string numNormalizado;
    private string titulo;

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
    public int Anio { get => anio; }
    public string Autor { get => autor; }
    public string Barcode { get => barcode; }
    public Paso Estado { get => estado; }
    protected string NumNormalizado { get => numNormalizado; }
    public string Titulo { get => titulo; }
    #endregion propiedades
    /// <summary>
    ///  Avanza el estado del documento a un siguiente paso en el proceso.
    /// </summary>
    /// <returns> Retorna true si el estado se avanzó con éxito; </returns>
    /// <returns> retorna false si el estado ya era "Paso.Terminado" y no se pudo avanzar.</returns>
    /// 
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
        string numNormalizado = this is Libro ? $"\nISBN: {this.NumNormalizado}" : "";
        StringBuilder text = new StringBuilder();

        text.AppendLine($"Titulo: {this.Titulo}");
        text.AppendLine($"Autor: {this.Autor}");
        text.AppendLine($"Año: {this.Anio.ToString()}{numNormalizado}");
        text.AppendLine($"Cod. de barras: {this.Barcode}");
        return text.ToString();
    }
}
