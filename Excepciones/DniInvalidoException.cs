using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private static string mensajeBase = "El dni tiene formato invalido";

        /// <summary>
        /// Constructor de una excepcion en caso de dni invalido
        /// </summary>
        public DniInvalidoException() : base(DniInvalidoException.mensajeBase)
        { }

        /// <summary>
        /// Constructor de una excepcion en caso de dni invalido
        /// </summary>
        /// <param name="message">Mensaje a incluir</param>
        public DniInvalidoException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor de una excepcion en caso de dni invalido
        /// </summary>
        /// <param name="e">Exception interna a incluir</param>
        public DniInvalidoException(Exception e) : this(DniInvalidoException.mensajeBase, e)
        {}

        /// <summary>
        /// Constructor de una excepcion en caso de dni invalido
        /// </summary>
        /// <param name="message">Mensaje a incluir</param>
        /// <param name="e">Exception interna a incluir</param>
        public DniInvalidoException(string message, Exception e) : base(message, e)
        {}
    }
}
