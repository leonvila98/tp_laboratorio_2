using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {

        /// <summary>
        /// Constructor de la excepcion dni invalido
        /// </summary>
        public DniInvalidoException()
        {

        }
        /// <summary>
        /// Constructor de la excepcion dni invalido
        /// </summary>
        /// <param name="e">innerException</param>
        public DniInvalidoException(Exception e):this("DNI invalido",e)
        {

        }
        /// <summary>
        /// Constructor de la excepcion dni invalido
        /// </summary>
        /// /// <param name="message">Mensaje de la Excepcion</param>
        public DniInvalidoException(string message):base(message)
        {

        }
        /// <summary>
        /// Constructor de la excepcion dni invalido
        /// </summary>
        /// <param name="message">Mensaje de la Excepcion</param>
        /// <param name="e">innerException</param>
        public DniInvalidoException(string message, Exception e):base(message,e)
        {

        }
    }
}
