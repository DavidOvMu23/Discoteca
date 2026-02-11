using System;
using System.Data;
using Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public sealed class TestUnitarios
    {
        [TestMethod]
        // prueba para comprobar si deja alquilar un vinilo que no ha sido devuelto
        public void ViniloDisponible()
        {
            var controller = new AlquileresController();
            var dt = new DataTable();
            dt.Columns.Add("id_vinilo", typeof(int));
            dt.Columns.Add("fecha_devolucion_real", typeof(DateTime));

            dt.Rows.Add(5, DBNull.Value);

            var disponible = controller.ViniloDisponible(dt, 5);

            Assert.IsFalse(disponible);
        }

        [TestMethod]
        // prueba para comprobar si se toleran artistas repetidos
        public void ArtistaRepetido()
        {
            var controller = new ArtistasController();
            var dt = new DataTable();
            dt.Columns.Add("nombre_artista", typeof(string));

            dt.Rows.Add("Muse");

            var disponible = controller.NombreArtistaDisponible(dt, "muse");

            Assert.IsFalse(disponible);
        }
    }
}
