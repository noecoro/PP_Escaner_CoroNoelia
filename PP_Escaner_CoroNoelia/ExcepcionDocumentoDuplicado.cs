using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DocumentoDuplicadoException : Exception
    {
        public DocumentoDuplicadoException() { }

        public DocumentoDuplicadoException(string mensaje)
            : base(mensaje) { }

        public DocumentoDuplicadoException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
    //internal class ExcepcionDocumentoDuplicado
    //{

    //}
}
