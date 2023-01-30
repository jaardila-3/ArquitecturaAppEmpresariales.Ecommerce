using ArquitecturaAppEmpresariales.Ecommerce.Application.Interface;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Modules.HealthCheck
{
    public class HealthCheckCustom : IHealthCheck
    {
        private readonly ICustomerApplication _customerApplication;
        //private readonly Random _random = new();

        public HealthCheckCustom(ICustomerApplication customerApplication)
        {
            _customerApplication = customerApplication;
        }

        /// <summary>
        /// Las comprobaciones de estado personalizadas se pueden usar para verificar
        /// el estado de los recursos externos, como las API de 3rd
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _customerApplication.GetAsync("ALFKI");
                if (response.IsSuccess)
                    return HealthCheckResult.Healthy("SI EXISTE EL CLIENTE");
                else
                    return HealthCheckResult.Unhealthy("NO EXISTE EL CLIENTE");
            }
            catch (Exception)
            {
                return HealthCheckResult.Unhealthy("EXCEPCION GENERADA");
            }

            //var responseTime = _random.Next(1, 300);
            //if (responseTime < 100)
            //{
            //    return HealthCheckResult.Healthy("Healthy result from HealthCheckCustom");
            //}
            //else if (responseTime < 200)
            //{
            //    return HealthCheckResult.Degraded("Degraded result from HealthCheckCustom");
            //}
            //return HealthCheckResult.Unhealthy("Unhealthy result from HealthCheckCustom");            
        }
    }
}
