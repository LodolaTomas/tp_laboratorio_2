using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    

    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }

        private EMarca marca;
        private string chasis;
        private ConsoleColor color;


        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio
        { 
            get;
        }

        /// <summary>
        /// Instancia todos los datos del Vehiculo
        /// </summary>
        /// <param name="chasis">Chasis del Vehiculo</param>
        /// <param name="marca">Marca del Vehiculo</param>
        /// <param name="color">Color del Vehiculo</param>
        public Vehiculo(string chasis,EMarca marca,ConsoleColor color)
        {
            this.marca = marca;
            this.chasis = chasis;
            this.color = color;
        }
        /// <summary>
        /// Muestra todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Convierte explicitamente a string los datos del Vehiculo
        /// </summary>
        /// <param name="p">Vehiculo a convertir sus datos</param>
        /// <returns>Retorna los datos del Vehiculo en formanto string</returns>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CHASIS: {p.chasis}");
            sb.AppendLine($"MARCA : {p.marca}");
            sb.AppendLine($"COLOR : {p.color}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Un Vehiculo</param>
        /// <param name="v2">Otro Vehiculo</param>
        /// <returns>Retorna true si son iguales, false en caso contrario</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis==v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">Un Vehiculo</param>
        /// <param name="v2">Otro Vehiculo</param>
        /// <returns>Retorna true si son diferentes, false en caso contrario</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
    }
}
