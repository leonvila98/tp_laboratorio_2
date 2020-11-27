using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de un objeto Profesor
        /// </summary>
        private Profesor()
        { }
        /// <summary>
        /// Constructor de un objeto Profesor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            random = new Random();
            this._randomClases();
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
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
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
        /// Crea un string de las clases que da el Profesor
        /// </summary>
        /// <returns>string con la info</returns>
        protected string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            if(clasesDelDia != null)
            {
                sb.AppendFormat("CLASES DEL DIA:");
                foreach (Universidad.EClases c in clasesDelDia)
                {
                    sb.AppendFormat("\n{0}",c);
                }
            }     
            return sb.ToString();
        }

        /// <summary>
        /// Asigna dos clases al azar al Profesor
        /// </summary>
        private void _randomClases()
        {
            for(int i = 0; i<2; i++)
            {
                clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            }
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>bool</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach(Universidad.EClases c in i.clasesDelDia)
            {
                if (c == clase)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Un Profesor será distinto a un EClase si no da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>bool</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
