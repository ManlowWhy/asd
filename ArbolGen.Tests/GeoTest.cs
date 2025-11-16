using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GMap.NET; // paquete NuGet: GMap.NET.Core


namespace ArbolGen.Tests
{
    [TestClass]
    public class GeoTests
    {
        private static double LlamarHaversine(double lat1, double lon1, double lat2, double lon2)
        {
            var acceso = new PrivateType(typeof(MapaTest.FormMapa));
            var a = new PointLatLng(lat1, lon1);
            var b = new PointLatLng(lat2, lon2);
            return (double)acceso.InvokeStatic("HaversineKm", new object[] { a, b });
        }

        private static double A_Radianes(double grados)
        {
            var acceso = new PrivateType(typeof(MapaTest.FormMapa));
            return (double)acceso.InvokeStatic("ToRad", new object[] { grados });
        }

        private static double A_Grados(double rad)
        {
            var acceso = new PrivateType(typeof(MapaTest.FormMapa));
            return (double)acceso.InvokeStatic("ToDeg", new object[] { rad });
        }

        [TestMethod]
        public void Haversine_MismasCoordenadas_CeroKm()
        {
            var d = LlamarHaversine(9.935, -84.091, 9.935, -84.091);
            Assert.IsTrue(Math.Abs(d) < 1e-6, $"Esperado ~0 km, fue {d} km");
        }

        [TestMethod]
        public void Haversine_DistanciaDe1GradoEnEcuador_Aprox111_195km()
        {
            var d = LlamarHaversine(0, 0, 1, 0);
            Assert.IsTrue(Math.Abs(d - 111.19508) < 0.1, $"Esperado ~111.195 km, fue {d} km");
        }

        [TestMethod]
        public void Haversine_Antipodas_Aprox20015km()
        {
            var d = LlamarHaversine(0, 0, 0, 180);
            Assert.IsTrue(Math.Abs(d - 20015.114) < 1.0, $"Esperado ~20015.114 km, fue {d} km");
        }

        [TestMethod]
        public void Conversion_Angulos_ToRad_ToDeg_SonInversas()
        {
            double x = 42.1234;
            double rad = A_Radianes(x);
            double deg = A_Grados(rad);
            Assert.IsTrue(Math.Abs(deg - x) < 1e-9, "ToRad/ToDeg no son inversas");
        }
    }
}
