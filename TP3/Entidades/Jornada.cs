using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de un objeto Jornada, instancia la lista de alumnos
        /// </summary>
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de un objeto Jornada
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase,Profesor instructor):this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Guarda un objeto Jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>truie si lo guardo-false si no lo guardo</returns>
        public static bool Guardar(Jornada jornada)
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Texto writer = new Texto();
            return writer.Guardar(ruta + "/JornadaDatos.txt", jornada.ToString());
        }
        
        /// <summary>
        /// Convierte y lee un archivo de texto
        /// </summary>
        /// <returns>string del archivo ya convertido</returns>
        public static string Leer()
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string datos = string.Empty;
            Texto reader = new Texto();
            if (reader.Leer(ruta + "/JornadaDatos.txt", out datos))
            {
                return datos;
            }
            else
                return "No se pudo leer";
        }

        /// <summary>
        /// Convierte los atributos del objeto Jornada en string
        /// </summary>
        /// <returns>String con informacion del objeto Jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Clase de {0} por {1}\nAlumnos:", this.Clase, this.Instructor);
            foreach(Alumno a in this.Alumnos)
            {
                sb.AppendFormat("\n{0}", a.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get 
            { 
                return this.alumnos; 
            }
            set 
            {
                if (value != null)
                    this.alumnos = value;
            }
        }
        public Universidad.EClases Clase
        {
            get 
            { 
                return this.clase; 
            }
            set 
            { 
                this.clase = value; 
            }
        }
        public Profesor Instructor
        {
            get 
            { 
                return this.instructor; 
            }
            set 
            { 
                //if(value != null)
                    this.instructor = value; 
            }
        }

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>bool</returns>
        public static bool operator ==(Jornada j,Alumno a)
        {
            foreach(Alumno al in j.alumnos)
            {
                if (al == a)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Una Jornada será distinta a un Alumno si el mismo no participa de la clase
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega Alumnos a la clase validando que no estén previamente cargados
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.alumnos.Add(a);
            return j;
        }
        #endregion
    }
}
