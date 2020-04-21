using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {

        /// <summary>
        /// Realiza una operacion entre dos objetos de tipo Numero dependiendo del operador pasado como parametro
        /// </summary>
        /// <param name="num1">1er objeto Numero.</param>
        /// <param name="num2">2do objeto Numero.</param>
        /// <param name="operador">Operador que especifica la operacion a realizar</param>
        /// <returns>Retorna el resultado de la operacion.</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;
            operador = ValidarOperador(operador);

            if (num1 != null && num2 != null)
            {
                switch (operador)
                {
                    case "+":
                        retorno = num1 + num2;
                        break;
                    case "-":
                        retorno = num1 - num2;
                        break;
                    case "*":
                        retorno = num1 * num2;
                        break;
                    case "/":
                        retorno = num1 / num2;
                        break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Valida que el operador pasado como parametro sea {+,-,*,/}
        /// </summary>
        /// <param name="operador">Operador a ser validado</param>
        /// <returns>Retorna el operador si es valido o retornara el operador + en caso contrario</returns>
        private static string ValidarOperador(string operador)
        {
            string strAux = "+";
            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                strAux = operador;
            }
            return strAux;
        }
    }
}
