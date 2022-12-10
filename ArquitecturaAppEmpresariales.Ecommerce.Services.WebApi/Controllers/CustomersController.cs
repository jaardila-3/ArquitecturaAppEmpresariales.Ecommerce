using ArquitecturaAppEmpresariales.Ecommerce.Application.DTO;
using ArquitecturaAppEmpresariales.Ecommerce.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ArquitecturaAppEmpresariales.Ecommerce.Services.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerApplication _customerApplication;

        public CustomersController(ICustomerApplication customerApplication)
        {
            _customerApplication = customerApplication;
        }

        #region métodos Sincronos
        /// <summary>
        /// Método para insertar un cliente de manera sincrona en el aplicativo
        /// </summary>
        /// <param name="customersDto"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request: Campos mínimos obligatorios
        ///
        ///     POST
        ///     {
        ///        "customerId": "string",
        ///        "companyName": "string",
        ///     }
        /// </remarks>
        /// <response code="200"> Return:
        /// {
        ///     "data": true,
        ///     "isSuccess": true,
        ///     "message": "Registro Exitoso!!!"
        /// }
        /// </response>
        /// <response code="400">Return: Message Exception</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Insert([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null) return BadRequest();

            var response = _customerApplication.Insert(customersDto);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut]
        public IActionResult Update([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null) return BadRequest();

            var response = _customerApplication.Update(customersDto);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("{customerId}")]
        public IActionResult Delete(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = _customerApplication.Delete(customerId);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("{customerId}")]
        public IActionResult Get(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = _customerApplication.Get(customerId);
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _customerApplication.GetAll();
            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion

        #region "Métodos Asincronos"

        [HttpPost]
        public async Task<IActionResult> InsertAsincrono([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
                return BadRequest();
            var response = await _customerApplication.InsertAsync(customersDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsincrono([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
                return BadRequest();
            var response = await _customerApplication.UpdateAsync(customersDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteAsincrono(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();
            var response = await _customerApplication.DeleteAsync(customerId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetAsincrono(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();
            var response = await _customerApplication.GetAsync(customerId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsincrono()
        {
            var response = await _customerApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}
