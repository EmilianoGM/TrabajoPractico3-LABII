using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor de una excepcion en caso de que ocurra un problema al guardar o cargar datos
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException) : base("Fallo al cargar o guardar el archivo", innerException)
        { }
    }
}
