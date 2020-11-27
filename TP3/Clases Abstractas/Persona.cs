using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    
    public abstract class Persona
    {
        #region Atributos
        public enum ENacionalidad { Argentino, Extranjero }
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;
        #endregion

        #region Constructores
        public Persona()
        { }
        /// <summary>
        /// Constructor de un objeto Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre,string apellido,ENacionalidad nacionalidad)
            :this(nombre,apellido,"",nacionalidad)
        {

        }
        /// <summary>
        /// Constructor de un objeto Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,dni.ToString(),nacionalidad)
        {

        }

        /// <summary>
        /// Constructor de un objeto Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido,string dni, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.StringToDNI = dni;
        }
        #endregion

        #region Propiedades 
        public string Nombre
        {
            get 
            { 
                return this.nombre; 
            }
            set 
            {
                this.nombre = ValidarNombreApellido(value); 
            }
        }
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        public int DNI
        {
            get
            { 
                return this.dni; 
            }
            set 
            {
                this.dni = ValidarDni(Nacionalidad, value);  
            }
        }
        /// <summary>
        /// Convierte el atributo Dni en string
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(Nacionalidad, value);
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Convierte los atributos del objeto Persona en string
        /// </summary>
        /// <returns>String con informacion del objeto Persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Nombre completo: {0}, {1}\nNacionalidad: {2}",
                            Apellido,Nombre,Nacionalidad);
            return sb.ToString();

        }

        /// <summary>
        /// Validará que los nombres sean cadenas con caracteres válidos para nombres
        /// </summary>
        /// <param name="dato">string a validar</param>
        /// <returns>string validado</returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char ch in dato)
            {
                if (!Char.IsLetter(ch))
                {
                    return "Nombre Invalido";
                }
            }
            return dato;
        }

        /// <summary>
        /// Validara que el DNI sea correcto, teniendo en cuenta su nacionalidad. Argentino entre 1 y 89999999 y Extranjero entre 90000000 y 99999999.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dni"></param>
        /// <returns>Dni validado</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dni)
        {
            if(((nacionalidad == ENacionalidad.Argentino) && dni >= 1 && dni <= 89999999)||
                ((nacionalidad == ENacionalidad.Extranjero) && dni >= 90000000 && dni <= 99999999))
            {
                return dni;
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
        }

        /// <summary>
        /// Validara que el DNI sea correcto
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dni"></param>
        /// <returns>Dni validado</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dni)
        {
            int dniInt;
            if (int.TryParse(dni, out dniInt) && dni.Length <= 8 && dni.Length >= 1)
            {
                return ValidarDni(nacionalidad, dniInt);
            }
            else
            {
                throw new DniInvalidoException();
            }
        }
        #endregion
    }
}
