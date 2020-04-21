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
       
        /// <summary>
        ///  Set de Numero que valida el value ingresado para setearlo al atributo numero
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        ///  Sobrecarga de constructor Numero, que setea el atributo numero, recibiendo el numero como string
        /// </summary>
        /// <param name="strNumero">El numero que es seteado en el atributo numero</param>
        public Numero(string strNumero) 
        { 
            this.SetNumero = strNumero; 
        }

        /// <summary>
        /// Sobrecarga de constructor Numero, que setea el atributo numero, recibiendo el numero como double.
        /// </summary>
        /// <param name="numero">El numero que es seteado en el atributo numero</param>
        public Numero(double numero) : this(numero.ToString())
        {

        }

        /// <summary>
        /// Constructor Numero, que inicializa al atributo numero = 0
        /// </summary>
        public Numero() : this(0)
        {

        }
        
        /// <summary>
        /// Realiza una resta entre dos objetos tipo Numero
        /// </summary>
        /// <param name="n1">1er objeto Numero</param>
        /// <param name="n2">2do objeto Numero</param>
        /// <returns>La resta entre ambos numeros</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double numAux;
            numAux = n1.numero - n2.numero;
            return numAux;
        }

        /// <summary>
        /// Realiza una multiplicacion entre dos objetos de tipo Numero
        /// </summary>
        /// <param name="n1">1er objeto Numero</param>
        /// <param name="n2">2do objeto Numero</param>
        /// <returns>La multiplicacion entre ambos numeros</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double numAux;
            numAux = n1.numero * n2.numero;
            return numAux;
        }

        /// <summary>
        /// Realiza una divicion entre dos objetos de tipo Numero
        /// </summary>
        /// <param name="n1">1er objeto numero.</param>
        /// <param name="n2">2do objeto numero.</param>
        /// <returns>El cociente entre ambos numeros o Retorna el double.MinValue en caso de que se quiera dividir entre 0</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double numAux= double.MinValue;
            if (n2.numero != 0)
            {
                numAux = n1.numero / n2.numero;
            }
            return numAux;
        }

        /// <summary>
        /// Realiza una suma entre dos objetos de tipo Numero.
        /// </summary>
        /// <param name="n1">1er objeto Numero.</param>
        /// <param name="n2">2do objeto Numero</param>
        /// <returns>La suma entre ambos numeros.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double numAux;
            numAux = n1.numero + n2.numero;
            return numAux;
        }

        /// <summary>
        /// Convierte un binario pasado como string a numero decimal
        /// </summary>
        /// <param name="binario">numero binario a convertir</param>
        /// <returns>El numero convertido a decimal o "Valor invalido" si ocurrio algun error</returns>
        public static string BinarioDecimal(string binario)
        {
            bool binAux = true;
            string strAux = "Valor Invalido";
            foreach (var c in binario)
            {
                if (c != '0' && c != '1')
                {
                    binAux = false;
                }
            }
            if (binAux == true)
            {
                strAux = Convert.ToInt32(binario, 2).ToString();
            }
            return strAux;
        }

        /// <summary>
        /// Convierte un numero decimal pasado como string a binario.
        /// </summary>
        /// <param name="numero">numero decimal a convertir</param>
        /// <returns>El numero convertido a binario o "Valor invalido" si ocurrio un error</returns>
        public static string DecimalBinario(string numero)
        {
            string strAux = "Valor Invalido";

            if (double.TryParse(numero, out double numAux))
            {
                strAux = DecimalBinario(numAux);
            }
            return strAux;
        }

        /// <summary>
        /// Convierte el numero pasado como double a decimal
        /// </summary>
        /// <param name="numero">numero decimal a convertir</param>
        /// <returns>El numero convertido a binario</returns>
        public static string DecimalBinario(double numero)
        {
            return Convert.ToString((int)Math.Abs(numero), 2);
        }

        /// <summary>
        /// Valida si lo pasado como parametro es un numero
        /// </summary>
        /// <param name="strNumero">numero a ser validado</param>
        /// <returns>El numero validado o 0 si ocurrio un error</returns>
        private double ValidarNumero(string strNumero)
        {
            double.TryParse(strNumero, out double numAux);
            return numAux;
        }
    }
}
