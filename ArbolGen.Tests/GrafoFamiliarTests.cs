using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapaTest;

namespace ArbolGen.Tests
{
    [TestClass]
    public class GrafoFamiliarTests
    {
        [TestInitialize]
        public void AntesDeCadaPrueba()
        {
            GrafoFamiliar.Nodos.Clear();
        }

        [TestMethod]
        public void AgregarNodo_InsertaEnDiccionario()
        {
            var n = new NodoFamiliar { Nombre = "Ana", Parentezco = "Madre" };
            GrafoFamiliar.AgregarNodo(n);

            Assert.IsTrue(GrafoFamiliar.Nodos.ContainsKey("Madre"));
            Assert.AreEqual("Ana", GrafoFamiliar.Nodos["Madre"].Nombre);
        }

        [TestMethod]
        public void AgregarNodoConPadre_AgregaHijoEnPadre()
        {
            var padre = new NodoFamiliar { Nombre = "Juan", Parentezco = "Padre" };
            GrafoFamiliar.AgregarNodo(padre);

            var hijo = new NodoFamiliar { Nombre = "Luis", Parentezco = "Hijo" };
            GrafoFamiliar.AgregarNodo(hijo, "Padre");

            Assert.AreEqual(1, GrafoFamiliar.Nodos["Padre"].Hijos.Count);
            Assert.AreEqual("Luis", GrafoFamiliar.Nodos["Padre"].Hijos[0].Nombre);
        }

        [TestMethod]
        public void AgregarNodo_PadreNoExiste_NoRevienta()
        {
            var hijo = new NodoFamiliar { Nombre = "Luis", Parentezco = "Hijo" };
            GrafoFamiliar.AgregarNodo(hijo, "NoExiste");

            Assert.IsTrue(GrafoFamiliar.Nodos.ContainsKey("Hijo"));
            Assert.IsFalse(GrafoFamiliar.Nodos.ContainsKey("NoExiste"));
        }

        [TestMethod]
        public void AgregarNodo_ParentezcoDuplicado_ApuntaAlUltimo()
        {
            var a = new NodoFamiliar { Nombre = "A1", Parentezco = "Madre" };
            var b = new NodoFamiliar { Nombre = "A2", Parentezco = "Madre" };
            GrafoFamiliar.AgregarNodo(a);
            GrafoFamiliar.AgregarNodo(b);

          
            Assert.IsTrue(GrafoFamiliar.Nodos.ContainsKey("Madre"), "No existe clave 'Madre'.");
            Assert.AreEqual("A2", GrafoFamiliar.Nodos["Madre"].Nombre, "La clave 'Madre' no apunta al último nodo insertado.");

            
        }

    }
}
