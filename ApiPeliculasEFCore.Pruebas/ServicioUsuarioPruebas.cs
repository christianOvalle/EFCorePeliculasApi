using ApiPeliculasEFCore.Servicios;

namespace ApiPeliculasEFCore.Pruebas
{
    [TestClass]
    public class ServicioUsuarioPruebas
    {
        [TestMethod]
        public void ObtenerUsuarioId_NoTraeValoresVacioONulo()
        {
            //Preparacion
            var servicioUsuario = new ServicioUsuario();

            // Prueba
            var resultado = servicioUsuario.ObtenerUsuarioId();

            // Verificacion
            Assert.AreNotEqual("", resultado);
            Assert.IsNotNull(resultado);
        }
    }
}