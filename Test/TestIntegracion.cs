using Model;

namespace Test
{
    /// <summary>
    /// Pruebas de integración con la base de datos.
    /// </summary>
    [TestClass]
    public sealed class TestIntegracion
    {
        [TestMethod]
        /// <summary>
        /// Comprueba que la conexión a la base de datos funciona.
        /// </summary>
        public void TestConexion()
        {
            var _model = new AlquileresModel();
            bool res = _model.PruebaConexion();

            Assert.AreEqual(true, res);
        }
    }
}
