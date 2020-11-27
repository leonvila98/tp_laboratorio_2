using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Atributos
        public enum EClases { Programacion = 0, Laboratorio = 1, Legislacion = 2, SPD = 3}
        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornada;
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de un objeto Universidad, instancia sus atributos
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Serializa y guarda en formato XML un objeto Universidad especificado
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>true si lo guardo-false si no lo guardo</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> serializador = new Xml<Universidad>();
            return serializador.Guardar("UniversidadDatos.xml", uni);
        }

        /// <summary>
        /// Deserializa y lee un archivo XML convirtiendolo en un objeto Universidad
        /// </summary>
        /// <returns>Objeto Universidad deserializado</returns>
        public Universidad Leer()
        {
            Universidad uni;
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Xml<Universidad> deserializador = new Xml<Universidad>();
            if (deserializador.Leer(ruta + "/UniversidadDatos.txt", out uni))
            {
                return uni;
            }
            else
                return null;
        }

        /// <summary>
        /// Convierte todas las jornadas de una universidad a string
        /// </summary>
        /// <param name="uni">Objeto Universidad</param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            foreach(Jornada j in uni.Jornadas)
            {
                sb.AppendLine(j.ToString()+ "\n<------------------------------------------->");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Convierte los atributos del objeto Universidad en string
        /// </summary>
        /// <returns>String con informacion del objeto Universidad</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
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
                if(value != null)
                    this.alumnos = value; 
            }
        }
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                if (value != null)
                    this.profesores = value;
            }
        }
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                if (value != null)
                    this.jornada = value;
            }
        }

        /// <summary>
        /// Se accederá a una Jornada específica de la Universidad a través de un indexador
        /// </summary>
        /// <param name="i">Indexador</param>
        /// <returns>Jornada</returns>
        public Jornada this[int i]
        {
            get
            {
                if (i <= this.Jornadas.Count)
                {
                    return this.Jornadas[i];
                }
                else
                    return null;
            }
            set
            {
                if (i <= this.Jornadas.Count)
                {
                    this.Jornadas[i] = value;
                }
            }
        }

        /// <summary>
        /// Una Universidad será distinta a un Alumno si el mismo no está inscripto en ella.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>bool</returns>
        public static bool operator !=(Universidad g,Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Un Universidad será distinto a un Profesor si el mismo no está dando clases en él
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>bool</returns>
        public static bool operator !=(Universidad g,Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// retornará el primer Profesor que no pueda dar la clase especificada
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">EClase</param>
        /// <returns>Profesor</returns>
        public static Profesor operator !=(Universidad u,EClases clase)
        {
            foreach (Profesor p in u.Instructores)
            {
                if (p != clase)
                {
                    return p;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Agrega una clase a una Universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">EClase</param>
        /// <returns>Universidad con la nueva clase</returns>
        public static Universidad operator +(Universidad g,EClases clase)
        {
            Jornada jNueva;
            foreach(Profesor i in g.Instructores)
            {
                if(i==clase)
                {
                    jNueva = new Jornada(clase, i);
                    foreach (Alumno a in g.Alumnos)
                    {
                        if (a == clase)
                        {
                            jNueva.Alumnos.Add(a);
                        }
                    }
                    g.Jornadas.Add(jNueva);
                    break;
                }
                else
                { throw new SinProfesorException(); }
            }
            return g;
        }

        /// <summary>
        /// Agregara un Alumno a la Universidad +, validando que no este previamente cargados.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Universidad con el alumno ya cargado</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
                return u;
            }
            else 
            { throw new AlumnoRepetidoException(); }    
        }

        /// <summary>
        /// Agregara un Profesor a la Universidad +, validando que no este previamente cargados.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Universidad con el Profesor ya cargado</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.Instructores.Add(i);
            return u;
        }

        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>bool</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach(Alumno al in g.Alumnos)
            {
                if (al == a)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>bool</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor p in g.Instructores)
            {
                if (p == i)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Clase retornará el primer Profesor capaz de dar la clase especificada
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">EClase</param>
        /// <returns>Profesor</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.Instructores)
            {
                if (p == clase)
                    return p;
            }
            throw new SinProfesorException(); 
        }

        #endregion
    }
}
