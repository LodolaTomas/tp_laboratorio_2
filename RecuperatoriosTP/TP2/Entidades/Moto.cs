using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        /// <summary>
        /// Instancia todos los datos de la Moto
        /// </summary>
        /// <param name="marca">Marca de la Moto</param>
        /// <param name="chasis">Chasis de la Moto</param>
        /// <param name="color">Color de la Moto</param>
        public Moto(EMarca marca, string chasis, ConsoleColor color):
            base(chasis,marca,color)
        {
            
        }

        /// <summary>
        /// Devuelve el Tamano de la Moto (Chico)
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Muestra todos los datos de la Moto
        /// </summary>
        /// <returns>Retorna todos los datos de la Moto en formato string</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO: {this.Tamanio}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
