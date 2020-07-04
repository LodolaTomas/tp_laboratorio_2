using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guarda en el escritorio el texto pasado como parametro en un archivo .txt
        /// </summary>
        /// <param name="texto">Texto a guardar</param>
        /// <param name="archivo">Nombre del archivo</param>
        /// <returns>Retorna true si se guardo, false caso contrario</returns>
        public static bool Guardar(this string texto, string archivo)
            {
                bool retorno = false;
                try
                {
                    using (StreamWriter escritor = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo, true))
                    {
                        escritor.WriteLine(texto);
                        retorno = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                return retorno;
            }
    }
}
