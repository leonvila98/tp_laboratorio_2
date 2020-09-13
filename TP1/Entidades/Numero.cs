using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region "Constructores"
        /// <summary>
        /// Instancia un objeto del tipo Numero e inicializa el atributo numero en 0.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Instancia un objeto del tipo Numero.
        /// </summary>
        /// <param name="numero">Tipo double - Valor del atributo numero</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Instancia un objeto del tipo Numero.
        /// </summary>
        /// <param name="numeroStr">Tipo string - Valor del atributo numero</param>
        public Numero(string numeroStr)
        {
            this.SetNumero = numeroStr;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Valida que strNumero sea un numero.
        /// </summary>
        /// <param name="strNumero">Tipo string - Numero a validar</param>
        /// <returns>Tipo double - Retorna el numero valido en tipo double, de no serlo retorna 0</returns>
        private double ValidarNumero(string strNumero)
        {
            double dblNumero;
            if(double.TryParse(strNumero, out dblNumero))
            {
                return dblNumero;
            }
            return 0;
        }

        /// <summary>
        /// Valida que binario contenga solamente unos o ceros.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Tipo bool - Retorna true de ser binario y false de no serlo. </returns>
        private static bool EsBinario(string binario)
        {
            char[] array = binario.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != '1' && array[i] != '0')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Convierte un numero binario en decimal.
        /// </summary>
        /// <param name="binario">Tipo string - Valor a convertir</param>
        /// <returns>Tipo string - Retorna el valor binario en decimal, de no ser binario retorna "Valor invalido"</returns>
        public static string BinarioDecimal(string binario)
        {
            if (Numero.EsBinario(binario))
            {
                int resultado = 0;
                char[] array = binario.ToCharArray();
                Array.Reverse(array);
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        resultado += (int)Math.Pow(2, i);
                    }
                }
                return resultado.ToString();
            }
            else
            {
                return "Valor invalido";
            }
        }

        /// <summary>
        /// Convierte un numero decimal en binario.
        /// </summary>
        /// <param name="numeroDou">Tipo double - Valor a convertir</param>
        /// <returns>Tipo string - Retorna el valor decimal a binario, de no ser mayor a cero retorna "Valor invalido"</returns>
        public static string DecimalBinario(double numeroDou)
        {
            int numero = Convert.ToInt32(numeroDou);
            string binario = "";
            if (numero > 0)//PROBAR SACANDO ESTE IF
            {
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        binario = "0" + binario;
                    }
                    else
                    {
                        binario = "1" + binario;
                    }
                    numero = (int)numero / 2;
                }
            }
            else if (numero == 0)
            {
                binario = "0";
            }
            else
            {
                binario = "Valor invalido";
            }
            return binario;
        }

        /// <summary>
        /// Convierte un numero decimal en binario.
        /// </summary>
        /// <param name="numeroStr">Tipo string - Valor a convertir</param>
        /// <returns>Tipo string - Retorna el valor decimal a binario, de no ser mayor a cero retorna "Valor invalido"</returns>
        public static string DecimalBinario(string numeroStr)
        {
            string binario = "";
            if (double.TryParse(numeroStr, out double numero))
            {
                binario = Numero.DecimalBinario(numero);
            }
            return binario;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Asigna un valor al atributo numero validando que sea un numero, de no serlo asigna cero.
        /// </summary>
        public string SetNumero
        {
            set 
            {
                this.numero = ValidarNumero(value);
            }
        }
        #endregion

        #region "Sobrecarga de operadores"
        /// <summary>
        /// Suma los atributos numero de dos objetos del tipo Numero.
        /// </summary>
        /// <param name="n1">Tipo Numero - Primer operando</param>
        /// <param name="n2">Tipo Numero - Segundo operando</param>
        /// <returns>Tipo double - Retorna el resultado de la operacion</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double resultado = n1.numero + n2.numero;
            return resultado;
        }

        /// <summary>
        /// Resta los atributos numero de dos objetos del tipo Numero.
        /// </summary>
        /// <param name="n1">Tipo Numero - Primer operando</param>
        /// <param name="n2">Tipo Numero - Segundo operando</param>
        /// <returns>Tipo double - Retorna el resultado de la operacion</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double resultado = n1.numero - n2.numero;
            return resultado;
        }

        /// <summary>
        /// Multiplica los atributos numero de dos objetos del tipo Numero.
        /// </summary>
        /// <param name="n1">Tipo Numero - Primer operando</param>
        /// <param name="n2">Tipo Numero - Segundo operando</param>
        /// <returns>Tipo double - Retorna el resultado de la operacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double resultado = n1.numero * n2.numero;
            return resultado;
        }

        /// <summary>
        /// Divide los atributos numero de dos objetos del tipo Numero.
        /// </summary>
        /// <param name="n1">Tipo Numero - Primer operando</param>
        /// <param name="n2">Tipo Numero - Segundo operando</param>
        /// <returns>Tipo double - Retorna el resultado de la operacion. De ser una division por cero, retorna el minimo valor posible </returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            double resultado = n1.numero / n2.numero;
            return resultado;
        }
        #endregion
    }
}
