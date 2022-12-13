using ArquitecturaAppEmpresariales.Ecommerce.Transversal.Common;
using Microsoft.Extensions.Logging;

namespace ArquitecturaAppEmpresariales.Ecommerce.Transversal.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogError(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }
    }
}