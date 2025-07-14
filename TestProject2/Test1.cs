using Modelo_de_final;

namespace TestProject2
{
    [TestClass]
    public sealed class Test1
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
            var guerrero = new Guerrero(1, "Conan", 2);

            Assert.AreEqual(110,guerrero.PuntosDeDefensa);
        }

        [TestMethod]
        public void Hechicero_TienePuntosDeDefensaEsperados()
        {
            var hechicero = new Hechicero(2, "Gandalf", 2);
            Assert.AreEqual(100, hechicero.PuntosDeDefensa);
        }
    }
}
