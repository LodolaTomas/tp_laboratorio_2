using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace CorreoTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Verifica si la lista de paquetes del correo esta instanciada
        /// </summary>
        [TestMethod]
        public void ListaPaquetesInstanciadaTest()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        /// <summary>
        /// Verifica si no se pueden cargar dos paquetes con el mismo Tracking ID
        /// </summary>
        [TestMethod]
        public void PaqueteRepetidoTest()
        {
            try
            {
                Correo correo = new Correo();
                Paquete unP = new Paquete("Avenida siempre viva 742", "911-404-6536");
                correo += unP;
                correo += unP;
                Assert.Fail("El Tracking ID ya figura en la lista de envios");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
        }
    }
}
