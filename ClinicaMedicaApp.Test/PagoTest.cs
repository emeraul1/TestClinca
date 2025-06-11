using NUnit.Framework;
using System;
using ClinicaMedicaApp.Entidades.Pagos;

namespace ClinicaMedicaApp.Test
{
    [TestFixture]
    public class PagoTests
    {
        [Test]
        public void Pago_SeCreaCorrectamente()
        {
            var pago = new Pago(1, 100.50, new DateTime(2025, 6, 6));

            Assert.Multiple(() =>
            {
                Assert.That(pago.Id, Is.EqualTo(1));
                Assert.That(pago.Monto, Is.EqualTo(100.50));
                Assert.That(pago.FechaPago, Is.EqualTo(new DateTime(2025, 6, 6)));
            });
        }

        [Test]
        public void Pago_ProcesarPago_RetornaTrue()
        {
            var pago = new Pago(2, 150.00, DateTime.Today);

            bool resultado = pago.ProcesarPago();

            Assert.That(resultado, Is.True);
        }
    }
}