using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;

namespace TestsUnitarios
{
    [TestClass]
    public class TestNulo
    {
        /// <summary>
        /// Testea si al instanciar una persona esta tiene el nombre nulo.
        /// </summary>
        [TestMethod]
        public void TestNombreValorNulo()
        {
            Alumno alumno = new Alumno(15, "Fulanito", "Rodriguez", "3546456", EntidadesAbstractas.Persona.ENacionalidad.Argentino,
            Universidad.EClases.SPD, Alumno.EEstadoCuenta.Becado);
            Assert.IsNotNull(alumno.Nombre);
        }
    }
}
