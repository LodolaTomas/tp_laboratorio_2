using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo :  IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        /// <summary>
        /// Propiedad de lectura y escritura de lista de paquetes.
        /// </summary>
        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }

        /// <summary>
        /// Constructor de la clase correo que instancia las listas.
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Cierra todos los hilos activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread h in this.mockPaquetes)
            {
                if (!Object.Equals(h, null))
                {
                    if (h.IsAlive)
                    {
                        h.Abort();
                    }
                }
            }
        }

        /// <summary>
        /// Compila la informacion de todos los paquetes
        /// </summary>
        /// <param name="elementos">Lista de paquetes</param>
        /// <returns>Retorna una cadena con los datos de cada paquete en la lista</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
                List<Paquete> listaPaquetes = ((Correo)elementos).Paquetes;

            foreach (Paquete p in listaPaquetes)
            {
                sb.AppendLine(string.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString()));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Agrega un paquete a la lista de paquetes del correo previa verificacion.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c,Paquete p)
        {
            Thread h = new Thread(p.MockCicloDeVida);
            foreach (Paquete paquete in c.Paquetes)
            {
                if (paquete == p)
                {
                    throw new TrackingIdRepetidoException("El Tracking ID " + p.TrackingID + " figura en la lista de envios");
                }
            }
            c.Paquetes.Add(p);
            c.mockPaquetes.Add(h);
            h.Start();            
            return c;
        }
    }
}
