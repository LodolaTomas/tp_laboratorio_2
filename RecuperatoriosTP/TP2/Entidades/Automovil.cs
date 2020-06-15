using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Entidades
{
    

    public class Automovil : Vehiculo
    {
        /// <summary>
        /// Tipo de Vehiculo
        /// </summary>
        public enum ETipo { Monovolumen, Sedan }

        private ETipo tipo;

        /// <summary>
        /// Instancia los datos del Automovil. Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca">Marca del Automovil</param>
        /// <param name="chasis">Chasis del Automovil</param>
        /// <param name="color">Color del Automovil</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color)
            : this(marca, chasis, color, ETipo.Monovolumen)
        {
            
        }

        /// <summary>
        /// Instancia los datos del Automovil
        /// </summary>
        /// <param name="marca">Marca del Automovil</param>
        /// <param name="chasis">Chasis del Automovil</param>
        /// <param name="color">Color del Automovil</param>
        /// <param name="tipo">Tipo de Automovil</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color,ETipo tipo):
            base(chasis, marca, color)
        {
            this.tipo = tipo;
        }


        /// <summary>
        /// Devuelve el Tamano de la Camioneta (Mediano)
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Muestra todos los datos del Automovil
        /// </summary>
        /// <returns>Retorna todos los datos del Automovil en formato string</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO: " + this.Tamanio);
            sb.AppendLine("TIPO: " + this.tipo);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
