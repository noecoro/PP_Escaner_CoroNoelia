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
        public enum Departamento { nulo, mapoteca, procesosTecnicos }
        public enum TipoDoc { libro, mapa }

        private  List<Documento> listaDocumentos;
        private Departamento locacion;
        private string marca;
        private TipoDoc tipo;
   
        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>();

            var tipoDepartamento = new Dictionary<TipoDoc, Departamento>
           {
           { TipoDoc.libro, Departamento.procesosTecnicos },
           { TipoDoc.mapa, Departamento.mapoteca }
             };
            if (tipoDepartamento.ContainsKey(tipo))
            {
                this.locacion = tipoDepartamento[tipo];
            }
            else
            {
                this.locacion = Departamento.nulo;
            }
        }

        #region PROPIEDADES
        public List<Documento> ListaDocumentos { get => listaDocumentos;  }
        public Departamento Locacion { get=>locacion;}
        public string Marca { get => marca;  }
        public TipoDoc Tipo { get=>tipo; }
        #endregion

        #region METODOS 
        /// <summary>
        /// Cambia el estado del documento especificado en la lista de documentos del escáner.
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
        /// <param name="e">El escáner</param>
        /// <param name="d">El documento</param>
        /// <returns>Verdadero si el documento no está presente en la lista de documentos del escáner; de lo contrario, retorna falso.</returns>
        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }
        /// <summary>
        /// Agrega un documento a la lista de documentos del escáner si cumple con ciertas condiciones.
        /// </summary>
        /// </summary>
        /// <param name="e">El escáner.</param>
        /// <param name="d">El documento a agregar</param>
        /// <returns>true si el documento se agregó con éxito a la lista de documentos del escáner; de lo contrario, false.
        /// </returns></returns>
        public static bool operator +(Escaner e, Documento d)
        {
            bool retorno = false;
            bool esTipoValido = (e.tipo == TipoDoc.libro && d is Libro) || (e.tipo == TipoDoc.mapa && d is Mapa);
            bool noExisteEnLista = !(e == d);
            bool esEstadoInicio = d.Estado == Paso.Inicio;
            if (esTipoValido && noExisteEnLista && esEstadoInicio)
            {
                if (d.AvanzarEstado())
                {
                    e.listaDocumentos.Add(d);      
                    retorno = true;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Comprueba si un documento está contenido en la lista de documentos de un escáner.
        /// </summary>
        /// <param name="e">El escáner en el que se busca el documento</param>
        /// <param name="d">El documento que se busca en la lista de documentos del escáner</param>
        /// <returns>True si el documento está en la lista de documentos del escáner,retorna false en caso contrario</returns>
        public static bool operator ==(Escaner e, Documento d)
        {
            foreach (Documento documento in e.listaDocumentos)
            {     
                if (documento.Equals(d))
                {
                    return true; 
                }
            }
            return false;
        }
        #endregion METODOS
    }
}
#pragma warning restore CS0660
#pragma warning restore CS0661