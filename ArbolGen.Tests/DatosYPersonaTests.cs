using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapaTest;
using System;


namespace ArbolGen.Tests
{
    [TestClass]
    public class DatosYPersonaTests
    {
        [TestInitialize]
        public void AntesDeCadaPrueba()
        {
            DatosGlobales.Familia.Clear();
        }

        [TestMethod]
        public void DatosGlobales_AgregarPersona_ConteoCorrecto()
        {
            DatosGlobales.Familia.Add(new Persona { Nombre = "Ana" });
            DatosGlobales.Familia.Add(new Persona { Nombre = "Luis" });
            Assert.AreEqual(2, DatosGlobales.Familia.Count);
        }

        private static int LlamarCalcularEdad(DateTime nacimiento)
        {
            var acceso = new PrivateType(typeof(MapaTest.FormRegistro));
            return (int)acceso.InvokeStatic("CalcularEdad", new object[] { nacimiento });
        }

        [TestMethod]
        public void CalcularEdad_Persona20Anios_Aprox20()
        {
            DateTime n = DateTime.Today.AddYears(-20);
            int edad = LlamarCalcularEdad(n);
            Assert.IsTrue(edad == 20 || edad == 19, $"Esperado ~20, resultó {edad}");
        }

        [TestMethod]
        public void CalcularEdad_FechaFutura_RetornaCero()
        {
            DateTime futuro = DateTime.Today.AddYears(5);
            int edad = LlamarCalcularEdad(futuro);
            Assert.AreEqual(0, edad);
        }
    }
}
