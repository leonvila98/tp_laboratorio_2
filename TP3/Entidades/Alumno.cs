using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributos
        public enum EEstadoCuenta { AlDia, Deudor, Becado}
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de un objeto Alumno
        /// </summary>
        public Alumno()
        { }
        /// <summary>
        /// Constructor de un objeto Alumno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de un objeto Alumno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Convierte los atributos del objeto Alumno en string
        /// </summary>
        /// <returns>String con informacion del objeto Alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}\n\nESTADO DE CUENTA: {1}\nTOMA CLASES DE {2}", base.MostrarDatos(), this.estadoCuenta, this.claseQueToma);
            return sb.ToString();
        }

        /// <summary>
        /// Convierte los atributos del objeto Alumno en string
        /// </summary>
        /// <returns>String con informacion del objeto Alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Convierte en string las clases del Alumno
        /// </summary>
        /// <returns></returns>
        protected string ParticiparEnClase()
        {
            return $"\nTOMA CLASE DE {this.claseQueToma}";
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="c"></param>
        /// <returns>bool</returns>
        public static bool operator ==(Alumno a, Universidad.EClases c)
        {
            if (a.claseQueToma == c && a.estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="c"></param>
        /// <returns>bool</returns>
        public static bool operator !=(Alumno a, Universidad.EClases c)
        {
            return !(a == c);
        }
        #endregion
    }
}
