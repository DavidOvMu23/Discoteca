using Model;

namespace Test
{
    [TestClass]
    public sealed class TestIntegracion
    {
        [TestMethod]
        public void TestConexion()
        {
            var _model = new AlquileresModel();
            bool res = _model.PruebaConexion();

            Assert.AreEqual(true, res);
        }
    }
}
