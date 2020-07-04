using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete: IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public delegate void DelegadoEstado(object sender, EventArgs evento);
        public event DelegadoEstado InformarEstado;

        public enum EEstado{
            Ingresado,
            EnViaje,
            Entregado
        }

        /// <summary>
        /// Propiedad de lectura y escritura de la direccion de entrega de Paquete
        /// </summary>
        public string DireccionEntrega 
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del estado de Paquete
        /// 
        /// </summary>
        public EEstado Estado 
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        
        /// /// <summary>
        /// Propiedad de lectura y escritura del Tracking ID de Paquete 
        /// </summary>
        public string TrackingID 
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        /// <summary>
        /// Hace que un paquete cambie de estado y lo guarda en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado += 1;
                this.InformarEstado(this, new EventArgs());
            }
            PaqueteDAO.Insertar(this);
        }

        /// <summary>
        /// Compila la informacion del paquete pasado como parametro
        /// </summary>
        /// <param name="elemento">Un paquete</param>
        /// <returns>Retorna una cadena con formato de los datos del paquete</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
             Paquete p = (Paquete)elemento;
             return string.Format("{0} para {1}", p.trackingID, p.direccionEntrega);
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Verifica si dos paquetes son iguales de acuerdo a su Tracking ID
        /// </summary>
        /// <param name="p1">Un paquete</param>
        /// <param name="p2">Otro paquete</param>
        /// <returns>Retorna true si los paquetes son iguales, false caso contrario</returns>
        public static bool operator ==(Paquete p1,Paquete p2)
        {
            bool retorno = false;
            if (p1.TrackingID == p2.TrackingID)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Constructor de la clase paquete que instancia sus datos
        /// </summary>
        /// <param name="direccionEntrega">Direccion de entrega del paquete</param>
        /// <param name="trackingID">Tracking ID del paquete</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.TrackingID = trackingID;
            this.DireccionEntrega = direccionEntrega;
            this.Estado = EEstado.Ingresado;
        }

        public override string ToString()
        {
            return this.MostrarDatos(this)+ " " + this.Estado.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
