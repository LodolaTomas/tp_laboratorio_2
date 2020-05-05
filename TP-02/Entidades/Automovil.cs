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
        
        private ETipo tipo;


        public enum ETipo { Monovolumen, Sedan }

        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            this.tipo = ETipo.Monovolumen;
        }

        public Automovil(EMarca marca, string chasis, ConsoleColor color,ETipo tipo):
            this(marca,chasis,color)
        {
            this.tipo = tipo;
        }


        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.Append("TAMAÑO : ");
            sb.AppendLine(this.Tamanio.ToString());
            sb.AppendLine("TIPO : " + this.tipo.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
