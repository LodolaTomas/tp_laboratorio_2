using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta : Vehiculo
    {
        /// <summary>
        /// Instancia todos los datos de la Camioneta
        /// </summary>
        /// <param name="marca">Marca de la Camioneta</param>
        /// <param name="chasis">Chasis de la Camioneta</param>
        /// <param name="color">Color de la camioneta</param>
        public Camioneta(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        /// <summary>
        /// Devuelve el Tamanio de la Camioneta (Grande)
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        /// <summary>
        /// Muestra todos los datos de la Camioneta
        /// </summary>
        /// <returns>Retorna los datos de la Camioneta en formato string</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMIONETA");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
