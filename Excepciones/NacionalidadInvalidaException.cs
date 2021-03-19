using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor de una excepcion en caso de que la nacionalidad sea invalida segun DNI
        /// </summary>
        public NacionalidadInvalidaException() : base("La nacionalidad no coincide con el numero de DNI")
        { }

        /// <summary>
        /// Constructor con mensaje especifico
        /// </summary>
        /// <param name="mensaje"></param>
        public NacionalidadInvalidaException(string mensaje) : base(mensaje)
        { }
    }
}
