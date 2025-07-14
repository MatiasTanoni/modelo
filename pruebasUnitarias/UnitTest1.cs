using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace pruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void CrearPersonajeConNivelInvalido_LanzaBusinessException()
        {
            var personaje = new Guerrero(1, "Conan", 0);
        }

        [TestMethod]
        public void RecibirAtaque_NoDebeQuedarConVidaNegativa()
        {
            var personaje = new Guerrero(1, "Conan", 1);

            personaje.RecibirAtaque(999999);

            Assert.IsTrue(personaje.PuntosDeVida >= 0);
        }

        [TestMethod]
        public void Guerrero_TienePuntosDeDefensaEsperados()
        {
            var guerrero = new Guerrero(1, "Conan", 1);

            Assert.AreEqual(100, guerrero.PuntosDeDefensa);
        }

        [TestMethod]
        public void Hechicero_TienePuntosDeDefensaEsperados()
        {
            var hechicero = new Hechicero(2, "Gandalf", 1);

            Assert.AreEqual(50, hechicero.PuntosDeDefensa);
        }
    }
}
