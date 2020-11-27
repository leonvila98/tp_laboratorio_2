using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using EntidadesAbstractas;
using Excepciones;

namespace UnitTest
{
    [TestClass]
    public class TP3Tests
    {
        [TestMethod]
        public void AtributosDeUniversidadInstanciadosCorrectamente()
        {
            Universidad u = new Universidad();

            Assert.IsTrue(  u.Alumnos != null &&
                            u.Instructores != null &&
                            u.Jornadas != null);
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void ValidacionNacionalidadAlumnoDeberiaLanzarExcepcion()
        {
            Alumno a = new Alumno(2, "Leon", "Vila", "92000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }
    }
}
