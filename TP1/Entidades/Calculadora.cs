using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Hace una operacion entre dos numeros.
        /// Operadores permitidos: +(Suma), -(Resta), *(Multiplicacion), /(Division).
        /// </summary>
        /// <param name="num1">Tipo Numero - Primer operando</param>
        /// <param name="num2">Tipo Numero - Segundo operando</param>
        /// <param name="operador">Tipo string - Operador</param>
        /// <returns>Tipo double - Retorna el resultado de la operacion</returns>
        public double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            switch(ValidarOperador(char.Parse(operador)))
            {
                case "+":
                    {
                        resultado = num1 + num2;
                        break;
                    }
                case "-":
                    {
                        resultado = num1 - num2;
                        break;
                    }
                case "*":
                    {
                        resultado = num1 * num2;
                        break;
                    }
                case "/":
                    {
                        resultado = num1 / num2;
                        break;
                    }
                default:
                    {
                        num2.SetNumero = "0";
                        resultado = num1 + num2;
                        break;
                    }
            }
            return resultado;
        }
        
        /// <summary>
        /// Valida que un caracter sea igual a +, -, *, /.
        /// </summary>
        /// <param name="operador">Tipo char - Caracter a validar</param>
        /// <returns>Tipo string - Retorna el caracter validado, de no ser valido retorna +.</returns>
        private static string ValidarOperador(char operador)
        {
            if( operador == '+'||
                operador == '-'||
                operador == '*'|| 
                operador == '/')
            {
                return operador.ToString();
            }
            else
            {
                return "+";
            }
        }
    }
}
