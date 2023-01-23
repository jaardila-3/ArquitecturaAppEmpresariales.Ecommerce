namespace ArquitecturaAppEmpresariales.Ecommerce.Application.Test
{
    /// <summary>
    /// proyecto MsTest
    /// </summary>
    [TestClass]
    public class UsersApplicationTest
    {
        [TestMethod]
        public void Authenticate_CuandoNoSeEnvianParametros_RetornarMensajeErrorValidacion()
        {
            // Arrange
            var userName = string.Empty;
            var password = string.Empty;
            var expected = "Errores de Validación";

            // Act            
            //var result = context.Authenticate(userName, password);
            //var actual = result.Message;

            // Assert
            //Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosCorrectos_RetornarMensajeExito()
        {
            // Arrange
            var userName = "ALEX";
            var password = "123456";
            var expected = "Autenticación Exitosa!!!";

            //Act
            //Assert
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosIncorrectos_RetornarMensajeUsuarioNoExiste()
        {
            // Arrange
            var userName = "ALEX";
            var password = "123456899";
            var expected = "Usuario no existe";

            //Act
            //Assert
        }
    }
}