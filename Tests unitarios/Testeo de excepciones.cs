using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using EntidadesAbstractas;
using Excepciones;

namespace TestsUnitarios
{
    [TestClass]
    public class TestExcepciones
    {
        /// <summary>
        /// Testea si se produce la excepcion y esta es del tipo correcto al agregar un alumno repetido
        /// </summary>
        [TestMethod]
        public void TestExcepcionAlumnoRepetido()
        {
            Profesor profesor = new Profesor(4, "Juan", "Medina", "96123000", Persona.ENacionalidad.Extranjero);
            Jornada jornada = new Jornada(Universidad.EClases.Laboratorio, profesor);
            Alumno alumnoUno = new Alumno(15, "Ramiro", "Algo", "17580000", EntidadesAbstractas.Persona.ENacionalidad.Argentino,
            Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
            Alumno alumnoDos = new Alumno(15, "Ramiro", "Algo", "17580000", EntidadesAbstractas.Persona.ENacionalidad.Argentino,
            Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
            jornada += alumnoUno;
            try
            {
                jornada += alumnoDos;
                Assert.Fail("Se agrego un alumno identico a uno ya agregado");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        /// <summary>
        /// Testea si se produce la excepcion y esta es del tipo correcto al instanciar una persona con formato de dni invalido
        /// </summary>
        [TestMethod]
        public void TestExcepcionDniInvalido()
        {
            try
            {
                Profesor profesor = new Profesor(3, "Enrique", "Vito", "aaaaaaaaaaa", Persona.ENacionalidad.Extranjero);
                Assert.Fail("Se instancio un profesor con DNI invalido");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }       
    }
}
