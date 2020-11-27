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
        /// Constructor de la excepcion nacionalidad invalida
        /// </summary>
        public NacionalidadInvalidaException()
            :this("La nacionalidad no se condice con el numero de DNI")
        {

        }
        /// <summary>
        /// Constructor de la excepcion nacionalidad invalida
        /// </summary>
        /// <param name="message">Mensaje de la excepcion</param>
        public NacionalidadInvalidaException(string message):base(message)
        {

        }
    }
}
