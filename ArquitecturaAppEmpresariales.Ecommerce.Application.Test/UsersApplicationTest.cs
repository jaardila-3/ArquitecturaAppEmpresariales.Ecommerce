using ArquitecturaAppEmpresariales.Ecommerce.Application.Interface;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ArquitecturaAppEmpresariales.Ecommerce.Application.Test
{
    /// <summary>
    /// proyecto MsTest
    /// </summary>
    [TestClass]
    public class UsersApplicationTest
    {
        private static WebApplicationFactory<Program>? _factory = null;
        private static IServiceScopeFactory? _scopeFactory = null;

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
        }

        [TestMethod]
        public void Authenticate_CuandoNoSeEnvianParametros_RetornarMensajeErrorValidacion()
        {
            using var scope = _scopeFactory!.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            // Arrange
            var userName = string.Empty;
            var password = string.Empty;
            var expected = "Errores de Validaci�n";

            // Act            
            var result = context!.Authenticate(userName, password);
            var actual = result.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosCorrectos_RetornarMensajeExito()
        {
            using var scope = _scopeFactory!.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            // Arrange
            var userName = "jorge";
            var password = "2404";
            var expected = "Autenticaci�n Exitosa!!!";

            // Act
            var result = context!.Authenticate(userName, password);
            var actual = result.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosIncorrectos_RetornarMensajeUsuarioNoExiste()
        {
            using var scope = _scopeFactory!.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            // Arrange
            var userName = "ALEX";
            var password = "123456899";
            var expected = "Usuario no existe";

            // Act
            var result = context!.Authenticate(userName, password);
            var actual = result.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}