using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion 

        #region Constructores
        public Universitario()
        { }
        /// <summary>
        /// Constructor de un objeto Universitario
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo,string nombre,string apellido,string dni,ENacionalidad nacionalidad)
            :base(nombre,apellido,dni,nacionalidad)
        {
            this.Legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Convierte los atributos del objeto Universitario en string
        /// </summary>
        /// <returns>String con informacion del objeto Universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}\n\nLEGAJO NUMERO: {1}", base.ToString(), this.Legajo);
            return sb.ToString();
        }

        /// <summary>
        /// Determina si eun objeto es del tipo Universitario
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        public override bool Equals(object obj)
        {
            if (obj.Equals(typeof(Universitario)))
                return true;
            else
                return false;
            //return this.Equals(obj);
        }
        #endregion

        #region Propiedades
        public int Legajo
        {
            get { return this.legajo; }
            set 
            { 
                if(value>0)
                {
                    this.legajo = value;
                }
            }
        }

        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>bool</returns>
        public static bool operator ==(Universitario pg1,Universitario pg2)
        {
            if (pg1.Equals(pg2) && (pg1.DNI == pg2.DNI || pg1.Legajo == pg2.Legajo))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Dos Universitario serán distintos si son distinto Tipo o su Legajo o DNI son distintos
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
